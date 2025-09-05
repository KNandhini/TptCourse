# Go to your solution root
Set-Location "C:\Users\LORE TECHNOLOGY\source\repos\TPTCOARSEAPI"

# Define replacements
$map = @{
    "RestaurantManagement.Api"            = "TptCoarse.Api"
    "RestaurantManagement.Application"    = "TptCoarse.Application"
    "RestaurantManagement.Domain"         = "TptCoarse.Domain"
    "RestaurantManagement.Infrastructure" = "TptCoarse.Infrastructure"
}

# Files to update (.sln and .csproj)
$files = Get-ChildItem -Recurse -Include *.sln,*.csproj

foreach ($file in $files) {
    Write-Host "Updating $($file.FullName)" -ForegroundColor Yellow
    $content = Get-Content $file.FullName

    foreach ($old in $map.Keys) {
        $new = $map[$old]
        $content = $content -replace [Regex]::Escape($old), $new
    }

    Set-Content $file.FullName $content
}

Write-Host "✅ All .sln and .csproj references updated!" -ForegroundColor Green
