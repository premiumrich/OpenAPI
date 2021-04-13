package com.trulioo.sdk.api;

import static org.junit.Assert.assertThrows;
import static org.junit.jupiter.api.Assertions.*;

import java.io.IOException;
import java.util.Map;
import java.util.HashMap;
import java.util.List;

import org.junit.jupiter.api.*;
import okhttp3.mockwebserver.*;
import okhttp3.HttpUrl;
import com.google.gson.JsonObject;

import com.trulioo.sdk.ApiClient;
import com.trulioo.sdk.ApiException;
import com.trulioo.sdk.SuccessfulCallback;
import com.trulioo.sdk.auth.ApiKeyAuth;

public class CommonApiTest {
    private MockWebServer server;
    private CommonApi commonApi;

    /* Setup */

    @BeforeEach
    public void beforeEach() throws IOException {
        server = new MockWebServer();
        server.start();

        HttpUrl url = server.url("/");
        ApiClient apiClient = new ApiClient().setBasePath(url.scheme() + "://" + url.host() + ":" + url.port());

        ApiKeyAuth auth = (ApiKeyAuth) apiClient.getAuthentication("ApiKeyAuth");
        auth.setApiKey("test-api-key");

        commonApi = new CommonApi(apiClient);
    }

    @AfterEach
    public void afterEach() throws IOException {
        server.shutdown();
    }

    /* Test constructor */

    @Test
    public void testCommonApi() {
        commonApi = new CommonApi();
        ApiClient apiClient = new ApiClient().setBasePath("https://abcd");
        commonApi.setApiClient(apiClient);

        assertEquals(apiClient, commonApi.getApiClient());
    }

    /* Test commonIpInfo */

    @Test
    public void testCommonIpInfoSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("IP", "0.0.0.0");

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        Map<String, String> expectedResult = new HashMap<String, String>();
        expectedResult.put("IP", "0.0.0.0");

        try {
            Map<String, String> result = commonApi.commonIpInfo("trial");
            RecordedRequest request = server.takeRequest();

            assertEquals(expectedResult, result);
            assertEquals("GET /trial/common/v1/ip-info HTTP/1.1", request.getRequestLine());
            assertEquals(null, request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            commonApi.commonIpInfoAsync("trial", new SuccessfulCallback<Map<String, String>>() {
                public void onSuccess(Map<String, String> resultAsync, int status, Map<String, List<String>> headers) {
                    assertEquals(expectedResult, resultAsync);
                }
            });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/common/v1/ip-info HTTP/1.1", requestAsync.getRequestLine());
            assertEquals(null, requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testCommonIpInfoServerError() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(500));

        ApiException e = assertThrows(ApiException.class, () -> commonApi.commonIpInfo("trial"));
        assertEquals(500, e.getCode());
        assertEquals("Server Error", e.getMessage());
    }

    @Test
    public void testCommonIpInfoNullParams() {
        ApiException e1 = assertThrows(ApiException.class, () -> commonApi.commonIpInfo(null));
        assertEquals("Missing the required parameter 'mode' when calling commonIpInfo(Async)", e1.getMessage());
    }
}
