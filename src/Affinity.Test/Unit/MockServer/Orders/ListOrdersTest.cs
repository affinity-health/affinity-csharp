using Affinity;
using Affinity.Test.Unit.MockServer;
using Affinity.Test.Utils;
using NUnit.Framework;

namespace Affinity.Test.Unit.MockServer.Orders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListOrdersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "revision": "revision",
                  "otcItems": [
                    {
                      "catalogItemId": "catalogItemId",
                      "prescriptionId": "prescriptionId",
                      "name": "name",
                      "quantity": 1,
                      "unitPriceCents": 1,
                      "subtotalCents": 1
                    },
                    {
                      "catalogItemId": "catalogItemId",
                      "prescriptionId": "prescriptionId",
                      "name": "name",
                      "quantity": 1,
                      "unitPriceCents": 1,
                      "subtotalCents": 1
                    }
                  ],
                  "practiceMedicationTotalCents": 1,
                  "externalOrderId": "externalOrderId",
                  "metadata": {},
                  "createdAt": "createdAt",
                  "fulfillments": [
                    {
                      "carrier": "carrier",
                      "cancellations": [
                        {
                          "attempts": 1,
                          "confirmedAt": "confirmedAt",
                          "createdAt": "createdAt",
                          "errorCode": "errorCode",
                          "errorMessage": "errorMessage",
                          "id": "id",
                          "providerStatus": "providerStatus",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "resolvedAt": "resolvedAt",
                          "sentAt": "sentAt",
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        },
                        {
                          "attempts": 1,
                          "confirmedAt": "confirmedAt",
                          "createdAt": "createdAt",
                          "errorCode": "errorCode",
                          "errorMessage": "errorMessage",
                          "id": "id",
                          "providerStatus": "providerStatus",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "resolvedAt": "resolvedAt",
                          "sentAt": "sentAt",
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "pharmacyId": "pharmacyId",
                      "createdAt": "createdAt",
                      "id": "id",
                      "prescriptionId": "prescriptionId",
                      "status": "status",
                      "trackingNumber": "trackingNumber",
                      "trackingStatus": "trackingStatus",
                      "shippedAt": "shippedAt",
                      "deliveredAt": "deliveredAt",
                      "estimatedDeliveryAt": "estimatedDeliveryAt",
                      "exceptions": [
                        {
                          "actionable": true,
                          "assignedTo": {
                            "id": "id",
                            "name": "name"
                          },
                          "createdAt": "createdAt",
                          "dueAt": "dueAt",
                          "id": "id",
                          "kind": "kind",
                          "resolution": "resolution",
                          "resolvedAt": "resolvedAt",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        },
                        {
                          "actionable": true,
                          "assignedTo": {
                            "id": "id",
                            "name": "name"
                          },
                          "createdAt": "createdAt",
                          "dueAt": "dueAt",
                          "id": "id",
                          "kind": "kind",
                          "resolution": "resolution",
                          "resolvedAt": "resolvedAt",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "shipping": {
                        "destinationType": "patient",
                        "method": "standard",
                        "option": {
                          "amountCents": 1,
                          "currency": "USD",
                          "label": "label",
                          "serviceLevel": "serviceLevel",
                          "temperature": "ambient"
                        }
                      },
                      "shipments": [
                        {
                          "carrier": "carrier",
                          "createdAt": "createdAt",
                          "deliveredAt": "deliveredAt",
                          "estimatedDeliveryAt": "estimatedDeliveryAt",
                          "id": "id",
                          "isActive": true,
                          "providerStatus": "providerStatus",
                          "replacedAt": "replacedAt",
                          "replacesShipmentId": "replacesShipmentId",
                          "shippedAt": "shippedAt",
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "trackingNumber": "trackingNumber",
                          "trackingUrl": "trackingUrl",
                          "updatedAt": "updatedAt",
                          "voidedAt": "voidedAt"
                        },
                        {
                          "carrier": "carrier",
                          "createdAt": "createdAt",
                          "deliveredAt": "deliveredAt",
                          "estimatedDeliveryAt": "estimatedDeliveryAt",
                          "id": "id",
                          "isActive": true,
                          "providerStatus": "providerStatus",
                          "replacedAt": "replacedAt",
                          "replacesShipmentId": "replacesShipmentId",
                          "shippedAt": "shippedAt",
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "trackingNumber": "trackingNumber",
                          "trackingUrl": "trackingUrl",
                          "updatedAt": "updatedAt",
                          "voidedAt": "voidedAt"
                        }
                      ],
                      "trackingUrl": "trackingUrl",
                      "updatedAt": "updatedAt"
                    },
                    {
                      "carrier": "carrier",
                      "cancellations": [
                        {
                          "attempts": 1,
                          "confirmedAt": "confirmedAt",
                          "createdAt": "createdAt",
                          "errorCode": "errorCode",
                          "errorMessage": "errorMessage",
                          "id": "id",
                          "providerStatus": "providerStatus",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "resolvedAt": "resolvedAt",
                          "sentAt": "sentAt",
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        },
                        {
                          "attempts": 1,
                          "confirmedAt": "confirmedAt",
                          "createdAt": "createdAt",
                          "errorCode": "errorCode",
                          "errorMessage": "errorMessage",
                          "id": "id",
                          "providerStatus": "providerStatus",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "resolvedAt": "resolvedAt",
                          "sentAt": "sentAt",
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "pharmacyId": "pharmacyId",
                      "createdAt": "createdAt",
                      "id": "id",
                      "prescriptionId": "prescriptionId",
                      "status": "status",
                      "trackingNumber": "trackingNumber",
                      "trackingStatus": "trackingStatus",
                      "shippedAt": "shippedAt",
                      "deliveredAt": "deliveredAt",
                      "estimatedDeliveryAt": "estimatedDeliveryAt",
                      "exceptions": [
                        {
                          "actionable": true,
                          "assignedTo": {
                            "id": "id",
                            "name": "name"
                          },
                          "createdAt": "createdAt",
                          "dueAt": "dueAt",
                          "id": "id",
                          "kind": "kind",
                          "resolution": "resolution",
                          "resolvedAt": "resolvedAt",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        },
                        {
                          "actionable": true,
                          "assignedTo": {
                            "id": "id",
                            "name": "name"
                          },
                          "createdAt": "createdAt",
                          "dueAt": "dueAt",
                          "id": "id",
                          "kind": "kind",
                          "resolution": "resolution",
                          "resolvedAt": "resolvedAt",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "shipping": {
                        "destinationType": "patient",
                        "method": "standard",
                        "option": {
                          "amountCents": 1,
                          "currency": "USD",
                          "label": "label",
                          "serviceLevel": "serviceLevel",
                          "temperature": "ambient"
                        }
                      },
                      "shipments": [
                        {
                          "carrier": "carrier",
                          "createdAt": "createdAt",
                          "deliveredAt": "deliveredAt",
                          "estimatedDeliveryAt": "estimatedDeliveryAt",
                          "id": "id",
                          "isActive": true,
                          "providerStatus": "providerStatus",
                          "replacedAt": "replacedAt",
                          "replacesShipmentId": "replacesShipmentId",
                          "shippedAt": "shippedAt",
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "trackingNumber": "trackingNumber",
                          "trackingUrl": "trackingUrl",
                          "updatedAt": "updatedAt",
                          "voidedAt": "voidedAt"
                        },
                        {
                          "carrier": "carrier",
                          "createdAt": "createdAt",
                          "deliveredAt": "deliveredAt",
                          "estimatedDeliveryAt": "estimatedDeliveryAt",
                          "id": "id",
                          "isActive": true,
                          "providerStatus": "providerStatus",
                          "replacedAt": "replacedAt",
                          "replacesShipmentId": "replacesShipmentId",
                          "shippedAt": "shippedAt",
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "trackingNumber": "trackingNumber",
                          "trackingUrl": "trackingUrl",
                          "updatedAt": "updatedAt",
                          "voidedAt": "voidedAt"
                        }
                      ],
                      "trackingUrl": "trackingUrl",
                      "updatedAt": "updatedAt"
                    }
                  ],
                  "id": "id",
                  "lifecycleEvents": [
                    {
                      "createdAt": "createdAt",
                      "eventType": "eventType",
                      "id": "id",
                      "message": "message",
                      "source": "cancellation"
                    },
                    {
                      "createdAt": "createdAt",
                      "eventType": "eventType",
                      "id": "id",
                      "message": "message",
                      "source": "cancellation"
                    }
                  ],
                  "livemode": true,
                  "object": "order",
                  "patientExternalId": "patientExternalId",
                  "patientId": "patientId",
                  "patientName": "patientName",
                  "patientState": "patientState",
                  "practiceId": "practiceId",
                  "prescriberName": "prescriberName",
                  "prescriberNpi": "prescriberNpi",
                  "review": {
                    "status": "completed",
                    "reason": "reason",
                    "requestedAt": "requestedAt",
                    "completedAt": "completedAt",
                    "canceledAt": "canceledAt",
                    "resolvedAt": "resolvedAt",
                    "resolvedBy": {
                      "id": "id",
                      "type": "type"
                    },
                    "providerId": "providerId"
                  },
                  "prescriptions": [
                    {
                      "version": 1,
                      "daysSupply": "Infinity",
                      "patientSnapshot": {
                        "address": {
                          "address": {
                            "key": "value"
                          }
                        },
                        "allergyReviewStatus": "no_known",
                        "dateOfBirth": "dateOfBirth",
                        "email": "email",
                        "gender": "f",
                        "legalName": "legalName",
                        "phone": "phone",
                        "state": "state"
                      },
                      "deliveryAddress": {
                        "deliveryAddress": {
                          "key": "value"
                        }
                      },
                      "deliveryAddressDiffersFromPatient": true,
                      "providerSnapshot": {
                        "address": {
                          "address": {
                            "key": "value"
                          }
                        },
                        "credentials": "credentials",
                        "legalName": "legalName",
                        "licenseNumber": "licenseNumber",
                        "licenseState": "licenseState",
                        "licenseExpiresAt": "licenseExpiresAt",
                        "npi": "npi",
                        "phone": "phone"
                      },
                      "clinical": {
                        "allergies": [],
                        "medicationReviewStatus": "not_reviewed",
                        "diagnosisReviewStatus": "not_reviewed",
                        "conditions": [],
                        "compoundingReason": {
                          "context": "context"
                        },
                        "medications": [],
                        "observations": []
                      },
                      "dispensing": {
                        "dispenseUponAcceptance": true,
                        "substitutionPermitted": true,
                        "pharmacyNotes": "pharmacyNotes",
                        "requestedFillDate": "requestedFillDate",
                        "shippingOptionId": "shippingOptionId",
                        "shippingAmountCents": 1,
                        "shippingDestinationType": "patient"
                      },
                      "structuredSig": {
                        "dose": "dose",
                        "doseUnit": "doseUnit",
                        "frequency": "frequency",
                        "route": "route",
                        "prn": true,
                        "duration": "duration",
                        "indication": "indication",
                        "maxDailyUse": "maxDailyUse",
                        "titrationSchedule": "titrationSchedule"
                      },
                      "externalPrescriptionId": "externalPrescriptionId",
                      "catalogItemId": "catalogItemId",
                      "pharmacyId": "pharmacyId",
                      "pharmacyName": "pharmacyName",
                      "directions": "directions",
                      "dosageForm": "dosageForm",
                      "id": "id",
                      "medicationName": "medicationName",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "status",
                      "strength": "strength"
                    },
                    {
                      "version": 1,
                      "daysSupply": "Infinity",
                      "patientSnapshot": {
                        "address": {
                          "address": {
                            "key": "value"
                          }
                        },
                        "allergyReviewStatus": "no_known",
                        "dateOfBirth": "dateOfBirth",
                        "email": "email",
                        "gender": "f",
                        "legalName": "legalName",
                        "phone": "phone",
                        "state": "state"
                      },
                      "deliveryAddress": {
                        "deliveryAddress": {
                          "key": "value"
                        }
                      },
                      "deliveryAddressDiffersFromPatient": true,
                      "providerSnapshot": {
                        "address": {
                          "address": {
                            "key": "value"
                          }
                        },
                        "credentials": "credentials",
                        "legalName": "legalName",
                        "licenseNumber": "licenseNumber",
                        "licenseState": "licenseState",
                        "licenseExpiresAt": "licenseExpiresAt",
                        "npi": "npi",
                        "phone": "phone"
                      },
                      "clinical": {
                        "allergies": [],
                        "medicationReviewStatus": "not_reviewed",
                        "diagnosisReviewStatus": "not_reviewed",
                        "conditions": [],
                        "compoundingReason": {
                          "context": "context"
                        },
                        "medications": [],
                        "observations": []
                      },
                      "dispensing": {
                        "dispenseUponAcceptance": true,
                        "substitutionPermitted": true,
                        "pharmacyNotes": "pharmacyNotes",
                        "requestedFillDate": "requestedFillDate",
                        "shippingOptionId": "shippingOptionId",
                        "shippingAmountCents": 1,
                        "shippingDestinationType": "patient"
                      },
                      "structuredSig": {
                        "dose": "dose",
                        "doseUnit": "doseUnit",
                        "frequency": "frequency",
                        "route": "route",
                        "prn": true,
                        "duration": "duration",
                        "indication": "indication",
                        "maxDailyUse": "maxDailyUse",
                        "titrationSchedule": "titrationSchedule"
                      },
                      "externalPrescriptionId": "externalPrescriptionId",
                      "catalogItemId": "catalogItemId",
                      "pharmacyId": "pharmacyId",
                      "pharmacyName": "pharmacyName",
                      "directions": "directions",
                      "dosageForm": "dosageForm",
                      "id": "id",
                      "medicationName": "medicationName",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "status",
                      "strength": "strength"
                    }
                  ],
                  "status": "blocked",
                  "updatedAt": "updatedAt"
                },
                {
                  "revision": "revision",
                  "otcItems": [
                    {
                      "catalogItemId": "catalogItemId",
                      "prescriptionId": "prescriptionId",
                      "name": "name",
                      "quantity": 1,
                      "unitPriceCents": 1,
                      "subtotalCents": 1
                    },
                    {
                      "catalogItemId": "catalogItemId",
                      "prescriptionId": "prescriptionId",
                      "name": "name",
                      "quantity": 1,
                      "unitPriceCents": 1,
                      "subtotalCents": 1
                    }
                  ],
                  "practiceMedicationTotalCents": 1,
                  "externalOrderId": "externalOrderId",
                  "metadata": {},
                  "createdAt": "createdAt",
                  "fulfillments": [
                    {
                      "carrier": "carrier",
                      "cancellations": [
                        {
                          "attempts": 1,
                          "confirmedAt": "confirmedAt",
                          "createdAt": "createdAt",
                          "errorCode": "errorCode",
                          "errorMessage": "errorMessage",
                          "id": "id",
                          "providerStatus": "providerStatus",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "resolvedAt": "resolvedAt",
                          "sentAt": "sentAt",
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        },
                        {
                          "attempts": 1,
                          "confirmedAt": "confirmedAt",
                          "createdAt": "createdAt",
                          "errorCode": "errorCode",
                          "errorMessage": "errorMessage",
                          "id": "id",
                          "providerStatus": "providerStatus",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "resolvedAt": "resolvedAt",
                          "sentAt": "sentAt",
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "pharmacyId": "pharmacyId",
                      "createdAt": "createdAt",
                      "id": "id",
                      "prescriptionId": "prescriptionId",
                      "status": "status",
                      "trackingNumber": "trackingNumber",
                      "trackingStatus": "trackingStatus",
                      "shippedAt": "shippedAt",
                      "deliveredAt": "deliveredAt",
                      "estimatedDeliveryAt": "estimatedDeliveryAt",
                      "exceptions": [
                        {
                          "actionable": true,
                          "assignedTo": {
                            "id": "id",
                            "name": "name"
                          },
                          "createdAt": "createdAt",
                          "dueAt": "dueAt",
                          "id": "id",
                          "kind": "kind",
                          "resolution": "resolution",
                          "resolvedAt": "resolvedAt",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        },
                        {
                          "actionable": true,
                          "assignedTo": {
                            "id": "id",
                            "name": "name"
                          },
                          "createdAt": "createdAt",
                          "dueAt": "dueAt",
                          "id": "id",
                          "kind": "kind",
                          "resolution": "resolution",
                          "resolvedAt": "resolvedAt",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "shipping": {
                        "destinationType": "patient",
                        "method": "standard",
                        "option": {
                          "amountCents": 1,
                          "currency": "USD",
                          "label": "label",
                          "serviceLevel": "serviceLevel",
                          "temperature": "ambient"
                        }
                      },
                      "shipments": [
                        {
                          "carrier": "carrier",
                          "createdAt": "createdAt",
                          "deliveredAt": "deliveredAt",
                          "estimatedDeliveryAt": "estimatedDeliveryAt",
                          "id": "id",
                          "isActive": true,
                          "providerStatus": "providerStatus",
                          "replacedAt": "replacedAt",
                          "replacesShipmentId": "replacesShipmentId",
                          "shippedAt": "shippedAt",
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "trackingNumber": "trackingNumber",
                          "trackingUrl": "trackingUrl",
                          "updatedAt": "updatedAt",
                          "voidedAt": "voidedAt"
                        },
                        {
                          "carrier": "carrier",
                          "createdAt": "createdAt",
                          "deliveredAt": "deliveredAt",
                          "estimatedDeliveryAt": "estimatedDeliveryAt",
                          "id": "id",
                          "isActive": true,
                          "providerStatus": "providerStatus",
                          "replacedAt": "replacedAt",
                          "replacesShipmentId": "replacesShipmentId",
                          "shippedAt": "shippedAt",
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "trackingNumber": "trackingNumber",
                          "trackingUrl": "trackingUrl",
                          "updatedAt": "updatedAt",
                          "voidedAt": "voidedAt"
                        }
                      ],
                      "trackingUrl": "trackingUrl",
                      "updatedAt": "updatedAt"
                    },
                    {
                      "carrier": "carrier",
                      "cancellations": [
                        {
                          "attempts": 1,
                          "confirmedAt": "confirmedAt",
                          "createdAt": "createdAt",
                          "errorCode": "errorCode",
                          "errorMessage": "errorMessage",
                          "id": "id",
                          "providerStatus": "providerStatus",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "resolvedAt": "resolvedAt",
                          "sentAt": "sentAt",
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        },
                        {
                          "attempts": 1,
                          "confirmedAt": "confirmedAt",
                          "createdAt": "createdAt",
                          "errorCode": "errorCode",
                          "errorMessage": "errorMessage",
                          "id": "id",
                          "providerStatus": "providerStatus",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "resolvedAt": "resolvedAt",
                          "sentAt": "sentAt",
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "pharmacyId": "pharmacyId",
                      "createdAt": "createdAt",
                      "id": "id",
                      "prescriptionId": "prescriptionId",
                      "status": "status",
                      "trackingNumber": "trackingNumber",
                      "trackingStatus": "trackingStatus",
                      "shippedAt": "shippedAt",
                      "deliveredAt": "deliveredAt",
                      "estimatedDeliveryAt": "estimatedDeliveryAt",
                      "exceptions": [
                        {
                          "actionable": true,
                          "assignedTo": {
                            "id": "id",
                            "name": "name"
                          },
                          "createdAt": "createdAt",
                          "dueAt": "dueAt",
                          "id": "id",
                          "kind": "kind",
                          "resolution": "resolution",
                          "resolvedAt": "resolvedAt",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        },
                        {
                          "actionable": true,
                          "assignedTo": {
                            "id": "id",
                            "name": "name"
                          },
                          "createdAt": "createdAt",
                          "dueAt": "dueAt",
                          "id": "id",
                          "kind": "kind",
                          "resolution": "resolution",
                          "resolvedAt": "resolvedAt",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "shipping": {
                        "destinationType": "patient",
                        "method": "standard",
                        "option": {
                          "amountCents": 1,
                          "currency": "USD",
                          "label": "label",
                          "serviceLevel": "serviceLevel",
                          "temperature": "ambient"
                        }
                      },
                      "shipments": [
                        {
                          "carrier": "carrier",
                          "createdAt": "createdAt",
                          "deliveredAt": "deliveredAt",
                          "estimatedDeliveryAt": "estimatedDeliveryAt",
                          "id": "id",
                          "isActive": true,
                          "providerStatus": "providerStatus",
                          "replacedAt": "replacedAt",
                          "replacesShipmentId": "replacesShipmentId",
                          "shippedAt": "shippedAt",
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "trackingNumber": "trackingNumber",
                          "trackingUrl": "trackingUrl",
                          "updatedAt": "updatedAt",
                          "voidedAt": "voidedAt"
                        },
                        {
                          "carrier": "carrier",
                          "createdAt": "createdAt",
                          "deliveredAt": "deliveredAt",
                          "estimatedDeliveryAt": "estimatedDeliveryAt",
                          "id": "id",
                          "isActive": true,
                          "providerStatus": "providerStatus",
                          "replacedAt": "replacedAt",
                          "replacesShipmentId": "replacesShipmentId",
                          "shippedAt": "shippedAt",
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "trackingNumber": "trackingNumber",
                          "trackingUrl": "trackingUrl",
                          "updatedAt": "updatedAt",
                          "voidedAt": "voidedAt"
                        }
                      ],
                      "trackingUrl": "trackingUrl",
                      "updatedAt": "updatedAt"
                    }
                  ],
                  "id": "id",
                  "lifecycleEvents": [
                    {
                      "createdAt": "createdAt",
                      "eventType": "eventType",
                      "id": "id",
                      "message": "message",
                      "source": "cancellation"
                    },
                    {
                      "createdAt": "createdAt",
                      "eventType": "eventType",
                      "id": "id",
                      "message": "message",
                      "source": "cancellation"
                    }
                  ],
                  "livemode": true,
                  "object": "order",
                  "patientExternalId": "patientExternalId",
                  "patientId": "patientId",
                  "patientName": "patientName",
                  "patientState": "patientState",
                  "practiceId": "practiceId",
                  "prescriberName": "prescriberName",
                  "prescriberNpi": "prescriberNpi",
                  "review": {
                    "status": "completed",
                    "reason": "reason",
                    "requestedAt": "requestedAt",
                    "completedAt": "completedAt",
                    "canceledAt": "canceledAt",
                    "resolvedAt": "resolvedAt",
                    "resolvedBy": {
                      "id": "id",
                      "type": "type"
                    },
                    "providerId": "providerId"
                  },
                  "prescriptions": [
                    {
                      "version": 1,
                      "daysSupply": "Infinity",
                      "patientSnapshot": {
                        "address": {
                          "address": {
                            "key": "value"
                          }
                        },
                        "allergyReviewStatus": "no_known",
                        "dateOfBirth": "dateOfBirth",
                        "email": "email",
                        "gender": "f",
                        "legalName": "legalName",
                        "phone": "phone",
                        "state": "state"
                      },
                      "deliveryAddress": {
                        "deliveryAddress": {
                          "key": "value"
                        }
                      },
                      "deliveryAddressDiffersFromPatient": true,
                      "providerSnapshot": {
                        "address": {
                          "address": {
                            "key": "value"
                          }
                        },
                        "credentials": "credentials",
                        "legalName": "legalName",
                        "licenseNumber": "licenseNumber",
                        "licenseState": "licenseState",
                        "licenseExpiresAt": "licenseExpiresAt",
                        "npi": "npi",
                        "phone": "phone"
                      },
                      "clinical": {
                        "allergies": [],
                        "medicationReviewStatus": "not_reviewed",
                        "diagnosisReviewStatus": "not_reviewed",
                        "conditions": [],
                        "compoundingReason": {
                          "context": "context"
                        },
                        "medications": [],
                        "observations": []
                      },
                      "dispensing": {
                        "dispenseUponAcceptance": true,
                        "substitutionPermitted": true,
                        "pharmacyNotes": "pharmacyNotes",
                        "requestedFillDate": "requestedFillDate",
                        "shippingOptionId": "shippingOptionId",
                        "shippingAmountCents": 1,
                        "shippingDestinationType": "patient"
                      },
                      "structuredSig": {
                        "dose": "dose",
                        "doseUnit": "doseUnit",
                        "frequency": "frequency",
                        "route": "route",
                        "prn": true,
                        "duration": "duration",
                        "indication": "indication",
                        "maxDailyUse": "maxDailyUse",
                        "titrationSchedule": "titrationSchedule"
                      },
                      "externalPrescriptionId": "externalPrescriptionId",
                      "catalogItemId": "catalogItemId",
                      "pharmacyId": "pharmacyId",
                      "pharmacyName": "pharmacyName",
                      "directions": "directions",
                      "dosageForm": "dosageForm",
                      "id": "id",
                      "medicationName": "medicationName",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "status",
                      "strength": "strength"
                    },
                    {
                      "version": 1,
                      "daysSupply": "Infinity",
                      "patientSnapshot": {
                        "address": {
                          "address": {
                            "key": "value"
                          }
                        },
                        "allergyReviewStatus": "no_known",
                        "dateOfBirth": "dateOfBirth",
                        "email": "email",
                        "gender": "f",
                        "legalName": "legalName",
                        "phone": "phone",
                        "state": "state"
                      },
                      "deliveryAddress": {
                        "deliveryAddress": {
                          "key": "value"
                        }
                      },
                      "deliveryAddressDiffersFromPatient": true,
                      "providerSnapshot": {
                        "address": {
                          "address": {
                            "key": "value"
                          }
                        },
                        "credentials": "credentials",
                        "legalName": "legalName",
                        "licenseNumber": "licenseNumber",
                        "licenseState": "licenseState",
                        "licenseExpiresAt": "licenseExpiresAt",
                        "npi": "npi",
                        "phone": "phone"
                      },
                      "clinical": {
                        "allergies": [],
                        "medicationReviewStatus": "not_reviewed",
                        "diagnosisReviewStatus": "not_reviewed",
                        "conditions": [],
                        "compoundingReason": {
                          "context": "context"
                        },
                        "medications": [],
                        "observations": []
                      },
                      "dispensing": {
                        "dispenseUponAcceptance": true,
                        "substitutionPermitted": true,
                        "pharmacyNotes": "pharmacyNotes",
                        "requestedFillDate": "requestedFillDate",
                        "shippingOptionId": "shippingOptionId",
                        "shippingAmountCents": 1,
                        "shippingDestinationType": "patient"
                      },
                      "structuredSig": {
                        "dose": "dose",
                        "doseUnit": "doseUnit",
                        "frequency": "frequency",
                        "route": "route",
                        "prn": true,
                        "duration": "duration",
                        "indication": "indication",
                        "maxDailyUse": "maxDailyUse",
                        "titrationSchedule": "titrationSchedule"
                      },
                      "externalPrescriptionId": "externalPrescriptionId",
                      "catalogItemId": "catalogItemId",
                      "pharmacyId": "pharmacyId",
                      "pharmacyName": "pharmacyName",
                      "directions": "directions",
                      "dosageForm": "dosageForm",
                      "id": "id",
                      "medicationName": "medicationName",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "status",
                      "strength": "strength"
                    }
                  ],
                  "status": "blocked",
                  "updatedAt": "updatedAt"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/orders"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/orders").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.ListOrdersAsync(new ListOrdersRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "revision": "revision",
                  "otcItems": [
                    {
                      "catalogItemId": "catalogItemId",
                      "prescriptionId": "prescriptionId",
                      "name": "name",
                      "quantity": 1,
                      "unitPriceCents": 1,
                      "subtotalCents": 1
                    }
                  ],
                  "practiceMedicationTotalCents": 1,
                  "externalOrderId": "externalOrderId",
                  "metadata": {},
                  "createdAt": "createdAt",
                  "fulfillments": [
                    {
                      "cancellations": [
                        {
                          "attempts": 1,
                          "createdAt": "createdAt",
                          "id": "id",
                          "reason": "reason",
                          "requestedAt": "requestedAt",
                          "requestedBy": {
                            "id": "id",
                            "type": "type"
                          },
                          "source": "provider",
                          "status": "requested",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "createdAt": "createdAt",
                      "id": "id",
                      "prescriptionId": "prescriptionId",
                      "status": "status",
                      "exceptions": [
                        {
                          "actionable": true,
                          "createdAt": "createdAt",
                          "id": "id",
                          "kind": "kind",
                          "retryable": true,
                          "severity": "warning",
                          "status": "open",
                          "summary": "summary",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "shipping": {
                        "destinationType": "patient",
                        "method": "standard"
                      },
                      "shipments": [
                        {
                          "createdAt": "createdAt",
                          "id": "id",
                          "isActive": true,
                          "source": "pharmacy_webhook",
                          "status": "label_created",
                          "updatedAt": "updatedAt"
                        }
                      ],
                      "updatedAt": "updatedAt"
                    }
                  ],
                  "id": "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                  "lifecycleEvents": [
                    {
                      "createdAt": "createdAt",
                      "eventType": "eventType",
                      "id": "id",
                      "message": "message",
                      "source": "cancellation"
                    }
                  ],
                  "livemode": true,
                  "object": "order",
                  "patientExternalId": "patientExternalId",
                  "patientId": "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                  "patientName": "patientName",
                  "patientState": "patientState",
                  "practiceId": "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                  "prescriberName": "prescriberName",
                  "prescriberNpi": "prescriberNpi",
                  "review": {
                    "status": "completed",
                    "requestedAt": "requestedAt"
                  },
                  "prescriptions": [
                    {
                      "version": 1,
                      "patientSnapshot": {
                        "dateOfBirth": "dateOfBirth",
                        "legalName": "legalName",
                        "state": "state"
                      },
                      "deliveryAddressDiffersFromPatient": true,
                      "directions": "directions",
                      "id": "id",
                      "medicationName": "medicationName",
                      "quantity": "Infinity",
                      "quantityUnit": "quantityUnit",
                      "refills": 1,
                      "status": "status"
                    }
                  ],
                  "status": "blocked",
                  "updatedAt": "updatedAt"
                }
              ],
              "hasMore": true,
              "object": "list",
              "url": "/v1/orders"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/orders")
                    .WithParam("endingBefore", "ord_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("orderId", "ord_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("patientId", "pat_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("practiceId", "prac_01j2y8m6jcc9tt24af5pw9x1bc")
                    .WithParam("startingAfter", "ord_01j2y8m6jcc9tt24af5pw9x1bc")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Orders.ListOrdersAsync(
            new ListOrdersRequest
            {
                EndingBefore = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
                PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
                PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
                StartingAfter = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
