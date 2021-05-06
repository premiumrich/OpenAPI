#!/bin/dash

# Usage: ./post-process-ruby.sh <inputfile>

# Replace every CGI.escape(...) with CGI.escape(...).gsub('+', '%20') to fix URL encoding
sed -i -r "s/(CGI\.escape\([^)]+\))/\1.gsub('+', '%20')/g" "$1"
