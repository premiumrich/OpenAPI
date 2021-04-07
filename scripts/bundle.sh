#!/bin/bash

echo "[PHP SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-php/test/ && cp -r tests/php/. dist/sdk-php/test/
mkdir -p dist/sdk-php/sample-app/ && cp -r sample-apps/php/. dist/sdk-php/sample-app/
cp -r deploy/php/. dist/sdk-php/

echo "[Python SDK] Copying supporting files to dist..."
mkdir -p dist/sdk-python/test/ && cp -r tests/python/. dist/sdk-python/test/
mkdir -p dist/sdk-python/sample-app/ && cp -r sample-apps/python/. dist/sdk-python/sample-app/
cp -r deploy/python/. dist/sdk-python/
