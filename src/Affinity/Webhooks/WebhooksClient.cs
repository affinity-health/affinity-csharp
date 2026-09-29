using Affinity.Core;

namespace Affinity.Webhooks;

public partial class WebhooksClient : IWebhooksClient
{
    private readonly RawClient _client;

    internal WebhooksClient(RawClient client)
    {
        _client = client;
        Endpoints = new EndpointsClient(_client);
        Events = new EventsClient(_client);
        Grants = new GrantsClient(_client);
    }

    public IEndpointsClient Endpoints { get; }

    public IEventsClient Events { get; }

    public IGrantsClient Grants { get; }
}
