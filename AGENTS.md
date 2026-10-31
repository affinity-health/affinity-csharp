# Affinity C# SDK agent guide

This repository contains the official C#/.NET SDK for the Affinity public API. NuGet package id and
root namespace: `Affinity`. Client class: `AffinityClient`.

## Source of truth

- `spec/affinity.openapi.json` is the Affinity API contract, copied unchanged from the matching
  committed snapshot. Do not edit it here; change the API upstream and copy the new snapshot.
- Fern generates the code from the spec. `fern/generators.yml` pins the generator and its config;
  `fern/fern.config.json` pins the Fern CLI. `scripts/generate.sh` adds method names and pagination
  with `scripts/prepare-spec.jq`, runs Fern in Docker, and sets the package version.
- Never hand-edit generated files: `src/Affinity/**`, `src/Affinity.Test/**`, `Affinity.slnx`,
  `.editorconfig`, `docs/reference.md` and `generation.json`. Fix the config or `scripts/generate.sh`
  and regenerate.

## Hand-written files

- `src/Affinity/Affinity.Custom.props` and `src/Affinity.Test/Affinity.Test.Custom.props`: build
  targets for the .NET 8 SDK (Fern also targets net9.0). `scripts/generate.sh` keeps them.
- `tests/Affinity.Smoke/`: the staging smoke test and `AffinityWebhook.cs`, the webhook verifier
  that README.md shows. Keep the README copy identical.
- `scripts/`, `fern/`, `.github/workflows/ci.yml`, `.gitignore`, README.md, CHANGELOG.md,
  CONTRIBUTING.md, SECURITY.md, LICENSE and this file.

## Regenerate and verify

```sh
scripts/generate.sh         # needs Docker, Node and jq
scripts/generate-check.sh   # fails if the generated files differ
docker run --rm -v "$PWD":/src -w /src mcr.microsoft.com/dotnet/sdk:8.0 sh -c '
  dotnet build src/Affinity/Affinity.csproj -c Release &&
  dotnet test src/Affinity.Test/Affinity.Test.csproj &&
  dotnet run --project tests/Affinity.Smoke -- webhook'
docker run --rm --env-file <smoke.env> -v "$PWD":/src -w /src mcr.microsoft.com/dotnet/sdk:8.0 \
  dotnet run --project tests/Affinity.Smoke
```

The package version is in `scripts/generate.sh` (`version=`); change it there and in CHANGELOG.md.

## Rules

- Do not publish to NuGet or any registry without explicit authorization.
- Use Test keys (`sk_test_`) only. Never call production with the smoke test. Never print, log or
  commit API keys.
- Keep examples synthetic. No real patient data.
- The SDK is for trusted servers. Never encourage API keys in browser, desktop or mobile code.
- A provider is a clinician or prescriber; a practice is the customer organization and API tenant.
  Do not introduce a `clinic` resource.
