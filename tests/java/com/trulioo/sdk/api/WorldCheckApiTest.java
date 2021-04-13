package com.trulioo.sdk.api;

import static org.junit.jupiter.api.Assertions.*;

import java.io.IOException;
import java.util.List;
import java.util.Map;

import org.junit.jupiter.api.*;
import okhttp3.mockwebserver.*;
import okhttp3.HttpUrl;
import com.google.gson.JsonObject;

import com.trulioo.sdk.ApiClient;
import com.trulioo.sdk.SuccessfulCallback;
import com.trulioo.sdk.auth.ApiKeyAuth;
import com.trulioo.sdk.ApiException;
import com.google.gson.internal.LinkedTreeMap;

public class WorldCheckApiTest {
    private MockWebServer server;
    private WorldCheckApi worldCheckApi;

    /* Setup */

    @BeforeEach
    public void beforeEach() throws IOException {
        server = new MockWebServer();
        server.start();

        HttpUrl url = server.url("/");
        ApiClient apiClient = new ApiClient().setBasePath(url.scheme() + "://" + url.host() + ":" + url.port());

        ApiKeyAuth auth = (ApiKeyAuth) apiClient.getAuthentication("ApiKeyAuth");
        auth.setApiKey("test-api-key");

        worldCheckApi = new WorldCheckApi(apiClient);
    }

    @AfterEach
    public void afterEach() throws IOException {
        server.shutdown();
    }

    /* Test constructor */

    @Test
    public void testWorldCheckApi() {
        worldCheckApi = new WorldCheckApi();
        ApiClient apiClient = new ApiClient().setBasePath("https://abcd");
        worldCheckApi.setApiClient(apiClient);

        assertEquals(apiClient, worldCheckApi.getApiClient());
    }

    /* Test getWorldCheckProfile */

    @Test
    @SuppressWarnings("unchecked")
    public void testGetWorldCheckProfileSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("content", "test");

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        LinkedTreeMap<String, Object> expectedResult = new LinkedTreeMap<String, Object>();
        expectedResult.put("content", "test");

        try {
            LinkedTreeMap<String, Object> result = (LinkedTreeMap<String, Object>) worldCheckApi
                    .getWorldCheckProfile("trial", "test-transaction-guid", "ref-123");
            RecordedRequest request = server.takeRequest();

            assertEquals(expectedResult, result);
            assertEquals("GET /trial/worldcheck/v1/profile/test-transaction-guid/ref-123 HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            worldCheckApi.getWorldCheckProfileAsync("trial", "test-transaction-guid", "ref-123",
                    new SuccessfulCallback<Object>() {
                        public void onSuccess(Object resultAsync, int status, Map<String, List<String>> headers) {
                            assertEquals(expectedResult, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/worldcheck/v1/profile/test-transaction-guid/ref-123 HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetWorldCheckProfileUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> worldCheckApi.getWorldCheckProfile("trial", "test-transaction-guid", "ref-123"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetWorldCheckProfileNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> worldCheckApi.getWorldCheckProfile(null, "test-transaction-guid", "ref-123"));
        assertEquals("Missing the required parameter 'mode' when calling getWorldCheckProfile(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> worldCheckApi.getWorldCheckProfile("trial", null, "ref-123"));
        assertEquals("Missing the required parameter 'originalTransactionID' when calling getWorldCheckProfile(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> worldCheckApi.getWorldCheckProfile("trial", "test-transaction-guid", null));
        assertEquals("Missing the required parameter 'referenceID' when calling getWorldCheckProfile(Async)",
                e3.getMessage());
    }
}
