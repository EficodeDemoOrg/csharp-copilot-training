#!/bin/bash
# validate-bicep.sh - Script to validate Bicep infrastructure files
# This script validates all .bicep files in the current directory

set -e  # Exit immediately if a command exits with a non-zero status

echo -e "\e[32mValidating Bicep files in the infrastructure directory...\e[0m"

# Get all .bicep files in the current directory
bicep_files=(*.bicep)

# Check if any Bicep files were found
if [ ${#bicep_files[@]} -eq 0 ] || [ ! -f "${bicep_files[0]}" ]; then
    echo -e "\e[33mNo Bicep files found in the current directory.\e[0m"
    exit 0
fi

error_count=0
valid_count=0

# Loop through each Bicep file and validate it
for file in "${bicep_files[@]}"; do
    # Skip if not a valid file (in case the wildcard didn't match)
    if [ ! -f "$file" ]; then
        continue
    fi
    
    echo -e "\e[36mValidating $file...\e[0m"
    
    # Use the Az CLI to validate the Bicep file
    if az bicep build --file "$file" 2>/dev/null; then
        # If we reach here, the file is valid
        echo -e "\e[32m✓ $file is valid.\e[0m"
        ((valid_count++))
    else
        # If there was an error, report it
        echo -e "\e[31m✗ $file has validation errors.\e[0m"
        az bicep build --file "$file" 2>&1 | grep -v "^$" | sed 's/^/    /'
        ((error_count++))
    fi
    
    echo "" # Empty line for better readability
done

# Output summary
echo -e "\e[32mValidation complete!\e[0m"
echo -e "\e[33mSummary:\e[0m"
echo -e "\e[33m- Total Bicep files: ${#bicep_files[@]}\e[0m"
echo -e "\e[32m- Valid files: $valid_count\e[0m"
if [ $error_count -gt 0 ]; then
    echo -e "\e[31m- Files with errors: $error_count\e[0m"
else
    echo -e "\e[32m- Files with errors: $error_count\e[0m"
fi

# Return non-zero exit code if any files had errors
if [ $error_count -gt 0 ]; then
    echo -e "\e[31mValidation failed with $error_count errors.\e[0m"
    exit 1
else
    echo -e "\e[32mAll Bicep files are valid!\e[0m"
    exit 0
fi