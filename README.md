# Trulioo OpenAPI SDK Generator

To effectively maintain support of our SDKs across multiple languages, we use OpenAPI Generator to automatically create
API and model classes based on our OpenAPI 3.0 specification.

Please read [OpenAPI SDK Generation](https://trulioo.atlassian.net/wiki/spaces/RDT/pages/1884848801/OpenAPI+SDK+Generation)
for documentation about the project, development process, project structure, CI/CD pipelines, etc.

## Project Structure

File/Folder                         | Description
------------------------------------|-----------------------------------------------------------------------------------
`configs/`                          | Configurations to instruct the generator on the creation of each SDK
`configs/shared/`                   | Shared configurations across all SDKs
`configs/openapi-generator-ignore/` | Files for each language to instruct the generator on what files to not generate
`deploy/`                           | CI/CD pipelines for every SDK repository
`dist/` (ignored)                   | Output folder for generated SDKs
`sample-apps/`                      | Sample apps for every SDK
`scripts/`                          | Scripts that assist the generation of SDKs
`templates/`                        | Mustache templates and other supporting files that get transformed by OpenAPI Generator
`tests/`                            | Manually written tests for API and model classes of every SDK
`bitbucket-pipelines.yml`           | Bitbucket pipelines for CI/CD
`developer.yaml`                    | Trulioo OpenAPI 3.0 spec that gets automatically updated
`openapitools.json`                 | Configuration of version for OpenAPI Generator
`package.json`                      | OpenAPI Generator dependencies and definitions for npm run scripts

## How to Generate SDKs

Run `npm ci` to install dependencies, then `npm run generate` to build SDKs in the `dist/` folder

## How to Unit Test SDKs

After generating SDKs, follow the testing instructions in the `README.md` of every SDK in `dist/`
