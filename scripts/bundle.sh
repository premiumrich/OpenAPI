#!/bin/bash

declare -A sdkLangs=(
    ["php"]="PHP"
    ["python"]="Python"
)

for lang in "${!sdkLangs[@]}"; do
    echo "Copying ${sdkLangs[$lang]} tests and sample app to dist..."
    mkdir -p dist/sdk-$lang/test/ && cp -r tests/$lang/* dist/sdk-$lang/test/
    mkdir -p dist/sdk-$lang/sample-app/ && cp -r sample-apps/$lang/* dist/sdk-$lang/sample-app/
done
