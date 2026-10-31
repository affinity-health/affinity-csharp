namespace Affinity;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ContentTooLargeError(object body, Affinity.RawResponse? rawResponse = null)
    : AffinityClientApiException("ContentTooLargeError", 413, body, rawResponse: rawResponse);
