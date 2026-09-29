#!/bin/sh
set -eu
cp -R /source /tmp/sdk
cd /tmp/sdk
dotnet pack src/Affinity/Affinity.csproj -o /tmp/packages
mkdir -p smoke
cp /tests/csharp_smoke.cs smoke/Program.cs
printf '%s\n' '<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net9.0</TargetFramework><ImplicitUsings>enable</ImplicitUsings></PropertyGroup><ItemGroup><ProjectReference Include="../src/Affinity/Affinity.csproj" /></ItemGroup></Project>' > smoke/smoke.csproj
dotnet run --project smoke/smoke.csproj
