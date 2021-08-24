package com.trulioo.sdk.api;

import static org.junit.jupiter.api.Assertions.*;

import java.io.IOException;
import java.time.OffsetDateTime;
import java.time.ZoneOffset;
import java.time.temporal.ChronoUnit;
import java.util.List;
import java.util.ArrayList;
import java.util.Map;

import org.junit.jupiter.api.*;
import okhttp3.mockwebserver.*;
import okhttp3.HttpUrl;
import com.google.gson.JsonObject;
import com.google.gson.JsonArray;

import com.trulioo.sdk.ApiClient;
import com.trulioo.sdk.ApiException;
import com.trulioo.sdk.SuccessfulCallback;
import com.trulioo.sdk.auth.ApiKeyAuth;
import com.trulioo.sdk.model.BusinessSearchRequest;
import com.trulioo.sdk.model.BusinessSearchResponse;
import com.trulioo.sdk.model.BusinessRecord;
import com.trulioo.sdk.model.BusinessResult;
import com.trulioo.sdk.model.Result;
import com.trulioo.sdk.model.ServiceError;

public class BusinessApiTest {
    private MockWebServer server;
    private BusinessApi businessApi;

    /* Setup */

    @BeforeEach
    public void beforeEach() throws IOException {
        server = new MockWebServer();
        server.start();

        HttpUrl url = server.url("/");
        ApiClient apiClient = new ApiClient().setBasePath(url.scheme() + "://" + url.host() + ":" + url.port());

        ApiKeyAuth auth = (ApiKeyAuth) apiClient.getAuthentication("ApiKeyAuth");
        auth.setApiKey("test-api-key");

        businessApi = new BusinessApi(apiClient);
    }

    @AfterEach
    public void afterEach() throws IOException {
        server.shutdown();
    }

    /* Test constructor */

    @Test
    public void testBusinessApi() {
        businessApi = new BusinessApi();
        ApiClient apiClient = new ApiClient().setBasePath("https://abcd");
        businessApi.setApiClient(apiClient);

        assertEquals(apiClient, businessApi.getApiClient());
    }

    /* Test getBusinessSearchResult */

    @Test
    public void testGetBusinessSearchResultSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("TransactionID", "test-transaction-guid");
        JsonObject bodyRecord = new JsonObject();
        bodyRecord.addProperty("RecordStatus", "match");
        body.add("Record", bodyRecord);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        BusinessSearchResponse expectedResult = new BusinessSearchResponse().transactionID("test-transaction-guid")
                .record(new BusinessRecord().recordStatus("match"));

        try {
            BusinessSearchResponse result = businessApi.getBusinessSearchResult("trial", "test-transaction-guid");
            RecordedRequest request = server.takeRequest();

            assertEquals(expectedResult, result);
            assertEquals("GET /trial/business/v1/search/transactionrecord/test-transaction-guid HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            businessApi.getBusinessSearchResultAsync("trial", "test-transaction-guid",
                    new SuccessfulCallback<BusinessSearchResponse>() {
                        public void onSuccess(BusinessSearchResponse resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expectedResult, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/business/v1/search/transactionrecord/test-transaction-guid HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetBusinessSearchResultUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> businessApi.getBusinessSearchResult("trial", "test-transaction-guid"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetBusinessSearchResultNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> businessApi.getBusinessSearchResult(null, "test-transaction-guid"));
        assertEquals("Missing the required parameter 'mode' when calling getBusinessSearchResult(Async)",
                e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> businessApi.getBusinessSearchResult("trial", null));
        assertEquals("Missing the required parameter 'id' when calling getBusinessSearchResult(Async)",
                e2.getMessage());
    }

    /* Test search */

    @Test
    public void testSearchSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("TransactionID", "test-transaction-guid-1");
        body.addProperty("UploadedDt", "2017-07-11T21:47:50.778124");
        body.addProperty("ProductName", "Business Search");
        JsonObject bodyRecord = new JsonObject();
        JsonArray bodyRecordDatasourceResults = new JsonArray();
        JsonObject bodyRecordDatasourceResults0 = new JsonObject();
        bodyRecordDatasourceResults0.addProperty("DatasourceName", "Datasource");
        JsonArray bodyRecordDatasourceResults0Results = new JsonArray();
        JsonObject bodyRecordDatasourceResults0Results0 = new JsonObject();
        bodyRecordDatasourceResults0Results0.addProperty("BusinessName", "test");
        bodyRecordDatasourceResults0Results0.addProperty("MatchingScore", "1");
        bodyRecordDatasourceResults0Results.add(bodyRecordDatasourceResults0Results0);
        bodyRecordDatasourceResults0.add("Results", bodyRecordDatasourceResults0Results);
        bodyRecordDatasourceResults.add(bodyRecordDatasourceResults0);
        bodyRecord.add("DatasourceResults", bodyRecordDatasourceResults);
        bodyRecord.add("Errors", new JsonArray());
        body.add("Record", bodyRecord);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        BusinessSearchResponse expected = new BusinessSearchResponse();
        expected.setTransactionID("test-transaction-guid-1");
        expected.setUploadedDt(
                OffsetDateTime.of(2017, 7, 11, 21, 47, 50, 778124000, ZoneOffset.UTC).truncatedTo(ChronoUnit.MICROS));
        expected.setProductName("Business Search");
        BusinessRecord expectedRecord = new BusinessRecord();
        BusinessResult expectedRecordResult0 = new BusinessResult().datasourceName("Datasource");
        expectedRecordResult0.addResultsItem(new Result().businessName("test").matchingScore("1"));
        expectedRecord.addDatasourceResultsItem(expectedRecordResult0);
        expectedRecord.setErrors(new ArrayList<ServiceError>());
        expected.setRecord(expectedRecord);

        try {
            BusinessSearchResponse result = businessApi.search("trial", new BusinessSearchRequest());
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("POST /trial/business/v1/search HTTP/1.1", request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            businessApi.searchAsync("trial", new BusinessSearchRequest(),
                    new SuccessfulCallback<BusinessSearchResponse>() {
                        public void onSuccess(BusinessSearchResponse resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("POST /trial/business/v1/search HTTP/1.1", requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testSearchUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> businessApi.search("trial", new BusinessSearchRequest()));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testSearchNullParams() {
        ApiException e1 = assertThrows(ApiException.class, () -> businessApi.search(null, new BusinessSearchRequest()));
        assertEquals("Missing the required parameter 'mode' when calling search(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> businessApi.search("trial", null));
        assertEquals("Missing the required parameter 'businessSearchRequest' when calling search(Async)",
                e2.getMessage());
    }
}
