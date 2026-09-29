using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Catalog;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPharmaciesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "access": "invited",
                  "catalogItemCount": 1,
                  "facilityType": "facilityType",
                  "facilityLocations": [
                    {
                      "city": "city",
                      "country": "country",
                      "name": "name",
                      "state": "state"
                    },
                    {
                      "city": "city",
                      "country": "country",
                      "name": "name",
                      "state": "state"
                    }
                  ],
                  "id": "id",
                  "livemode": true,
                  "logoUrl": "logoUrl",
                  "name": "name",
                  "object": "pharmacy",
                  "prescriptionsLast30Days": 1,
                  "profile": {
                    "description": "description",
                    "effectiveAt": "effectiveAt",
                    "monthlyPrescriptionVolume": 1,
                    "rating": "Infinity",
                    "ratingBasis": "ratingBasis",
                    "ratingReviewCount": 1,
                    "recommendedRank": 1
                  },
                  "restrictedStates": [
                    "restrictedStates",
                    "restrictedStates"
                  ],
                  "shippingOptions": [
                    {
                      "amountCents": 1,
                      "carrier": "carrier",
                      "currency": "USD",
                      "destinationTypes": [
                        "patient",
                        "patient"
                      ],
                      "estimatedDaysMax": 1,
                      "estimatedDaysMin": 1,
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient",
                        "ambient"
                      ]
                    },
                    {
                      "amountCents": 1,
                      "carrier": "carrier",
                      "currency": "USD",
                      "destinationTypes": [
                        "patient",
                        "patient"
                      ],
                      "estimatedDaysMax": 1,
                      "estimatedDaysMin": 1,
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient",
                        "ambient"
                      ]
                    }
                  ],
                  "supportedStates": [
                    "supportedStates",
                    "supportedStates"
                  ]
                },
                {
                  "access": "invited",
                  "catalogItemCount": 1,
                  "facilityType": "facilityType",
                  "facilityLocations": [
                    {
                      "city": "city",
                      "country": "country",
                      "name": "name",
                      "state": "state"
                    },
                    {
                      "city": "city",
                      "country": "country",
                      "name": "name",
                      "state": "state"
                    }
                  ],
                  "id": "id",
                  "livemode": true,
                  "logoUrl": "logoUrl",
                  "name": "name",
                  "object": "pharmacy",
                  "prescriptionsLast30Days": 1,
                  "profile": {
                    "description": "description",
                    "effectiveAt": "effectiveAt",
                    "monthlyPrescriptionVolume": 1,
                    "rating": "Infinity",
                    "ratingBasis": "ratingBasis",
                    "ratingReviewCount": 1,
                    "recommendedRank": 1
                  },
                  "restrictedStates": [
                    "restrictedStates",
                    "restrictedStates"
                  ],
                  "shippingOptions": [
                    {
                      "amountCents": 1,
                      "carrier": "carrier",
                      "currency": "USD",
                      "destinationTypes": [
                        "patient",
                        "patient"
                      ],
                      "estimatedDaysMax": 1,
                      "estimatedDaysMin": 1,
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient",
                        "ambient"
                      ]
                    },
                    {
                      "amountCents": 1,
                      "carrier": "carrier",
                      "currency": "USD",
                      "destinationTypes": [
                        "patient",
                        "patient"
                      ],
                      "estimatedDaysMax": 1,
                      "estimatedDaysMin": 1,
                      "id": "id",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient",
                        "ambient"
                      ]
                    }
                  ],
                  "supportedStates": [
                    "supportedStates",
                    "supportedStates"
                  ]
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/pharmacies"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/pharmacies").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.ListPharmaciesAsync(new ListPharmaciesRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "access": "invited",
                  "catalogItemCount": 1,
                  "facilityType": "facilityType",
                  "facilityLocations": [
                    {
                      "name": "name"
                    }
                  ],
                  "id": "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
                  "livemode": true,
                  "logoUrl": "logoUrl",
                  "name": "name",
                  "object": "pharmacy",
                  "prescriptionsLast30Days": 1,
                  "profile": {
                    "description": "description",
                    "effectiveAt": "effectiveAt"
                  },
                  "restrictedStates": [
                    "restrictedStates"
                  ],
                  "shippingOptions": [
                    {
                      "amountCents": 1,
                      "currency": "USD",
                      "destinationTypes": [
                        "patient"
                      ],
                      "id": "shp_01j2y8m6jcc9tt24af5pw9x1bc",
                      "label": "label",
                      "serviceLevel": "serviceLevel",
                      "temperatures": [
                        "ambient"
                      ]
                    }
                  ],
                  "supportedStates": [
                    "supportedStates"
                  ]
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/pharmacies"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/pharmacies")
                    .WithParam("endingBefore", "pharm_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("orgId", "acct_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("pharmacyId", "pharm_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("startingAfter", "pharm_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Catalog.ListPharmaciesAsync(
            new ListPharmaciesRequest
            {
                EndingBefore = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
                OrgId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
                PharmacyId = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
