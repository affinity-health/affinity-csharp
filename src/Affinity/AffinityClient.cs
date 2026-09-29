using Affinity.Core;

namespace Affinity;

public partial class AffinityClient : IAffinityClient
{
    private readonly RawClient _client;

    public AffinityClient(
        string? apiKey = null,
        string? affinityVersion = null,
        ClientOptions? clientOptions = null
    )
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Affinity" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "x-affinity-api-key", apiKey ?? "" },
                { "Affinity-Version", affinityVersion ?? "" },
            }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Locations = new LocationsClient(_client);
        ApiKeys = new ApiKeysClient(_client);
        Account = new AccountClient(_client);
        Catalog = new CatalogClient(_client);
        Orders = new OrdersClient(_client);
        Webhooks = new WebhooksClient(_client);
        Team = new TeamClient(_client);
        Patients = new PatientsClient(_client);
        Practices = new PracticesClient(_client);
        PlatformPricing = new PlatformPricingClient(_client);
    }

    public ILocationsClient Locations { get; }

    public IApiKeysClient ApiKeys { get; }

    public IAccountClient Account { get; }

    public ICatalogClient Catalog { get; }

    public IOrdersClient Orders { get; }

    public IWebhooksClient Webhooks { get; }

    public ITeamClient Team { get; }

    public IPatientsClient Patients { get; }

    public IPracticesClient Practices { get; }

    public IPlatformPricingClient PlatformPricing { get; }
}
