using Affinity;class ApprovedDocs{class Draft{public List<OrderCreateParamsPrescriptionsItem> Prescriptions {get;}=[];}class Job{public string CreateOrderKey="create",SignOrderKey="sign",SubmitOrderKey="submit";}class Review{public string PrescriberId="prov_a",OrderRevision="rev_a";public bool SignatureAttestation=true;}Task SyncPatientAsync(object patient)=>Task.CompletedTask;
async Task Example0(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
var patients = await api.Patients.ListAsync(new PatientListParams { Limit = 20 });
var patient = await api.Patients.GetAsync(patientId);
var items = await api.Catalog.Items.ListAsync(new CatalogItemListParams { Limit = 20 });

}
async Task Example1(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
var options = new RequestOptions { PracticeId = practiceId };
var patients = await api.Patients.ListAsync(
    new PatientListParams { Limit = 20 },
    options
);

var patient = await api.Patients.GetAsync(patientId, options);

await api.Patients.UpdateAsync(
    patientId,
    new PatientUpdateParams { Email = "alex@example.com" },
    new RequestOptions {
        PracticeId = practiceId,
    }
);


}
async Task Example2(){var api=new AffinityClient("test");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
var practice = api.ForPractice(practiceId);

var patients = await practice.Patients.ListAsync(new PatientListParams { Limit = 20 });
var items = await practice.Catalog.Items.ListAsync(
    new CatalogItemListParams { Limit = 20 }
);


}
async Task Example3(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
var patient = await practice.Patients.CreateAsync(new PatientCreateParams {
    Name = new PatientName { First = "Alex", Last = "Example" },
    DateOfBirth = "1990-01-01",
});

var saved = await practice.Patients.GetAsync(patient.Id);
await practice.Patients.UpdateAsync(patient.Id, new PatientUpdateParams {
    Email = "alex@example.com",
});

await practice.Patients.UpdateAsync(patient.Id, new PatientUpdateParams {
    Status = "archived",
});

}
async Task Example4(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
await practice.Patients.DeleteAsync(patientId);

}
async Task Example5(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
var order = await api.Orders.CreateAsync(
    new OrderCreateParams { PatientId = patientId, Prescriptions = draft.Prescriptions },
    new RequestOptions { PracticeId = practiceId, IdempotencyKey = job.CreateOrderKey }
);


}
async Task Example6(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
await practice.Orders.SignAsync(
    orderId,
    new OrderSignParams {
        Prescriber = new PrescriberSelector { Id = review.PrescriberId },
        ExpectedRevision = review.OrderRevision,
        SignatureAttestation = review.SignatureAttestation,
    },
    new RequestOptions { IdempotencyKey = job.SignOrderKey }
);

var submission = await practice.Orders.SubmitAsync(orderId,
    new RequestOptions { IdempotencyKey = job.SubmitOrderKey });

}
async Task Example7(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
var page = await practice.Patients.ListAsync(new PatientListParams { Limit = 20 });
if (page.HasMore && page.Data.Any()) {
    var next = await practice.Patients.ListAsync(new PatientListParams {
        Limit = 20, StartingAfter = page.Data.Last().Id,
    });
}

var patients = practice.Patients.IterateAsync(
    new PatientListParams { Limit = 100 }
);

await foreach (var patient in patients) {
    await SyncPatientAsync(patient);
}

}
async Task Example8(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
try {
    await practice.Patients.GetAsync(patientId);
} catch (AffinityException error) {
    Console.Error.WriteLine(
        $"status={error.Status} code={error.Code} request={error.RequestId} " +
        $"retryable={error.Retryable} retryAfter={error.RetryAfter}");
}

}
async Task Example9(){var api=new AffinityClient("test");var practice=api.ForPractice("prac_a");string practiceId="prac_a",patientId="pat_a",orderId="ord_a";var draft=new Draft();var job=new Job();var review=new Review();
var practices = await api.Practices.ListAsync(new PracticeListParams { Limit = 20 });
var selected = await api.Practices.GetAsync(practiceId);
var endpoints = await api.Webhooks.Endpoints.ListAsync(
    new WebhookEndpointListParams { Limit = 20 }
);


}
}