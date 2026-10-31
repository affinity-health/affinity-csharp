namespace Affinity;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnsupportedMediaTypeError(object body, Affinity.RawResponse? rawResponse = null)
    : AffinityClientApiException("UnsupportedMediaTypeError", 415, body, rawResponse: rawResponse);
