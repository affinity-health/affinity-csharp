namespace Affinity;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(Problem body, Affinity.RawResponse? rawResponse = null)
    : AffinityClientApiException("BadRequestError", 400, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Problem Body => body;
}
