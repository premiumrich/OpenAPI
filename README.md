# Trulioo OpenAPI SDK Generator

To effectively maintain support of Trulioo SDKs across multiple languages, we use OpenAPI Generator to automatically
build API and model classes based on our OpenAPI 3.0 specification.

Please read [OpenAPI SDK Generation](https://trulioo.atlassian.net/wiki/spaces/RDT/pages/1884848801/OpenAPI+SDK+Generation)
for documentation about the project, development process, project structure, CI/CD pipelines, etc.

## Project Structure

File/Folder                         | Description
------------------------------------|-----------------------------------------------------------------------------------
`automation/`                       | Scripts that assist the automated generation and distribution of SDKs
`configs/`                          | Configurations for the generation of every SDK
`configs/shared/`                   | Shared configurations across all SDKs
`configs/openapi-generator-ignore/` | Ignore files that instruct the generator on what files to not generate
`deploy/`                           | CI/CD pipeline files for every SDK repository
`dist/` (ignored)                   | Output folder for generated SDKs
`sample-apps/`                      | Sample apps for every SDK
`scripts/`                          | Miscellaneous helper scripts
`templates/`                        | Mustache templates and other supporting files for every SDK
`tests/`                            | Unit tests for every SDK
`tests/functional/`                 | Functional tests for every SDK sample app
`bitbucket-pipelines.yml`           | Bitbucket pipelines for CI/CD
`developer.yaml`                    | Trulioo OpenAPI 3.0 specification that gets automatically updated
`openapitools.json`                 | Version configuration for OpenAPI Generator
`package.json`                      | OpenAPI Generator dependencies and definitions for npm scripts

## How to Generate SDKs

Run `npm ci` to install dependencies, then `npm run generate` to build SDKs in the `dist/` folder

## How to Run Unit Tests

After generating SDKs, follow the testing instructions in the `README.md` of every SDK in `dist/`

## How to Run Functional Tests

After [generating SDKs](#how-to-generate-sdks), run the `automation/install-dependencies.sh` script, then `npm test`
