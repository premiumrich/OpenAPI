#!/bin/bash

echo "[JavaScript SDK] Generating sample app..."
mkdir -p dist/sdk-javascript/sample-app/static/
cp -r sample-apps/javascript/. dist/sdk-javascript/sample-app/
node automation/generate-sample-app.js configs/javascript.yaml dist/sdk-javascript/sample-app/static/
cp sample-apps/common/{index.js,styles.css} dist/sdk-javascript/sample-app/static/

echo "[PHP SDK] Generating sample app..."
mkdir -p dist/sdk-php/sample-app/
cp -r sample-apps/php/. dist/sdk-php/sample-app/
node automation/generate-sample-app.js configs/php.yaml dist/sdk-php/sample-app/
cp sample-apps/common/{index.js,styles.css} dist/sdk-php/sample-app/

echo "[Python SDK] Generating sample app..."
mkdir -p dist/sdk-python/sample-app/app/{static/,templates/}
cp -r sample-apps/python/. dist/sdk-python/sample-app/
node automation/generate-sample-app.js configs/python.yaml dist/sdk-python/sample-app/app/templates/
cp sample-apps/common/{index.js,styles.css} dist/sdk-python/sample-app/app/static/

echo "[Java SDK] Generating sample app..."
mkdir -p dist/sdk-java/sample-app/src/main/resources/static/
cp -r sample-apps/java/. dist/sdk-java/sample-app/
node automation/generate-sample-app.js configs/java.yaml dist/sdk-java/sample-app/src/main/resources/static/
cp sample-apps/common/{index.js,styles.css} dist/sdk-java/sample-app/src/main/resources/static/

echo "[Ruby SDK] Generating sample app..."
mkdir -p dist/sdk-ruby/sample-app/static/
cp -r sample-apps/ruby/. dist/sdk-ruby/sample-app/
node automation/generate-sample-app.js configs/ruby.yaml dist/sdk-ruby/sample-app/static/
cp sample-apps/common/{index.js,styles.css} dist/sdk-ruby/sample-app/static/

echo
