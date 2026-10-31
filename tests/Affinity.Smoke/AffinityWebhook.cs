// Written by hand. The same code is in README.md ("Verify webhooks"); keep them identical.
using System.Security.Cryptography;
using System.Text;

public static class AffinityWebhook
{
    /// <summary>
    /// Returns true when the Affinity-Signature header (t=unix,v1=hex[,v1=hex]) signs rawBody with
    /// secret (whsec_...) and t is within 300 seconds of now.
    /// </summary>
    public static bool Verify(string? signatureHeader, byte[] rawBody, string secret, DateTimeOffset? now = null)
    {
        if (string.IsNullOrEmpty(signatureHeader)) return false;
        long? timestamp = null;
        var signatures = new List<string>();
        foreach (var part in signatureHeader.Split(','))
        {
            var pair = part.Trim().Split(new[] { '=' }, 2);
            if (pair.Length != 2) continue;
            if (pair[0] == "t" && long.TryParse(pair[1], out var t)) timestamp = t;
            else if (pair[0] == "v1") signatures.Add(pair[1]);
        }
        if (timestamp is null || signatures.Count == 0) return false;
        var current = (now ?? DateTimeOffset.UtcNow).ToUnixTimeSeconds();
        if (Math.Abs(current - timestamp.Value) > 300) return false;

        var prefix = Encoding.UTF8.GetBytes(timestamp.Value + ".");
        var signed = new byte[prefix.Length + rawBody.Length];
        prefix.CopyTo(signed, 0);
        rawBody.CopyTo(signed, prefix.Length);
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var expected = Encoding.ASCII.GetBytes(
            BitConverter.ToString(hmac.ComputeHash(signed)).Replace("-", "").ToLowerInvariant());
        foreach (var signature in signatures)
        {
            var actual = Encoding.ASCII.GetBytes(signature);
            if (CryptographicOperations.FixedTimeEquals(actual, expected)) return true;
        }
        return false;
    }
}
