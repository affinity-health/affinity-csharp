using Affinity;
using Affinity.Core;
using global::System.Text.Json;

namespace Affinity.Orders;

public partial class BatchesClient : IBatchesClient
{
    private readonly RawClient _client;

    internal BatchesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CreateOrderBatchResponse>> CreateAsyncCore(
        CreateOrderBatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Affinity.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Affinity.Core.HeadersBuilder.Builder()
            .Add("Idempotency-Key", request.IdempotencyKey)
            .Add("Affinity-Actor-Id", request.AffinityActorId)
            .Add("Affinity-Actor-Type", request.AffinityActorType)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1/order-batches",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
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
                var responseData = JsonUtils.Deserialize<CreateOrderBatchResponse>(responseBody)!;
                return new WithRawResponse<CreateOrderBatchResponse>()
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
                    case 503:
                        throw new ServiceUnavailableError(
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
    /// Creates 1–20 orders for distinct patients in one practice, each with 1–20 prescriptions. Each accepts patientId or inline patient details. Orders and newly created patients commit atomically; any failure saves none. Requires orders:write and Idempotency-Key; inline patients also require patients:write. Omitted actor context defaults to the authenticated service account as a system actor. Sign and submit each resulting order separately using orders:sign.
    /// </summary>
    /// <example><code>
    /// await client.Orders.Batches.CreateAsync(
    ///     new CreateOrderBatchRequest
    ///     {
    ///         IdempotencyKey = "Idempotency-Key",
    ///         PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
    ///         Orders = new List&lt;CreateOrderBatchRequestOrdersItem&gt;()
    ///         {
    ///             new CreateOrderBatchRequestOrdersItem
    ///             {
    ///                 Prescriptions = new List&lt;CreateOrderBatchRequestOrdersItemPrescriptionsItem&gt;()
    ///                 {
    ///                     new CreateOrderBatchRequestOrdersItemPrescriptionsItem
    ///                     {
    ///                         DaysSupply = 1,
    ///                         Dispensing =
    ///                             new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensing(),
    ///                         Directions = "directions",
    ///                         MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
    ///                         Quantity =
    ///                             CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne.Infinity,
    ///                         QuantityUnit = "quantityUnit",
    ///                         Refills = 1,
    ///                     },
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateOrderBatchResponse> CreateAsync(
        CreateOrderBatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateOrderBatchResponse>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }
}
