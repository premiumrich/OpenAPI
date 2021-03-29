#!/bin/bash

function getPublishedVersions() {
    case $1 in
        javascript)
            echo $(curl -s "https://registry.npmjs.com/$2" | \
                jq --compact-output ".versions | keys" 2>/dev/null)
            ;;
        php)
            echo $(curl -s "https://repo.packagist.org/p2/$2.json" | \
                jq --compact-output ".packages[] | map(.version)" 2>/dev/null)
            ;;
        python)
            echo $(curl -s "https://pypi.org/pypi/$2/json" | \
                jq --compact-output '.releases | keys' 2>/dev/null)
            ;;
    esac
}

function getLatestVersion() {
    case $1 in
        javascript)
            echo $(curl -s "https://registry.npmjs.com/$2" | \
                jq --raw-output ".\"dist-tags\".latest" 2>/dev/null)
            ;;
        php)
            echo $(curl -s "https://repo.packagist.org/p2/$2.json" | \
                jq --raw-output ".packages[][0].version" 2>/dev/null)
            ;;
        python)
            echo $(curl -s "https://pypi.org/pypi/$2/json" | \
                jq --raw-output '.info.version' 2>/dev/null)
            ;;
    esac
}

declare -A sdkLangs=(
    ["javascript"]="JavaScript"
    ["php"]="PHP"
    ["python"]="Python"
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
