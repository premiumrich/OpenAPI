#!/bin/bash

declare -A languages=(
    ["javascript"]="JavaScript"
    ["php"]="PHP"
    ["python"]="Python"
)


if [[ $CI != true ]]; then
    echo "Error: not deploying from Bitbucket Pipelines"
    exit 1
fi

if [[ $(git rev-parse --abbrev-ref HEAD) != "qa" ]]; then
    echo "Error: not deploying from QA branch"
    exit 1
fi

git fetch -q origin master:refs/remotes/origin/master

if ! (git merge-base --is-ancestor origin/master qa); then
    echo "Error: qa branch has diverged from master branch"
    exit 1
fi

git config --global user.name "Trulioo" && git config --global user.email "support@trulioo.com"

echo "Obtaining Bitbucket OAuth access token..."
bitbucket_client_credentials=$(curl https://bitbucket.org/site/oauth2/access_token \
    --silent --fail --show-error --request POST \
    --user "${BITBUCKET_CLIENT_KEY}:${BITBUCKET_CLIENT_SECRET}" \
    --data grant_type=client_credentials --data scopes="pullrequest:write") || exit $?
bitbucket_token=$(jq --raw-output '.access_token' <<< "${bitbucket_client_credentials}")
echo

spec_file="developer.yaml"
diff=$(git diff --name-only HEAD^)

# For every SDK, print the current repo version.
# If there are changes to the API spec, config file, templates, tests, or sample app, proceed with the update.
for lang in "${!languages[@]}"; do
    cd "${BITBUCKET_CLONE_DIR}" \
        || { echo "[${languages[$lang]} SDK] Unable to change directory to BITBUCKET_CLONE_DIR";
                 continue; }

    config_file="configs/${lang}.yaml"
    sdk_version=$(grep "artifactVersion" "$config_file" | sed "s/artifactVersion: //")
    echo "[${languages[$lang]} SDK] Current version: ${sdk_version}"

    echo "[${languages[$lang]} SDK] Checking for changes..."
    templates_folder="templates/${lang}/"
    tests_folder="tests/${lang}/"
    sample_app_folder="sample-apps/${lang}/"
    if ! [[ \
        $diff =~ $spec_file || \
        $diff =~ $config_file || \
        $diff =~ $templates_folder || \
        $diff =~ $tests_folder || \
        $diff =~ $sample_app_folder \
    ]]; then
        echo "[${languages[$lang]} SDK] No changes, skipping update"
        continue
    fi

    sdk_repo_name="sdk-${lang}"
    echo "[${languages[$lang]} SDK] Cloning ${sdk_repo_name} from Bitbucket..."
    git clone -q "https://x-token-auth:${bitbucket_token}@bitbucket.org/trulioo-rnd/${sdk_repo_name}" \
        "${BITBUCKET_CLONE_DIR}/../target/${sdk_repo_name}/"

    cd "${BITBUCKET_CLONE_DIR}/../target/${sdk_repo_name}/" \
        || { echo "[${languages[$lang]} SDK] Unable to change directory to ${sdk_repo_name}/";
                 continue; }

    if ! [[ $(git branch --list master) ]]; then
        echo "[${languages[$lang]} SDK] Master branch does not exist. Pushing initial empty commit..."
        git checkout -q -b master
        git commit -q --allow-empty -m "Initial commit"
        git push -q -u origin master \
            || { echo "[${languages[$lang]} SDK] Unable to push to master (are branch permissions configured?)";
                 continue; }
    fi

    sdk_branch_name="automated-update-$(cut -c1-7 <<< "${BITBUCKET_COMMIT}")-${BITBUCKET_BUILD_NUMBER}"
    echo "[${languages[$lang]} SDK] Committing changes to branch ${sdk_branch_name}..."
    git checkout -q -b "$sdk_branch_name"
    rsync --archive --delete --exclude=".git/" \
        "${BITBUCKET_CLONE_DIR}/dist/${sdk_repo_name}/" \
        "${BITBUCKET_CLONE_DIR}/../target/${sdk_repo_name}/"
    git add .
    commit_title=$'Automated update to '"$sdk_version"$'\n\n'
    commit_msg=$'Contains changes from this recent commit in Trulioo/OpenAPI:\n\n'
    openapi_commit_msg=$(git -C "$BITBUCKET_CLONE_DIR" log -1 --pretty="format:commit %H%n%n%w(0,4,4)%B")
    git commit -q -m "${commit_title}${commit_msg}${openapi_commit_msg}"

    echo "[${languages[$lang]} SDK] Tagging commit as ${sdk_version}..."
    git tag "$sdk_version"

    echo "[${languages[$lang]} SDK] Pushing branch and tag..."
    git push -q -u origin HEAD
    git push -q origin "$sdk_version"

    echo "[${languages[$lang]} SDK] Creating pull request..."
    default_reviewers=$(curl \
        "https://api.bitbucket.org/2.0/repositories/trulioo-rnd/${sdk_repo_name}/default-reviewers" \
        --silent --fail --show-error --request GET \
        --header "Authorization: Bearer ${bitbucket_token}" \
        | jq "[.values[] | select(.uuid != \"$BITBUCKET_STEP_TRIGGERER_UUID\")] | map({uuid})")
    curl "https://api.bitbucket.org/2.0/repositories/trulioo-rnd/${sdk_repo_name}/pullrequests" \
        --silent --fail --show-error --request POST \
        --header "Authorization: Bearer ${bitbucket_token}" \
        --header "Content-Type: application/json" \
        --data '{
            "title": "Automated update to '"$sdk_version"'",
            "source": { "branch": { "name": "'"$sdk_branch_name"'" } },
            "destination": { "branch": { "name": "master" } },
            "reviewers": '"$default_reviewers"'
        }' \
        || echo "[${languages[$lang]} SDK] Error occurred when automatically creating pull request"
    echo
done
