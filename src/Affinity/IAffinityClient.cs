namespace Affinity;

public partial interface IAffinityClient
{
    public IAccountClient Account { get; }
    public IFeedbackClient Feedback { get; }
    public IMedicationsClient Medications { get; }
    public IOrdersClient Orders { get; }
    public IPracticesClient Practices { get; }
    public IWebhooksClient Webhooks { get; }
}
