namespace Affinity;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class AffinityClientException(string message, Exception? innerException = null)
    : Exception(message, innerException);
