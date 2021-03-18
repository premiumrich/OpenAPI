#!/bin/bash

function getPublishedVersions() {
    case $1 in
        javascript)
            echo $(npm view $2 versions 2>&1)
            ;;
        php)
            echo $(composer show $2 --available 2>&1 | grep "versions")
            ;;
    esac
}

function getLatestVersion() {
    case $1 in
        javascript)
            echo $(npm view $2 version 2>&1)
            ;;
        php)
            echo $(getPublishedVersions "php" $2 | cut -d "," -f3 | xargs)
            ;;
    esac
}

declare -A sdkLangs=(
    ["javascript"]="JavaScript"
    ["php"]="PHP"
)

status=0

for lang in "${!sdkLangs[@]}"; do
    echo "${sdkLangs[$lang]} SDK"
    configFile="configs/$lang.yaml"
    packageName=$(grep "packageName" $configFile | sed "s/packageName: //")
    printf "\tLatest published version: $(getLatestVersion $lang $packageName)\n"
    repoVersion=$(grep "artifactVersion" $configFile | sed "s/artifactVersion: //")
    printf "\tCurrent repo version: $repoVersion\n"
    publishedVersions=$(getPublishedVersions $lang $packageName)
    if [[ $publishedVersions =~ $repoVersion ]]; then
        printf "\t\e[31mConflict!\e[39m Current repo version has already been published\n"
        status=1
    fi
    echo
done

exit $status
