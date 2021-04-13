#!/bin/bash

echo "[PHP SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-php/test/ && cp -r tests/php/. dist/sdk-php/test/
mkdir -p dist/sdk-php/sample-app/ && cp -r sample-apps/php/. dist/sdk-php/sample-app/
cp -r deploy/php/. dist/sdk-php/

echo "[Python SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-python/test/ && cp -r tests/python/. dist/sdk-python/test/
mkdir -p dist/sdk-python/sample-app/ && cp -r sample-apps/python/. dist/sdk-python/sample-app/
cp -r deploy/python/. dist/sdk-python/

echo "[Java SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-java/src/test/java/ && cp -r tests/java/* dist/sdk-java/src/test/java/
mkdir -p dist/sdk-java/sample-app/ && cp -r sample-apps/java/* dist/sdk-java/sample-app/
rm -rf dist/sdk-java/api/ dist/sdk-java/gradle/
cp -r deploy/java/. dist/sdk-java/
