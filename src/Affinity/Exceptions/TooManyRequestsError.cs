namespace Affinity;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class TooManyRequestsError(Problem429 body, Affinity.RawResponse? rawResponse = null)
    : AffinityClientApiException("TooManyRequestsError", 429, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Problem429 Body => body;
}
