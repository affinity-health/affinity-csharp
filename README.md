# Affinity C# SDK

Generated client for the Affinity API, version `2026-09-28`. This is a source preview
at `0.1.0`; the generated interface may change before a stable release.

## Install and use

Requires the .NET 9 SDK to build. The library targets .NET Framework 4.6.2, .NET Standard 2.0, .NET 8, and .NET 9.

```sh
git clone https://github.com/affinity-health/affinity-csharp.git
dotnet add YourApp.csproj reference affinity-csharp/src/Affinity/Affinity.csproj
```

```csharp
using Affinity;

var client = new AffinityClient(
    apiKey: Environment.GetEnvironmentVariable("AFFINITY_API_KEY"),
    affinityVersion: "2026-09-28",
    clientOptions: new ClientOptions { MaxRetries = 0 });
var page = await client.Orders.ListOrdersAsync(new ListOrdersRequest { Limit = 20 });
```

For a local NuGet package, run `dotnet pack src/Affinity/Affinity.csproj -o ./packages`.
`Affinity.Health.Sdk` is a local package name; it is not published on NuGet.

Use a server-side API key from `AFFINITY_API_KEY`. Never embed keys in a browser or
shipped application. The default base URL is `https://api.joinaffinityai.com`.
These examples disable automatic retries. Reuse the same idempotency key when
retrying a write that requires one. List responses expose data and cursor metadata;
pass the next cursor explicitly when fetching more records.

See [the generated reference](reference.md) for resource methods and types and
[Affinity documentation](https://docs.joinaffinityai.com) for API behavior.
Generated reference examples may assume registry publication; use the installation
instructions above while this SDK is available only from GitHub.

## Development

With Docker installed:

```sh
./scripts/check.sh
```

This builds/packages the SDK locally and checks synthetic HTTP requests, authentication,
API version headers, pagination parameters, response decoding, and failed writes.
It does not call the hosted API or publish a package.

The committed [OpenAPI contract](spec/affinity.openapi.json) is the source of truth.
[generation.json](generation.json) records the pinned Cloudflare Forge and Fern
versions and source hash. Generation is maintained in Affinity's SDK pipeline.
Do not edit generated models directly.
