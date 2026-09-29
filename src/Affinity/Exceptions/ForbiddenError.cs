namespace Affinity;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(Problem body, Affinity.RawResponse? rawResponse = null)
    : AffinityClientApiException("ForbiddenError", 403, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Problem Body => body;
}
