# validate-bicep.ps1 - Script to validate Bicep infrastructure files
# This script validates all .bicep files in the current directory

# Set the error action preference to stop on any error
$ErrorActionPreference = "Stop"

Write-Host "Validating Bicep files in the infrastructure directory..." -ForegroundColor Green

# Get all .bicep files in the current directory
$bicepFiles = Get-ChildItem -Path . -Filter "*.bicep"

# Check if any Bicep files were found
if ($bicepFiles.Count -eq 0) {
    Write-Host "No Bicep files found in the current directory." -ForegroundColor Yellow
    exit 0
}

$errorCount = 0
$validCount = 0

# Loop through each Bicep file and validate it
foreach ($file in $bicepFiles) {
    Write-Host "Validating $($file.Name)..." -ForegroundColor Cyan
    
    # Use the Az CLI to validate the Bicep file
    try {
        # Build the Bicep file to validate its syntax
        $result = az bicep build --file $file.FullName 2>&1
        
        # If we reach here, the file is valid
        Write-Host "✓ $($file.Name) is valid." -ForegroundColor Green
        $validCount++
    }
    catch {
        # If there was an error, report it
        Write-Host "✗ $($file.Name) has validation errors:" -ForegroundColor Red
        Write-Host $_ -ForegroundColor Red
        $errorCount++
    }
    
    Write-Host "" # Empty line for better readability
}

# Output summary
Write-Host "Validation complete!" -ForegroundColor Green
Write-Host "Summary:" -ForegroundColor Yellow
Write-Host "- Total Bicep files: $($bicepFiles.Count)" -ForegroundColor Yellow
Write-Host "- Valid files: $validCount" -ForegroundColor Green
Write-Host "- Files with errors: $errorCount" -ForegroundColor $(if ($errorCount -gt 0) { "Red" } else { "Green" })

# Return non-zero exit code if any files had errors
if ($errorCount -gt 0) {
    Write-Host "Validation failed with $errorCount errors." -ForegroundColor Red
    exit 1
}
else {
    Write-Host "All Bicep files are valid!" -ForegroundColor Green
    exit 0
}