#!/bin/bash

# Automated functional tests run in a Node Docker container
# Working directory: root of repo

apt-get update
apt-get install -y chromium=90.*

printf "\n[JavaScript SDK] Installing dependencies for sample app\n"
cd dist/sdk-javascript/sample-app/
npm install

printf "\n[PHP SDK] Installing dependencies for sample app\n"
apt-get install -y php php-curl php-mbstring
curl -sS \
    https://raw.githubusercontent.com/composer/getcomposer.org/7eaf36ba91c05f00e46bc4a9d3fc5fe12d5160e5/web/installer \
    | php -- --install-dir=/usr/local/bin --filename=composer
cd ../../sdk-php/sample-app/
composer install

printf "\n[Python SDK] Installing dependencies for sample app\n"
update-alternatives --install /usr/bin/python python /usr/bin/python3 1
apt-get install -y python3-pip
cd ../../sdk-python/sample-app/
python -m pip install -r requirements.txt

printf "\n[Ruby SDK] Installing dependencies for sample app\n"
apt-get install -y ruby bundler
cd ../../sdk-ruby/sample-app/
bundle install

printf "\n[Java SDK] Installing dependencies for sample app\n"
apt-get -y install default-jdk maven
cd ../../sdk-java/sample-app/
mvn package

printf "\n[C# .NET Core SDK] Installing dependencies for sample app\n"
wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb 
apt-get update
apt-get install -y apt-transport-https dotnet-sdk-3.1
