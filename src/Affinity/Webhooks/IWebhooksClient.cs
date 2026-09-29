namespace Affinity.Webhooks;

public partial interface IWebhooksClient
{
    public IEndpointsClient Endpoints { get; }
    public IEventsClient Events { get; }
    public IGrantsClient Grants { get; }
}
