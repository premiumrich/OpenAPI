#!/bin/bash

PACKAGE_NAME=$(grep '"name"' package.json | cut -d '"' -f4 | tr -d '[[:space:]]')
NPM_PACKAGE_VERSIONS=$(npm view $PACKAGE_NAME versions)
PACKAGE_VERSION=$(grep '"version"' package.json | cut -d '"' -f4 | tr -d '[[:space:]]')

echo "PACKAGE_NAME: " $PACKAGE_NAME
echo "NPM_PACKAGE_VERSIONS: " $NPM_PACKAGE_VERSION
echo "PACKAGE_VERSION: " $PACKAGE_VERSION

if [[ ${NPM_PACKAGE_VERSIONS[*]} =~ $PACKAGE_VERSION ]]
then
    echo "The version number is already being used"
    exit 1
fi