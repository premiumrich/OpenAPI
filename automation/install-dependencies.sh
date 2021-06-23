#!/bin/bash

# Automated functional tests run in a Node Docker container
# Working directory: root of repo

apt-get update
apt-get install -y chromium=90.*
apt-get install -y php php-curl php-mbstring
curl -sS https://getcomposer.org/installer | php -- --install-dir=/usr/local/bin --filename=composer

printf "\n[JavaScript SDK] Installing dependencies for sample app\n"
cd dist/sdk-javascript/sample-app/
npm install

printf "\n[PHP SDK] Installing dependencies for sample app\n"
cd ../../sdk-php/sample-app/
composer install
