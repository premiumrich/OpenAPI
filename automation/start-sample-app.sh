#!/bin/bash

# Start an SDK sample app with/without PROD_X_TRULIOO_API_KEY
# Working directory: root of repo
# Usage: start-sample-app.sh <language> ["withkey"]

declare -A config_paths=(
    ["javascript"]="src/routes.js"
    ["php"]="router.php"
    ["python"]="app/settings.py"
    ["java"]="src/main/resources/application.yml"
    ["ruby"]="app.rb"
    ["csharp-netcore"]="appsettings.json"
)

cd "dist/sdk-$1/sample-app/" || exit 1

# Create backup of original config file or restore original
if [[ -f "${config_paths[$1]}.orig" ]]; then
    cp -f "${config_paths[$1]}.orig" "${config_paths[$1]}"
else
    cp "${config_paths[$1]}" "${config_paths[$1]}.orig"
fi

# Insert PROD_X_TRULIOO_API_KEY if applicable
if [[ "$2" == "withkey" ]]; then
    sed -i "s/YOUR-X-TRULIOO-API-KEY/$PROD_X_TRULIOO_API_KEY/" "${config_paths[$1]}"
fi

bash start.sh
