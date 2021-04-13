package com.trulioo.sdk.api;

import static org.junit.jupiter.api.Assertions.*;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.time.OffsetDateTime;
import java.time.ZoneOffset;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;

import org.junit.jupiter.api.*;
import okhttp3.mockwebserver.*;
import okhttp3.HttpUrl;
import com.google.gson.JsonObject;
import com.google.gson.JsonArray;
import com.google.gson.internal.LinkedTreeMap;

import com.trulioo.sdk.ApiClient;
import com.trulioo.sdk.ApiException;
import com.trulioo.sdk.SuccessfulCallback;
import com.trulioo.sdk.auth.ApiKeyAuth;
import com.trulioo.sdk.model.TransactionRecordResult;
import com.trulioo.sdk.model.TransactionStatus;
import com.trulioo.sdk.model.VerifyRequest;
import com.trulioo.sdk.model.VerifyResult;
import com.trulioo.sdk.model.DataField;
import com.trulioo.sdk.model.DatasourceField;
import com.trulioo.sdk.model.DatasourceResult;
import com.trulioo.sdk.model.Record;
import com.trulioo.sdk.model.AppendedField;
import com.trulioo.sdk.model.ServiceError;

public class VerificationsApiTest {
    private MockWebServer server;
    private VerificationsApi verificationsApi;

    /* Setup */

    @BeforeEach
    public void beforeEach() throws IOException {
        server = new MockWebServer();
        server.start();

        HttpUrl url = server.url("/");
        ApiClient apiClient = new ApiClient().setBasePath(url.scheme() + "://" + url.host() + ":" + url.port());

        ApiKeyAuth auth = (ApiKeyAuth) apiClient.getAuthentication("ApiKeyAuth");
        auth.setApiKey("test-api-key");

        verificationsApi = new VerificationsApi(apiClient);
    }

    @AfterEach
    public void afterEach() throws IOException {
        server.shutdown();
    }

    /* Test constructor */

    @Test
    public void testVerificationsApi() {
        verificationsApi = new VerificationsApi();
        ApiClient apiClient = new ApiClient().setBasePath("https://abcd");
        verificationsApi.setApiClient(apiClient);

        assertEquals(apiClient, verificationsApi.getApiClient());
    }

    /* Test documentDownload */

    @Test
    @SuppressWarnings("unchecked")
    public void testDocumentDownloadSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("Image", "base64");
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        LinkedTreeMap<String, Object> expected = new LinkedTreeMap<String, Object>();
        expected.put("Image", "base64");

