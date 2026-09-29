#!/bin/sh
set -eu
cd "$(dirname "$0")/.."
./tests/with-fixtures.sh docker run --rm --network host -v "$PWD:/source:ro" -v "$PWD/tests:/tests:ro" mcr.microsoft.com/dotnet/sdk:9.0 sh /tests/verify-csharp.sh
