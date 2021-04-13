#!/bin/bash

base=$(git merge-base master HEAD)
diff=$(git diff --staged --name-only $base)

spec_file="developer.yaml"

declare -A languages=(
    ["javascript"]="JavaScript"
    ["php"]="PHP"
    ["python"]="Python"
    ["java"]="Java"
)

for lang in "${!languages[@]}"; do
    echo "[${languages[$lang]} SDK] Checking for any changes..."
    config_file="configs/$lang.yaml"
    templates_folder="templates/$lang/"
    tests_folder="tests/$lang/"
    sample_app_folder="sample-apps/$lang/"
    if [[ \
        $diff =~ $spec_file || \
        $diff =~ $config_file || \
        $diff =~ $templates_folder || \
        $diff =~ $tests_folder || \
        $diff =~ $sample_app_folder \
    ]]; then
        echo "[${languages[$lang]} SDK] Detected changes"
        is_new_sdk=$(! [[ $(git ls-tree -r --name-only $base) =~ $config_file ]] && echo true)
        is_version_updated=$([[ $(git diff --staged $base $config_file) =~ "+artifactVersion" ]] && echo true)
        if [[ $is_new_sdk == true || $is_version_updated == true ]]; then
            echo "[${languages[$lang]} SDK] Version has already been updated"
        else
            current_version=$(grep "artifactVersion" $config_file | sed "s/artifactVersion: //")
            IFS="." read -a parts <<< $current_version
            new_version="${parts[0]}.${parts[1]}.$((${parts[2]}+1))"
            echo "[${languages[$lang]} SDK] Automatically bumping version from $current_version to $new_version"
            sed -i "s/artifactVersion: .*$/artifactVersion: $new_version/g" $config_file
            git add $config_file 2>/dev/null
        fi
    else 
        echo "[${languages[$lang]} SDK] No changes were detected"
    fi
    echo
done
