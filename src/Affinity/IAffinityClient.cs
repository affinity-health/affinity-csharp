using Affinity.Catalog;
using Affinity.Webhooks;

namespace Affinity;

public partial interface IAffinityClient
{
    public ILocationsClient Locations { get; }
    public IApiKeysClient ApiKeys { get; }
    public IAccountClient Account { get; }
    public IPharmaciesClient Pharmacies { get; }
    public IOrdersClient Orders { get; }
    public ITeamClient Team { get; }
    public IPracticesClient Practices { get; }
    public IPatientsClient Patients { get; }
    public ICatalogClient Catalog { get; }
    public IWebhooksClient Webhooks { get; }
}
