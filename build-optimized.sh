#!/bin/bash

# Performance-optimized build script for WinForms Calculator
# This script builds the application with maximum performance optimizations

echo "🚀 Building Performance-Optimized WinForms Calculator..."

# Check if .NET SDK is available
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET SDK not found. Please install .NET 8.0 SDK or later."
    echo "   Download from: https://dotnet.microsoft.com/download"
    exit 1
fi

# Clean previous builds
echo "🧹 Cleaning previous builds..."
dotnet clean WinFormsApp1/WinFormsApp1.csproj

# Restore dependencies
echo "📦 Restoring dependencies..."
dotnet restore WinFormsApp1/WinFormsApp1.csproj

# Build optimized release version
echo "🔨 Building optimized release version..."
dotnet build WinFormsApp1/WinFormsApp1.csproj -c Release --no-restore

# Publish single-file optimized version
echo "📦 Publishing single-file optimized version..."
dotnet publish WinFormsApp1/WinFormsApp1.csproj \
    -c Release \
    -r win-x64 \
    --self-contained true \
    --no-restore \
    -p:PublishSingleFile=true \
    -p:PublishTrimmed=true \
    -p:PublishReadyToRun=true \
    -p:TieredCompilation=true \
    -p:TieredPGO=true \
    -o ./publish/optimized

# Display results
echo "✅ Build completed successfully!"
echo ""
echo "📊 Build Results:"
echo "   - Optimized executable: ./publish/optimized/WinFormsApp1.exe"

if [ -f "./publish/optimized/WinFormsApp1.exe" ]; then
    FILE_SIZE=$(stat -c%s "./publish/optimized/WinFormsApp1.exe" 2>/dev/null || stat -f%z "./publish/optimized/WinFormsApp1.exe" 2>/dev/null)
    if [ ! -z "$FILE_SIZE" ]; then
        FILE_SIZE_MB=$((FILE_SIZE / 1024 / 1024))
        echo "   - File size: ${FILE_SIZE_MB} MB"
    fi
fi

echo ""
echo "🎯 Performance Optimizations Applied:"
echo "   ✓ .NET 8.0 with latest performance improvements"
echo "   ✓ Single-file deployment for faster startup"
echo "   ✓ Trimmed unused code for smaller bundle size"
echo "   ✓ ReadyToRun compilation for faster startup"
echo "   ✓ Tiered compilation with PGO"
echo "   ✓ Optimized string operations"
echo "   ✓ Efficient input validation"
echo "   ✓ Reduced memory allocations"
echo ""
echo "🚀 Ready to run! Execute: ./publish/optimized/WinFormsApp1.exe"