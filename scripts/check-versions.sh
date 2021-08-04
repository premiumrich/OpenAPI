#!/bin/bash

declare -A languages=(
    ["javascript"]="JavaScript"
    ["php"]="PHP"
    ["python"]="Python"
    ["java"]="Java"
    ["ruby"]="Ruby"
    ["csharp-netcore"]="C# .NET Core"
)

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
            curl -s "https://pypi.org/pypi/trulioo-sdk/json" \
                | jq --raw-output '.info.version' 2>/dev/null
            ;;
        java)
            curl -s "https://search.maven.org/solrsearch/select?q=g:%22com.trulioo%22+AND+a:%22trulioo-sdk%22&rows=1000&wt=json" \
                | jq --raw-output '.response.docs[0].latestVersion' 2>/dev/null
            ;;
        ruby)
            curl -s "https://rubygems.org/api/v1/versions/trulioo_sdk/latest.json" \
                | jq --raw-output '.version' 2>/dev/null
            ;;
        csharp-netcore)
            curl -s "https://api.nuget.org/v3-flatcontainer/Trulioo.SDK/index.json" \
                | jq --raw-output '.versions[-1]' 2>/dev/null
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
            curl -s "https://pypi.org/pypi/trulioo-sdk/json" \
                | jq --compact-output '.releases | keys' 2>/dev/null
            ;;
        java)
            curl -s "https://search.maven.org/solrsearch/select?q=g:%22com.trulioo%22+AND+a:%22trulioo-sdk%22&core=gav&rows=1000&wt=json" \
                | jq --compact-output '.response.docs | map(.v)' 2>/dev/null
            ;;
        ruby)
            curl -s "https://rubygems.org/api/v1/versions/trulioo_sdk.json" \
                | jq --compact-output 'map(.number)' 2>/dev/null
            ;;
        csharp-netcore)
            curl -s "https://api.nuget.org/v3-flatcontainer/Trulioo.SDK/index.json" \
                | jq --raw-output '.versions' 2>/dev/null
            ;;
    esac
}


git fetch -q origin master:refs/remotes/origin/master

branch_name=$(git rev-parse --abbrev-ref HEAD)
if [[ "$branch_name" == "master" || "$branch_name" == "qa" ]]; then
    branch_base="HEAD^"
else
    branch_base=$(git merge-base origin/master HEAD)
fi

spec_file="developer.yaml"

exit_status=0

# For every SDK, print the latest published version and current repo version.
# If there are changes to the API spec, config file, templates, tests, or sample app,
# check if the current repo version conflicts with any published versions.
for lang in "${!languages[@]}"; do
    echo "[${languages[$lang]} SDK] Latest published version: $(get_latest_version "$lang")"
    config_file="configs/${lang}.yaml"
    sdk_version=$(grep "artifactVersion" "$config_file" | sed "s/artifactVersion: //")
    echo "[${languages[$lang]} SDK] Current version: ${sdk_version}"

    echo "[${languages[$lang]} SDK] Checking for changes..."
    templates_folder="templates/${lang}/"
    tests_folder="tests/${lang}/"
    sample_app_folder="sample-apps/${lang}/"

    diff=$(git diff --name-only "$branch_base")

    if [[ \
        $diff =~ $spec_file || \
        $diff =~ $config_file || \
        ($diff =~ $templates_folder && !($diff =~ "${templates_folder}README.mustache")) || \
        $diff =~ $tests_folder || \
        $diff =~ $sample_app_folder \
    ]]; then
        echo "[${languages[$lang]} SDK] Detected changes"
        if [[ $(get_published_versions "$lang") =~ $sdk_version ]]; then
            printf "[${languages[$lang]} SDK] \e[31mConflict!\e[39m Current version has already been published\n"
            exit_status=1
        else
            echo "[${languages[$lang]} SDK] Current version can be published"
        fi
    else
        echo "[${languages[$lang]} SDK] No changes were detected"
    fi
    echo
done

exit $exit_status
