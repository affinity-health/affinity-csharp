using Affinity.Core;

namespace Affinity;

public partial class AffinityClient : IAffinityClient
{
    private readonly RawClient _client;

    public AffinityClient(string? token = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Affinity" },
                { "X-Fern-SDK-Version", global::Affinity.Version.Current },
            }
        );
        if (clientOptions.AffinityVersion != null)
        {
            platformHeaders["Affinity-Version"] = clientOptions.AffinityVersion;
        }
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
                { "Authorization", $"Bearer {token ?? ""}" },
                { "Affinity-Version", "2026-10-28" },
            }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Account = new AccountClient(_client);
        Feedback = new FeedbackClient(_client);
        Medications = new MedicationsClient(_client);
        Orders = new OrdersClient(_client);
        Practices = new PracticesClient(_client);
        Webhooks = new WebhooksClient(_client);
    }

    public IAccountClient Account { get; }

    public IFeedbackClient Feedback { get; }

    public IMedicationsClient Medications { get; }

    public IOrdersClient Orders { get; }

    public IPracticesClient Practices { get; }

    public IWebhooksClient Webhooks { get; }
}
