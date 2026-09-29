#!/bin/sh
set -eu
cd "$(dirname "$0")/.."
docker run --rm -v "$PWD:/source:ro" -v "$PWD/tests:/tests:ro" mcr.microsoft.com/dotnet/sdk:9.0 sh /tests/verify-csharp.sh
