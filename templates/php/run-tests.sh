#!/bin/bash

# Requires PHP and PHPUnit

./vendor/bin/phpunit \
    --coverage-clover clover.xml --coverage-text --coverage-html=coverage/ \
    --log-junit test-reports/junit.xml
tests_status=$?

php -r "$(cat << END
  \$clover = simplexml_load_file('./clover.xml');
  \$statements = \$clover->project->metrics['statements'];
  \$coveredStatements = \$clover->project->metrics['coveredstatements'];
  if ((\$coveredStatements / \$statements) < 1) exit(1);
END
)"
coverage_status=$?

exit $(($tests_status || $coverage_status))
