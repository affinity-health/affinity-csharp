using OneOf;

namespace Affinity;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ServiceUnavailableError(
    OneOf<Problem, ServiceUnavailableErrorBodyCode> body,
    Affinity.RawResponse? rawResponse = null
) : AffinityClientApiException("ServiceUnavailableError", 503, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new OneOf<Problem, ServiceUnavailableErrorBodyCode> Body => body;
}
