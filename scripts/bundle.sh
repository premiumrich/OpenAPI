#!/bin/bash

echo "[JavaScript SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-javascript/test/ && cp -r tests/javascript/. dist/sdk-javascript/test/
mkdir -p dist/sdk-javascript/sample-app/ && cp -r sample-apps/javascript/. dist/sdk-javascript/sample-app/
cp -r deploy/javascript/. dist/sdk-javascript/

echo "[PHP SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-php/test/ && cp -r tests/php/. dist/sdk-php/test/
mkdir -p dist/sdk-php/sample-app/ && cp -r sample-apps/php/. dist/sdk-php/sample-app/
cp -r deploy/php/. dist/sdk-php/

echo "[Python SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-python/test/ && cp -r tests/python/. dist/sdk-python/test/
mkdir -p dist/sdk-python/sample-app/ && cp -r sample-apps/python/. dist/sdk-python/sample-app/
cp -r deploy/python/. dist/sdk-python/

echo "[Java SDK] Copying supporting files to dist..."
rm -rf dist/sdk-java/api/ dist/sdk-java/gradle/
mkdir -p dist/sdk-java/src/test/java/ && cp -r tests/java/. dist/sdk-java/src/test/java/
mkdir -p dist/sdk-java/sample-app/ && cp -r sample-apps/java/. dist/sdk-java/sample-app/
cp -r deploy/java/. dist/sdk-java/

echo "[Ruby SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-ruby/spec/ && cp -r tests/ruby/. dist/sdk-ruby/spec/
mkdir -p dist/sdk-ruby/sample-app/ && cp -r sample-apps/ruby/. dist/sdk-ruby/sample-app/