        try {
            LinkedTreeMap<String, Object> result = (LinkedTreeMap<String, Object>) verificationsApi
                    .documentDownload("trial", "test-transaction-guid", "DocumentFrontImage");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals(
                    "GET /trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            verificationsApi.documentDownloadAsync("trial", "test-transaction-guid", "DocumentFrontImage",
                    new SuccessfulCallback<Object>() {
                        public void onSuccess(Object resultAsync, int status, Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals(
                    "GET /trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testDocumentDownloadUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> verificationsApi.documentDownload("trial", "test-transaction-guid", "DocumentFrontImage"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testDocumentDownloadNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> verificationsApi.documentDownload(null, "test-transaction-guid", "DocumentFrontImage"));
        assertEquals("Missing the required parameter 'mode' when calling documentDownload(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> verificationsApi.documentDownload("trial", null, "DocumentFrontImage"));
        assertEquals("Missing the required parameter 'transactionRecordId' when calling documentDownload(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> verificationsApi.documentDownload("trial", "test-transaction-guid", null));
        assertEquals("Missing the required parameter 'fieldName' when calling documentDownload(Async)",
                e3.getMessage());
    }

    /* Test getTransactionRecord */

    @Test
    public void testGetTransactionRecordSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        JsonArray bodyInputFields = new JsonArray();
        JsonObject bodyInputFields0 = new JsonObject();
        bodyInputFields0.addProperty("FieldName", "FirstGivenName");
        bodyInputFields0.addProperty("Value", "Test");
        bodyInputFields.add(bodyInputFields0);
        body.add("InputFields", bodyInputFields);
        body.addProperty("UploadedDt", "2017-07-11T21:47:50.778124");
        JsonObject bodyRecord = new JsonObject();
        bodyRecord.addProperty("TransactionRecordID", "test-transaction-guid");
        bodyRecord.addProperty("RecordStatus", "match");
        JsonArray bodyRecordDatasourceResults = new JsonArray();
        JsonObject bodyRecordDatasourceResults0 = new JsonObject();
        bodyRecordDatasourceResults0.addProperty("DatasourceName", "Datasource");
        JsonArray bodyRecordDatasourceResults0DatasourceFields = new JsonArray();
        JsonObject bodyRecordDatasourceResults0DatasourceFields0 = new JsonObject();
        bodyRecordDatasourceResults0DatasourceFields0.addProperty("FieldName", "FirstGivenName");
        bodyRecordDatasourceResults0DatasourceFields0.addProperty("Status", "match");
        bodyRecordDatasourceResults0DatasourceFields.add(bodyRecordDatasourceResults0DatasourceFields0);
        bodyRecordDatasourceResults0.add("DatasourceFields", bodyRecordDatasourceResults0DatasourceFields);
        bodyRecordDatasourceResults.add(bodyRecordDatasourceResults0);
        bodyRecord.add("DatasourceResults", bodyRecordDatasourceResults);
        body.add("Record", bodyRecord);
        body.add("Errors", new JsonArray());

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        TransactionRecordResult expected = new TransactionRecordResult();
        expected.addInputFieldsItem(new DataField().fieldName("FirstGivenName").value("Test"));
        expected.setUploadedDt(
                OffsetDateTime.of(2017, 7, 11, 21, 47, 50, 778124000, ZoneOffset.UTC).truncatedTo(ChronoUnit.MICROS));
        Record expectedRecord = new Record().transactionRecordID("test-transaction-guid").recordStatus("match");
        DatasourceResult expectedRecordDatasourceResult0 = new DatasourceResult().datasourceName("Datasource");
        expectedRecordDatasourceResult0
                .addDatasourceFieldsItem(new DatasourceField().fieldName("FirstGivenName").status("match"));
        expectedRecord.addDatasourceResultsItem(expectedRecordDatasourceResult0);
        expected.setRecord(expectedRecord);
        expected.setErrors(new ArrayList<ServiceError>());

        try {
            TransactionRecordResult result = verificationsApi.getTransactionRecord("trial", "test-transaction-guid");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/verifications/v1/transactionrecord/test-transaction-guid HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            verificationsApi.getTransactionRecordAsync("trial", "test-transaction-guid",
                    new SuccessfulCallback<TransactionRecordResult>() {
                        public void onSuccess(TransactionRecordResult resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/verifications/v1/transactionrecord/test-transaction-guid HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetTransactionRecordUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecord("trial", "test-transaction-guid"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetTransactionRecordNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecord(null, "test-transaction-guid"));
        assertEquals("Missing the required parameter 'mode' when calling getTransactionRecord(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> verificationsApi.getTransactionRecord("trial", null));
        assertEquals("Missing the required parameter 'id' when calling getTransactionRecord(Async)", e2.getMessage());
    }

    /* Test getTransactionRecordAddress */

    @Test
    public void testGetTransactionRecordAddressSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        JsonArray bodyInputFields = new JsonArray();
        JsonObject bodyInputFields0 = new JsonObject();
        bodyInputFields0.addProperty("FieldName", "FirstGivenName");
        bodyInputFields0.addProperty("Value", "Test");
        bodyInputFields.add(bodyInputFields0);
        body.add("InputFields", bodyInputFields);
        body.addProperty("UploadedDt", "2017-07-11T21:47:50.778124");
        JsonObject bodyRecord = new JsonObject();
        bodyRecord.addProperty("TransactionRecordID", "test-transaction-guid");
        bodyRecord.addProperty("RecordStatus", "match");
        JsonArray bodyRecordDatasourceResults = new JsonArray();
        JsonObject bodyRecordDatasourceResults0 = new JsonObject();
        bodyRecordDatasourceResults0.addProperty("DatasourceName", "Datasource");
        bodyRecordDatasourceResults0.add("DatasourceFields", new JsonArray());
        bodyRecordDatasourceResults0.add("AppendedFields", new JsonArray());
        bodyRecordDatasourceResults0.add("FieldGroups", new JsonArray());
        bodyRecordDatasourceResults.add(bodyRecordDatasourceResults0);
        bodyRecord.add("DatasourceResults", bodyRecordDatasourceResults);
        bodyRecord.add("Errors", new JsonArray());
        body.add("Record", bodyRecord);
        body.add("Errors", new JsonArray());

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        TransactionRecordResult expected = new TransactionRecordResult();
        expected.addInputFieldsItem(new DataField().fieldName("FirstGivenName").value("Test"));
        expected.setUploadedDt(
                OffsetDateTime.of(2017, 7, 11, 21, 47, 50, 778124000, ZoneOffset.UTC).truncatedTo(ChronoUnit.MICROS));
        Record expectedRecord = new Record().transactionRecordID("test-transaction-guid").recordStatus("match");
        DatasourceResult expectedRecordDatasourceResult0 = new DatasourceResult().datasourceName("Datasource");
        expectedRecordDatasourceResult0.setDatasourceFields(new ArrayList<DatasourceField>());
        expectedRecordDatasourceResult0.setAppendedFields(new ArrayList<AppendedField>());
        expectedRecordDatasourceResult0.setFieldGroups(new ArrayList<String>());
        expectedRecord.addDatasourceResultsItem(expectedRecordDatasourceResult0);
        expectedRecord.setErrors(new ArrayList<ServiceError>());
        expected.setRecord(expectedRecord);
        expected.setErrors(new ArrayList<ServiceError>());

        try {
            TransactionRecordResult result = verificationsApi.getTransactionRecordAddress("trial",
                    "test-transaction-guid");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            verificationsApi.getTransactionRecordAddressAsync("trial", "test-transaction-guid",
                    new SuccessfulCallback<TransactionRecordResult>() {
                        public void onSuccess(TransactionRecordResult resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetTransactionRecordAddressUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecordAddress("trial", "test-transaction-guid"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetTransactionRecordAddressNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecordAddress(null, "test-transaction-guid"));
        assertEquals("Missing the required parameter 'mode' when calling getTransactionRecordAddress(Async)",
                e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecordAddress("trial", null));
        assertEquals("Missing the required parameter 'id' when calling getTransactionRecordAddress(Async)",
                e2.getMessage());
    }

    /* Test getTransactionRecordDocument */

    @Test
    public void testGetTransactionRecordDocumentSuccess() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(200).setBody("base64"));
        server.enqueue(new MockResponse().setResponseCode(200).setBody("base64"));

        String expected = "base64";

        try {
            String result = verificationsApi.getTransactionRecordDocument("trial", "test-transaction-guid",
                    "DocumentFrontImage");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals(
                    "GET /trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            verificationsApi.getTransactionRecordDocumentAsync("trial", "test-transaction-guid", "DocumentFrontImage",
                    new SuccessfulCallback<String>() {
                        public void onSuccess(String resultAsync, int status, Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals(
                    "GET /trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetTransactionRecordDocumentUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class, () -> verificationsApi.getTransactionRecordDocument("trial",
                "test-transaction-guid", "DocumentFrontImage"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetTransactionRecordDocumentNullParams() {
        ApiException e1 = assertThrows(ApiException.class, () -> verificationsApi.getTransactionRecordDocument(null,
                "test-transaction-guid", "DocumentFrontImage"));
        assertEquals("Missing the required parameter 'mode' when calling getTransactionRecordDocument(Async)",
                e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecordDocument("trial", null, "DocumentFrontImage"));
        assertEquals(
                "Missing the required parameter 'transactionRecordID' when calling getTransactionRecordDocument(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecordDocument("trial", "test-transaction-guid", null));
        assertEquals("Missing the required parameter 'documentField' when calling getTransactionRecordDocument(Async)",
                e3.getMessage());
    }

    /* Test getTransactionRecordVerbose */

    @Test
    public void testGetTransactionRecordVerboseSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        JsonArray bodyInputFields = new JsonArray();
        JsonObject bodyInputFields0 = new JsonObject();
        bodyInputFields0.addProperty("FieldName", "FirstGivenName");
        bodyInputFields0.addProperty("Value", "Test");
        bodyInputFields.add(bodyInputFields0);
        body.add("InputFields", bodyInputFields);
        body.addProperty("UploadedDt", "2017-07-11T21:47:50.778124");
        JsonObject bodyRecord = new JsonObject();
        bodyRecord.addProperty("TransactionRecordID", "test-transaction-guid");
        bodyRecord.addProperty("RecordStatus", "match");
        JsonArray bodyRecordDatasourceResults = new JsonArray();
        JsonObject bodyRecordDatasourceResults0 = new JsonObject();
        bodyRecordDatasourceResults0.addProperty("DatasourceName", "Datasource");
        bodyRecordDatasourceResults0.add("DatasourceFields", new JsonArray());
        bodyRecordDatasourceResults0.add("AppendedFields", new JsonArray());
        bodyRecordDatasourceResults0.add("FieldGroups", new JsonArray());
        bodyRecordDatasourceResults.add(bodyRecordDatasourceResults0);
        bodyRecord.add("DatasourceResults", bodyRecordDatasourceResults);
        bodyRecord.add("Errors", new JsonArray());
        body.add("Record", bodyRecord);
        body.add("Errors", new JsonArray());

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        TransactionRecordResult expected = new TransactionRecordResult();
        expected.addInputFieldsItem(new DataField().fieldName("FirstGivenName").value("Test"));
        expected.setUploadedDt(
                OffsetDateTime.of(2017, 7, 11, 21, 47, 50, 778124000, ZoneOffset.UTC).truncatedTo(ChronoUnit.MICROS));
        Record expectedRecord = new Record().transactionRecordID("test-transaction-guid").recordStatus("match");
        DatasourceResult expectedRecordDatasourceResult0 = new DatasourceResult().datasourceName("Datasource");
        expectedRecordDatasourceResult0.setDatasourceFields(new ArrayList<DatasourceField>());
        expectedRecordDatasourceResult0.setAppendedFields(new ArrayList<AppendedField>());
        expectedRecordDatasourceResult0.setFieldGroups(new ArrayList<String>());
        expectedRecord.addDatasourceResultsItem(expectedRecordDatasourceResult0);
        expectedRecord.setErrors(new ArrayList<ServiceError>());
        expected.setRecord(expectedRecord);
        expected.setErrors(new ArrayList<ServiceError>());

        try {
            TransactionRecordResult result = verificationsApi.getTransactionRecordVerbose("trial",
                    "test-transaction-guid");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/verifications/v1/transactionrecord/test-transaction-guid/verbose HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            verificationsApi.getTransactionRecordVerboseAsync("trial", "test-transaction-guid",
                    new SuccessfulCallback<TransactionRecordResult>() {
                        public void onSuccess(TransactionRecordResult resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/verifications/v1/transactionrecord/test-transaction-guid/verbose HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetTransactionRecordVerboseUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecordVerbose("trial", "test-transaction-guid"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetTransactionRecordVerboseNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecordVerbose(null, "test-transaction-guid"));
        assertEquals("Missing the required parameter 'mode' when calling getTransactionRecordVerbose(Async)",
                e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionRecordVerbose("trial", null));
        assertEquals("Missing the required parameter 'id' when calling getTransactionRecordVerbose(Async)",
                e2.getMessage());
    }

    /* Test getTransactionStatus */

    @Test
    public void testGetTransactionStatusSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("TransactionId", "test-transaction-guid-1");
        body.addProperty("TransactionRecordId", "test-transaction-guid-2");
        body.addProperty("Status", "InProgress");
        body.addProperty("UploadedDt", "2017-07-11T21:47:50.778124");
        body.addProperty("IsTimedOut", false);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        TransactionStatus expected = new TransactionStatus();
        expected.setTransactionId("test-transaction-guid-1");
        expected.setTransactionRecordId("test-transaction-guid-2");
        expected.setStatus("InProgress");
        expected.setUploadedDt(
                OffsetDateTime.of(2017, 7, 11, 21, 47, 50, 778124000, ZoneOffset.UTC).truncatedTo(ChronoUnit.MICROS));
        expected.setIsTimedOut(false);

        try {
            TransactionStatus result = verificationsApi.getTransactionStatus("trial", "test-transaction-guid-1");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/verifications/v1/transaction/test-transaction-guid-1/status HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            verificationsApi.getTransactionStatusAsync("trial", "test-transaction-guid-1",
                    new SuccessfulCallback<TransactionStatus>() {
                        public void onSuccess(TransactionStatus resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/verifications/v1/transaction/test-transaction-guid-1/status HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetTransactionStatusUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionStatus("trial", "test-transaction-guid-1"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetTransactionStatusNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> verificationsApi.getTransactionStatus(null, "test-transaction-guid-1"));
        assertEquals("Missing the required parameter 'mode' when calling getTransactionStatus(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> verificationsApi.getTransactionStatus("trial", null));
        assertEquals("Missing the required parameter 'id' when calling getTransactionStatus(Async)", e2.getMessage());
    }

    /* Test verify */

    @Test
    public void testVerifySuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("TransactionID", "test-transaction-guid-1");
        body.addProperty("UploadedDt", "2017-07-11T21:47:50.778124");
        JsonObject bodyRecord = new JsonObject();
        bodyRecord.addProperty("TransactionRecordID", "test-transaction-guid-2");
        bodyRecord.addProperty("RecordStatus", "match");
        JsonArray bodyRecordDatasourceResults = new JsonArray();
        JsonObject bodyRecordDatasourceResults0 = new JsonObject();
        bodyRecordDatasourceResults0.addProperty("DatasourceName", "Datasource");
        JsonArray bodyRecordDatasourceResults0DatasourceFields = new JsonArray();
        JsonObject bodyRecordDatasourceResults0DatasourceFields0 = new JsonObject();
        bodyRecordDatasourceResults0DatasourceFields0.addProperty("FieldName", "FirstGivenName");
        bodyRecordDatasourceResults0DatasourceFields0.addProperty("Status", "match");
        bodyRecordDatasourceResults0DatasourceFields.add(bodyRecordDatasourceResults0DatasourceFields0);
        bodyRecordDatasourceResults0.add("DatasourceFields", bodyRecordDatasourceResults0DatasourceFields);
        bodyRecordDatasourceResults.add(bodyRecordDatasourceResults0);
        bodyRecord.add("DatasourceResults", bodyRecordDatasourceResults);
        bodyRecord.add("Errors", new JsonArray());
        body.add("Record", bodyRecord);
        body.addProperty("CustomerReferenceID", "ref-123");
        body.add("Errors", new JsonArray());

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        VerifyResult expected = new VerifyResult();
        expected.setTransactionID("test-transaction-guid-1");
        expected.setUploadedDt(
                OffsetDateTime.of(2017, 7, 11, 21, 47, 50, 778124000, ZoneOffset.UTC).truncatedTo(ChronoUnit.MICROS));
        Record expectedRecord = new Record().transactionRecordID("test-transaction-guid-2").recordStatus("match");
        DatasourceResult expectedRecordDatasourceResult0 = new DatasourceResult().datasourceName("Datasource");
        expectedRecordDatasourceResult0
                .addDatasourceFieldsItem(new DatasourceField().fieldName("FirstGivenName").status("match"));
        expectedRecord.addDatasourceResultsItem(expectedRecordDatasourceResult0);
        expectedRecord.setErrors(new ArrayList<ServiceError>());
        expected.setRecord(expectedRecord);
        expected.setCustomerReferenceID("ref-123");
        expected.setErrors(new ArrayList<ServiceError>());

        try {
            VerifyResult result = verificationsApi.verify("trial", new VerifyRequest());
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("POST /trial/verifications/v1/verify HTTP/1.1", request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            verificationsApi.verifyAsync("trial", new VerifyRequest(), new SuccessfulCallback<VerifyResult>() {
                public void onSuccess(VerifyResult resultAsync, int status, Map<String, List<String>> headers) {
                    assertEquals(expected, resultAsync);
                }
            });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("POST /trial/verifications/v1/verify HTTP/1.1", requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testVerifyUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class, () -> verificationsApi.verify("trial", new VerifyRequest()));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testVerifyNullParams() {
        ApiException e1 = assertThrows(ApiException.class, () -> verificationsApi.verify(null, new VerifyRequest()));
        assertEquals("Missing the required parameter 'mode' when calling verify(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> verificationsApi.verify("trial", null));
        assertEquals("Missing the required parameter 'verifyRequest' when calling verify(Async)", e2.getMessage());
    }
}
