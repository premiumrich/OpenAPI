const fs = require('fs');
const path = require('path');
const yaml = require('js-yaml');
const merge = require('merge-deep');
const mustache = require('mustache');
const beautify = require('js-beautify');

/**
 * Usage: node generate-sample-app.js <config-file> <output-folder>
 */

const langConfig = yaml.load(fs.readFileSync(process.argv[2]));
const commonConfig = yaml.load(fs.readFileSync(path.join(path.dirname(process.argv[2]), langConfig['!include'])));
const mergedConfig = merge(commonConfig, langConfig);
mergedConfig.sampleApp.idvSteps = Object.values(mergedConfig.sampleApp.idvSteps);

const indexTemplate = fs.readFileSync(mergedConfig.sampleApp.indexTemplateFile).toString();

const indexRendered = mustache.render(indexTemplate, mergedConfig);

const indexFormatted = beautify.html_beautify(indexRendered, {
  indent_size: 2,
  wrap_line_length: 120,
  end_with_newline: true,
  content_unformatted: [],
});

fs.writeFileSync(path.join(process.argv[3], 'index.html'), indexFormatted);
