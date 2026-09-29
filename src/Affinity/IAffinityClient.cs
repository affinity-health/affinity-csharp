namespace Affinity;

public partial interface IAffinityClient
{
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
