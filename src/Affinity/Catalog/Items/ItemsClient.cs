using Affinity;
using Affinity.Core;
using global::System.Text.Json;

namespace Affinity.Catalog;

public partial class ItemsClient : IItemsClient
{
    private readonly RawClient _client;

    internal ItemsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<ListCatalogItemsResponse>> ListAsyncCore(
        ListItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Affinity.Core.QueryStringBuilder.Builder(capacity: 18)
            .Add("view", request.View)
            .Add("relatedToCatalogItemId", request.RelatedToCatalogItemId)
            .Add("catalogKind", request.CatalogKind)
            .Add("sort", request.Sort)
            .Add("catalogItemId", request.CatalogItemId)
            .Add("availability", request.Availability)
            .AddDeepObject("pharmacyIds", request.PharmacyIds)
            .AddDeepObject("dosageForms", request.DosageForms)
            .Add("endingBefore", request.EndingBefore)
            .Add("hideControlledSubstances", request.HideControlledSubstances)
            .Add("hideUnpriced", request.HideUnpriced)
            .Add("limit", request.Limit)
            .Add("orgId", request.OrgId)
            .Add("practiceId", request.PracticeId)
            .Add("query", request.Query)
            .Add("requirement", request.Requirement)
            .AddDeepObject("routes", request.Routes)
            .Add("startingAfter", request.StartingAfter)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Affinity.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1/catalog/items",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ListCatalogItemsResponse>(responseBody)!;
                return new WithRawResponse<ListCatalogItemsResponse>()
                {
                    Data = responseData,
                    RawResponse = new Affinity.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new AffinityClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Affinity.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<Problem>(responseBody),
                            rawResponse: new Affinity.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<Problem>(responseBody),
                            rawResponse: new Affinity.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<Problem>(responseBody),
                            rawResponse: new Affinity.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<Problem>(responseBody),
                            rawResponse: new Affinity.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 409:
                        throw new ConflictError(
                            JsonUtils.Deserialize<Problem>(responseBody),
                            rawResponse: new Affinity.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<Problem>(responseBody),
                            rawResponse: new Affinity.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<Problem>(responseBody),
                            rawResponse: new Affinity.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new AffinityClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Affinity.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// Lists catalog items for the authenticated account and mode. Use view=medications for priced prescription groups with offer counts, pharmacy counts, and strengths; the default view=offers returns individual offers. Use relatedToCatalogItemId to find offers for the same medication and route. When practiceId is supplied, a practice price overrides the platform price and missing overrides inherit the platform price.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.Items.ListAsync(
    ///     new ListItemsRequest
    ///     {
    ///         RelatedToCatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
    ///         CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
    ///         PharmacyIds = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
    ///         EndingBefore = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
    ///         OrgId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
    ///         PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
    ///         StartingAfter = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ListCatalogItemsResponse> ListAsync(
        ListItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListCatalogItemsResponse>(
            ListAsyncCore(request, options, cancellationToken)
        );
    }
}
