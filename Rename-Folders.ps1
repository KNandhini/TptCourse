# Go to your solution root folder
Set-Location "C:\Users\LORE TECHNOLOGY\source\repos\TPTCOARSEAPI"

Write-Host "Current folders in solution root:" -ForegroundColor Cyan
Get-ChildItem -Directory | ForEach-Object { Write-Host " - $($_.Name)" }

# Mapping of old folder names -> new folder names
$folders = @{
    "RestaurantManagement.Api"            = "TptCoarse.Api"
    "RestaurantManagement.Application"    = "TptCoarse.Application"
    "RestaurantManagement.Domain"         = "TptCoarse.Domain"
    "RestaurantManagement.Infrastructure" = "TptCoarse.Infrastructure"
}

Write-Host "`nStarting folder renaming..." -ForegroundColor Yellow

foreach ($old in $folders.Keys) {
    $new = $folders[$old]
    if (Test-Path $old) {
        Write-Host "Renaming $old -> $new" -ForegroundColor Green
        Rename-Item -Path $old -NewName $new
    } else {
        Write-Host "Folder $old not found, skipping..." -ForegroundColor Red
    }
}

Write-Host "`nDone! Updated folders:" -ForegroundColor Cyan
Get-ChildItem -Directory | ForEach-Object { Write-Host " - $($_.Name)" }
