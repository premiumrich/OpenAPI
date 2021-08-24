#!/bin/bash

echo "[JavaScript SDK] Bundling supporting files..."
mkdir -p dist/sdk-javascript/test/
cp -r tests/unit/javascript/. dist/sdk-javascript/test/
cp -r deploy/javascript/. dist/sdk-javascript/

echo "[PHP SDK] Bundling supporting files..."
mkdir -p dist/sdk-php/test/
cp -r tests/unit/php/. dist/sdk-php/test/
cp -r deploy/php/. dist/sdk-php/

echo "[Python SDK] Bundling supporting files..."
mkdir -p dist/sdk-python/test/
cp -r tests/unit/python/. dist/sdk-python/test/
cp -r deploy/python/. dist/sdk-python/

echo "[Java SDK] Bundling supporting files..."
mkdir -p dist/sdk-java/src/test/java/
cp -r tests/unit/java/. dist/sdk-java/src/test/java/
cp -r deploy/java/. dist/sdk-java/
rm -rf dist/sdk-java/api/ dist/sdk-java/gradle/

echo "[Ruby SDK] Bundling supporting files..."
mkdir -p dist/sdk-ruby/spec/
cp -r tests/unit/ruby/. dist/sdk-ruby/spec/
cp -r deploy/ruby/. dist/sdk-ruby/

echo "[.NET Core SDK] Bundling supporting files..."
cp -r tests/unit/csharp-netcore/. dist/sdk-csharp-netcore/src/
cp -r deploy/csharp-netcore/. dist/sdk-csharp-netcore/

echo
