#!/bin/bash

# remove previous folder
rm -rf generated-sdk && mkdir generated-sdk

# generate the original JavaScript SDK
java -jar ./bin/utils/openapi-generator-cli.jar generate -i developer.yaml -g javascript -o generated-sdk

# update names to more appropriate names for markdown
sed -i -e 's/trulioo_sdk/trulioo-sdk/g; s/GIT_USER_ID/GIT-USER-ID/g; s/GIT_REPO_ID/GIT-REPO-ID/g;' generated-sdk/README.md

# update package with apache license and correct package names
sed -i -e 's/"license": "Unlicense"/"license": "Apache-2.0"/g; s/"name": "trulioo_sdk"/"name": "trulioo-sdk"/g; s/"description": "Trulioo_SDK"/"description": "Trulioo JavaScript SDK"/g;' generated-sdk/package.json
