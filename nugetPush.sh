# !/bin/bash

rm -r src/Library/bin/Release/*.nupkg

dotnet build src/Library/Library.csproj -c Release

dotnet pack src/Library/Library.csproj -c Release

dotnet nuget push src/Library/bin/Release/*.nupkg --source https://api.nuget.org/v3/index.json --api-key $1