#!/bin/bash


# Arguments: language
# Outputs: STDOUT
function get_latest_version() {
    case $1 in
        javascript)
            curl -s "https://registry.npmjs.com/trulioo-sdk" \
                | jq --raw-output '."dist-tags".latest' 2>/dev/null
            ;;
        php)
            curl -s "https://repo.packagist.org/p2/trulioo/trulioo-sdk.json" \
                | jq --raw-output '.packages[][0].version' 2>/dev/null
            ;;
        python)
            curl -s "https://pypi.org/pypi/trulioo_sdk/json" \
                | jq --raw-output '.info.version' 2>/dev/null
            ;;
        java)
            curl -s "https://search.maven.org/solrsearch/select?q=g:%22com.trulioo%22+AND+a:%22trulioo-sdk%22&rows=1000&wt=json" \
                | jq --raw-output '.response.docs[0].latestVersion' 2>/dev/null
            ;;
    esac
}


# Arguments: language
# Outputs: STDOUT
function get_published_versions() {
    case $1 in
        javascript)
            curl -s "https://registry.npmjs.com/trulioo-sdk" \
                | jq --compact-output '.versions | keys' 2>/dev/null
            ;;
        php)
            curl -s "https://repo.packagist.org/p2/trulioo/trulioo-sdk.json" \
                | jq --compact-output '.packages[] | map(.version)' 2>/dev/null
            ;;
        python)
            curl -s "https://pypi.org/pypi/trulioo_sdk/json" \
                | jq --compact-output '.releases | keys' 2>/dev/null
            ;;
        java)
            curl -s "https://search.maven.org/solrsearch/select?q=g:%22com.trulioo%22+AND+a:%22trulioo-sdk%22&core=gav&rows=1000&wt=json" \
                | jq --compact-output '.response.docs | map(.v)' 2>/dev/null
            ;;
    esac
}


if [[ $CI != true ]]; then
    echo "Not deploying from Bitbucket Pipelines! Exiting..."
    exit 1
fi

if [[ $(git rev-parse --abbrev-ref HEAD) != "qa" ]]; then
    echo "Not deploying from QA branch! Exiting..."
    exit 1
fi

git fetch origin master:refs/remotes/origin/master

if ! (git merge-base --is-ancestor origin/master qa); then
    echo "QA branch has diverged from master branch! Exiting..."
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

declare -A languages=(
    ["php"]="PHP"
)

for lang in "${!languages[@]}"; do
    echo "[${languages[$lang]} SDK] Latest published version: $(get_latest_version "${lang}")"
    sdk_version=$(grep "artifactVersion" "${BITBUCKET_CLONE_DIR}/configs/$lang.yaml" | sed "s/artifactVersion: //")
    echo "[${languages[$lang]} SDK] Current version: ${sdk_version}"

    if [[ $(get_published_versions "${lang}") =~ ${sdk_version} ]]; then
        echo "[${languages[$lang]} SDK] Version ${sdk_version} has already been published! Skipping update..."
        continue
    fi

    sdk_repo_name="sdk-${lang}"
    echo "[${languages[$lang]} SDK] Cloning ${sdk_repo_name} from Bitbucket..."
    git clone -q "https://x-token-auth:${bitbucket_token}@bitbucket.org/trulioo-rnd/${sdk_repo_name}" \
        "${BITBUCKET_CLONE_DIR}/../target/${sdk_repo_name}/"
    sdk_branch_name="automated-update-$(cut -c1-7 <<< "${BITBUCKET_COMMIT}")-${BITBUCKET_BUILD_NUMBER}"
    cd "${BITBUCKET_CLONE_DIR}/../target/${sdk_repo_name}/"

    if ! [[ $(git branch --list master) ]]; then
        echo "[${languages[$lang]} SDK] Master branch does not exist. Pushing initial empty commit..."
        git checkout -q -b master
        git commit -q --allow-empty -m "Initial commit"
        git push -q -u origin master \
            || { echo "[${languages[$lang]} SDK] Unable to push to master (are branch permissions configured?)";
                 continue; }
    fi

    echo "[${languages[$lang]} SDK] Committing changes to branch ${sdk_branch_name}..."
    git checkout -q -b "${sdk_branch_name}"
    rsync --archive --delete --exclude=".git/" \
        "${BITBUCKET_CLONE_DIR}/dist/${sdk_repo_name}/" \
        "${BITBUCKET_CLONE_DIR}/../target/${sdk_repo_name}/"
    git add .
    if ! [[ $(git diff --staged --name-only) ]]; then
        echo "[${languages[$lang]} SDK] No changes to commit. Skipping update..."
        continue
    fi
    commit_title=$'Automated update to '"${sdk_version}"$'\n\n'
    commit_msg=$'Contains changes from this recent commit in Trulioo/OpenAPI:\n\n'
    last_commit_msg=$(git -C "${BITBUCKET_CLONE_DIR}" log -1 --pretty="format:commit %H%n%n%w(0,4,4)%B")
    git commit -q -m "${commit_title}${commit_msg}${last_commit_msg}"

    echo "[${languages[$lang]} SDK] Tagging commit as ${sdk_version}..."
    git tag "${sdk_version}"

    echo "[${languages[$lang]} SDK] Pushing branch and tag..."
    git push -q -u origin HEAD
    git push -q origin "${sdk_version}"

    echo "[${languages[$lang]} SDK] Creating pull request..."
    default_reviewers=$(curl \
        "https://api.bitbucket.org/2.0/repositories/trulioo-rnd/${sdk_repo_name}/default-reviewers" \
        --silent --fail --show-error --request GET \
        --header "Authorization: Bearer ${bitbucket_token}" \
        | jq "[.values[] | select(.uuid != \"${BITBUCKET_STEP_TRIGGERER_UUID}\")] | map({uuid})")
    curl "https://api.bitbucket.org/2.0/repositories/trulioo-rnd/${sdk_repo_name}/pullrequests" \
        --silent --fail --show-error --request POST \
        --header "Authorization: Bearer ${bitbucket_token}" \
        --header "Content-Type: application/json" \
        --data '{
            "title": "Automated update to '"${sdk_version}"'",
            "source": { "branch": { "name": "'"${sdk_branch_name}"'" } },
            "destination": { "branch": { "name": "master" } },
            "reviewers": '"${default_reviewers}"'
        }' \
        || echo "[${languages[$lang]} SDK] Error occurred when automatically creating pull request"
    echo
done
