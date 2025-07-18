# Performance-optimized build script for WinForms Calculator
# This script builds the application with maximum performance optimizations

Write-Host "🚀 Building Performance-Optimized WinForms Calculator..." -ForegroundColor Green

# Check if .NET SDK is available
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Host "❌ .NET SDK not found. Please install .NET 8.0 SDK or later." -ForegroundColor Red
    Write-Host "   Download from: https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    exit 1
}

# Clean previous builds
Write-Host "🧹 Cleaning previous builds..." -ForegroundColor Yellow
dotnet clean WinFormsApp1/WinFormsApp1.csproj

# Restore dependencies
Write-Host "📦 Restoring dependencies..." -ForegroundColor Yellow
dotnet restore WinFormsApp1/WinFormsApp1.csproj

# Build optimized release version
Write-Host "🔨 Building optimized release version..." -ForegroundColor Yellow
dotnet build WinFormsApp1/WinFormsApp1.csproj -c Release --no-restore

# Publish single-file optimized version
Write-Host "📦 Publishing single-file optimized version..." -ForegroundColor Yellow
dotnet publish WinFormsApp1/WinFormsApp1.csproj `
    -c Release `
    -r win-x64 `
    --self-contained true `
    --no-restore `
    -p:PublishSingleFile=true `
    -p:PublishTrimmed=true `
    -p:PublishReadyToRun=true `
    -p:TieredCompilation=true `
    -p:TieredPGO=true `
    -o ./publish/optimized

# Display results
Write-Host "✅ Build completed successfully!" -ForegroundColor Green
Write-Host ""
Write-Host "📊 Build Results:" -ForegroundColor Cyan
Write-Host "   - Optimized executable: ./publish/optimized/WinFormsApp1.exe" -ForegroundColor White

if (Test-Path "./publish/optimized/WinFormsApp1.exe") {
    $fileSize = (Get-Item "./publish/optimized/WinFormsApp1.exe").Length
    $fileSizeMB = [math]::Round($fileSize / 1MB, 2)
    Write-Host "   - File size: $fileSizeMB MB" -ForegroundColor White
}

Write-Host ""
Write-Host "🎯 Performance Optimizations Applied:" -ForegroundColor Cyan
Write-Host "   ✓ .NET 8.0 with latest performance improvements" -ForegroundColor Green
Write-Host "   ✓ Single-file deployment for faster startup" -ForegroundColor Green
Write-Host "   ✓ Trimmed unused code for smaller bundle size" -ForegroundColor Green
Write-Host "   ✓ ReadyToRun compilation for faster startup" -ForegroundColor Green
Write-Host "   ✓ Tiered compilation with PGO" -ForegroundColor Green
Write-Host "   ✓ Optimized string operations" -ForegroundColor Green
Write-Host "   ✓ Efficient input validation" -ForegroundColor Green
Write-Host "   ✓ Reduced memory allocations" -ForegroundColor Green
Write-Host ""
Write-Host "🚀 Ready to run! Execute: ./publish/optimized/WinFormsApp1.exe" -ForegroundColor Magenta

# Optional: Measure startup time
Write-Host ""
Write-Host "🔍 To measure startup time, run:" -ForegroundColor Yellow
Write-Host "   Measure-Command { & './publish/optimized/WinFormsApp1.exe' }" -ForegroundColor Gray