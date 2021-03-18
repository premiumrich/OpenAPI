#!/bin/bash

echo "Copying tests to each SDK in dist..."
mkdir -p dist/sdk-php/test/ && cp -r tests/php/* dist/sdk-php/test/

echo "Copying sample apps to each SDK in dist..."
mkdir -p dist/sdk-php/sample-app/ && cp -r sample-apps/php/* dist/sdk-php/sample-app/
