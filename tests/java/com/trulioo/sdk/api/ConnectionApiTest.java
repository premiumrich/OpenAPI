package com.trulioo.sdk.api;

import static org.junit.jupiter.api.Assertions.*;

import java.io.IOException;
import java.util.List;
import java.util.Map;

import org.junit.jupiter.api.*;
import okhttp3.mockwebserver.*;
import okhttp3.HttpUrl;
import com.google.gson.JsonObject;
import com.google.gson.internal.LinkedTreeMap;

import com.trulioo.sdk.ApiClient;
import com.trulioo.sdk.ApiException;
import com.trulioo.sdk.SuccessfulCallback;
import com.trulioo.sdk.auth.ApiKeyAuth;
import com.trulioo.sdk.model.TransactionStatus;

public class ConnectionApiTest {
    private MockWebServer server;
    private ConnectionApi connectionApi;

    /* Setup */

    @BeforeEach
    public void beforeEach() throws IOException {
        server = new MockWebServer();
        server.start();

        HttpUrl url = server.url("/");
        ApiClient apiClient = new ApiClient().setBasePath(url.scheme() + "://" + url.host() + ":" + url.port());

        ApiKeyAuth auth = (ApiKeyAuth) apiClient.getAuthentication("ApiKeyAuth");
        auth.setApiKey("test-api-key");

        connectionApi = new ConnectionApi(apiClient);
    }

    @AfterEach
    public void afterEach() throws IOException {
        server.shutdown();
    }

    /* Test constructor */

    @Test
    public void testConnectionApi() {
        connectionApi = new ConnectionApi();
        ApiClient apiClient = new ApiClient().setBasePath("https://abcd");
        connectionApi.setApiClient(apiClient);

        assertEquals(apiClient, connectionApi.getApiClient());
    }

    /* Test connectionAsyncCallbackUrl */

    @Test
    @SuppressWarnings("unchecked")
    public void testConnectionAsyncCallbackUrlSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        LinkedTreeMap<String, Object> expectedResult = new LinkedTreeMap<String, Object>();

        try {
            LinkedTreeMap<String, Object> result = (LinkedTreeMap<String, Object>) connectionApi
                    .connectionAsyncCallbackUrl("trial", new TransactionStatus());
            RecordedRequest request = server.takeRequest();

            assertEquals(expectedResult, result);
            assertEquals("POST /trial/connection/v1/async-callback HTTP/1.1", request.getRequestLine());
            assertEquals(null, request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            connectionApi.connectionAsyncCallbackUrlAsync("trial", new TransactionStatus(),
                    new SuccessfulCallback<Object>() {
                        public void onSuccess(Object resultAsync, int status, Map<String, List<String>> headers) {
                            assertEquals(expectedResult, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("POST /trial/connection/v1/async-callback HTTP/1.1", requestAsync.getRequestLine());
            assertEquals(null, requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testConnectionAsyncCallbackUrlServerError() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(500));

        ApiException e = assertThrows(ApiException.class,
                () -> connectionApi.connectionAsyncCallbackUrl("trial", new TransactionStatus()));
        assertEquals(500, e.getCode());
        assertEquals("Server Error", e.getMessage());
    }

    @Test
    public void testConnectionAsyncCallbackUrlNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> connectionApi.connectionAsyncCallbackUrl(null, new TransactionStatus()));
        assertEquals("Missing the required parameter 'mode' when calling connectionAsyncCallbackUrl(Async)",
                e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> connectionApi.connectionAsyncCallbackUrl("trial", null));
        assertEquals(
                "Missing the required parameter 'transactionStatus' when calling connectionAsyncCallbackUrl(Async)",
                e2.getMessage());
    }

    /* Test sayHello */

    @Test
    public void testSayHelloSuccess() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(200).setBody("Hello Trulioo User"));
        server.enqueue(new MockResponse().setResponseCode(200).setBody("Hello Trulioo User"));

        String expectedResult = "Hello Trulioo User";

        try {
            String result = connectionApi.sayHello("trial", "Trulioo User");
            RecordedRequest request = server.takeRequest();

            assertEquals(expectedResult, result);
            assertEquals("GET /trial/connection/v1/sayhello/Trulioo%20User HTTP/1.1", request.getRequestLine());
            assertEquals(null, request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            connectionApi.sayHelloAsync("trial", "Trulioo User", new SuccessfulCallback<String>() {
                public void onSuccess(String resultAsync, int status, Map<String, List<String>> headers) {
                    assertEquals(expectedResult, resultAsync);
                }
            });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/connection/v1/sayhello/Trulioo%20User HTTP/1.1", requestAsync.getRequestLine());
            assertEquals(null, requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testSayHelloServerError() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(500));

        ApiException e = assertThrows(ApiException.class, () -> connectionApi.sayHello("trial", "Trulioo User"));
        assertEquals(500, e.getCode());
        assertEquals("Server Error", e.getMessage());
    }

    @Test
    public void testSayHelloNullParams() {
        ApiException e1 = assertThrows(ApiException.class, () -> connectionApi.sayHello(null, "Trulioo User"));
        assertEquals("Missing the required parameter 'mode' when calling sayHello(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> connectionApi.sayHello("trial", null));
        assertEquals("Missing the required parameter 'name' when calling sayHello(Async)", e2.getMessage());
    }

    /* Test testAuthentication */

    @Test
    public void testTestAuthenticationSuccess() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(200).setBody("Hello Trulioo User"));
        server.enqueue(new MockResponse().setResponseCode(200).setBody("Hello Trulioo User"));

        String expectedResult = "Hello Trulioo User";

        try {
            String result = connectionApi.testAuthentication("trial");
            RecordedRequest request = server.takeRequest();

            assertEquals(expectedResult, result);
            assertEquals("GET /trial/connection/v1/testauthentication HTTP/1.1", request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            connectionApi.testAuthenticationAsync("trial", new SuccessfulCallback<String>() {
                public void onSuccess(String resultAsync, int status, Map<String, List<String>> headers) {
                    assertEquals(expectedResult, resultAsync);
                }
            });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/connection/v1/testauthentication HTTP/1.1", requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testTestAuthenticationUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class, () -> connectionApi.testAuthentication("trial"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testTestAuthenticationNullParams() {
        ApiException e1 = assertThrows(ApiException.class, () -> connectionApi.testAuthentication(null));
        assertEquals("Missing the required parameter 'mode' when calling testAuthentication(Async)", e1.getMessage());
    }
}
