#!/bin/bash

base=$(git merge-base master HEAD)
diff=$(git diff --staged --name-only $base)

specFile="developer.yaml"

declare -A sdkLangs=(
    ["javascript"]="JavaScript"
    ["php"]="PHP"
    ["python"]="Python"
)

for lang in "${!sdkLangs[@]}"; do
    echo "Checking changes to ${sdkLangs[$lang]} SDK"
    configFile="configs/$lang.yaml"
    templateFolder="templates/$lang/"
    testsFolder="tests/$lang/"
    if [[ \
        "$diff" == *$specFile* || \
        "$diff" == *$configFile* || \
        "$diff" == *$templateFolder* || \
        "$diff" == *$testsFolder* \
    ]]; then
        echo "Detected changes that affect ${sdkLangs[$lang]} SDK"
        configDiff=$(git diff --staged $base $configFile)
        isNewSDK=$([[ "$configDiff" == *"new file"* ]] && echo 1 || echo 0)
        versionLineDiffCount=$(grep -c "artifactVersion" <<< $configDiff)
        if [[ $isNewSDK == 1 || $versionLineDiffCount > 1 ]]; then
            echo "Version of ${sdkLangs[$lang]} SDK has already been updated"
        else
            currentVersion=$(grep "artifactVersion" $configFile | sed "s/artifactVersion: //")
            IFS="." read -a parts <<< $currentVersion
            newVersion="${parts[0]}.${parts[1]}.$((${parts[2]}+1))"
            echo "Automatically bumping patch version of ${sdkLangs[$lang]} SDK from $currentVersion to $newVersion"
            sed -i "s/artifactVersion: .*$/artifactVersion: $newVersion/g" $configFile
            git add $configFile
        fi
    else 
        echo "No changes that affect ${sdkLangs[$lang]} SDK were detected"
    fi
    echo
done
