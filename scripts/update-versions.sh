#!/bin/bash

declare -A languages=(
    ["javascript"]="JavaScript"
    ["php"]="PHP"
    ["python"]="Python"
    ["java"]="Java"
)


branch_name=$(git rev-parse --abbrev-ref HEAD)
if [[ "$branch_name" == "master" || "$branch_name" == "qa" ]]; then
    branch_base="HEAD^"
else
    branch_base=$(git merge-base master HEAD)
fi

diff=$(git diff --staged --name-only "$branch_base")

spec_file="developer.yaml"

# For every SDK, print the current repo version.
# If there are changes to the API spec, config file, templates, tests, or sample app,
# automatically increment the patch version.
for lang in "${!languages[@]}"; do
    config_file="configs/${lang}.yaml"
    sdk_version=$(grep "artifactVersion" "$config_file" | sed "s/artifactVersion: //")
    echo "[${languages[$lang]} SDK] Current version: ${sdk_version}"

    echo "[${languages[$lang]} SDK] Checking for changes..."
    templates_folder="templates/${lang}/"
    tests_folder="tests/${lang}/"
    sample_app_folder="sample-apps/${lang}/"
    if [[ \
        $diff =~ $spec_file || \
        $diff =~ $config_file || \
        $diff =~ $templates_folder || \
        $diff =~ $tests_folder || \
        $diff =~ $sample_app_folder \
    ]]; then
        echo "[${languages[$lang]} SDK] Detected changes"
        is_new_sdk=$(! [[ $(git ls-tree -r --name-only "$branch_base") =~ $config_file ]] && echo true)
        previous_version=$(git show "${branch_base}:${config_file}" 2>/dev/null \
            | grep "artifactVersion" | sed "s/artifactVersion: //")
        current_version=$(grep "artifactVersion" "$config_file" | sed "s/artifactVersion: //")
        if [[ $is_new_sdk == true || "$previous_version" != "$current_version" ]]; then
            echo "[${languages[$lang]} SDK] Version has already been updated"
        else
            IFS="." read -r -a parts <<< "$current_version"
            new_version="${parts[0]}.${parts[1]}.$((parts[2]+1))"
            echo "[${languages[$lang]} SDK] Automatically bumping version from $current_version to $new_version"
            sed -i "s/artifactVersion: .*$/artifactVersion: $new_version/g" "$config_file"
            git add "$config_file" 2>/dev/null
        fi
    else 
        echo "[${languages[$lang]} SDK] No changes were detected"
    fi
    echo
done
