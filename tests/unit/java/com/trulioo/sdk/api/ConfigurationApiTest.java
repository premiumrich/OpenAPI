package com.trulioo.sdk.api;

import static org.junit.jupiter.api.Assertions.*;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.HashMap;

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
import com.trulioo.sdk.model.BusinessRegistrationNumber;
import com.trulioo.sdk.model.Communication;
import com.trulioo.sdk.model.Consent;
import com.trulioo.sdk.model.CountrySubdivision;
import com.trulioo.sdk.model.Location;
import com.trulioo.sdk.model.NormalizedDatasourceGroupCountry;
import com.trulioo.sdk.model.PersonInfo;
import com.trulioo.sdk.model.TestEntityDataFields;

public class ConfigurationApiTest {
    private MockWebServer server;
    private ConfigurationApi configurationApi;

    /* Setup */

    @BeforeEach
    public void beforeEach() throws IOException {
        server = new MockWebServer();
        server.start();

        HttpUrl url = server.url("/");
        ApiClient apiClient = new ApiClient().setBasePath(url.scheme() + "://" + url.host() + ":" + url.port());

        ApiKeyAuth auth = (ApiKeyAuth) apiClient.getAuthentication("ApiKeyAuth");
        auth.setApiKey("test-api-key");

        configurationApi = new ConfigurationApi(apiClient);
    }

    @AfterEach
    public void afterEach() throws IOException {
        server.shutdown();
    }

    /* Test constructor */

    @Test
    public void testConfigurationApi() {
        configurationApi = new ConfigurationApi();
        ApiClient apiClient = new ApiClient().setBasePath("https://abcd");
        configurationApi.setApiClient(apiClient);

        assertEquals(apiClient, configurationApi.getApiClient());
    }

    /* Test getBusinessRegistrationNumbers */

    @Test
    public void testGetBusinessRegistrationNumbersSuccess() throws InterruptedException {
        JsonArray body = new JsonArray();
        JsonObject body0 = new JsonObject();
        body0.addProperty("Name", "test1");
        body.add(body0);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        List<BusinessRegistrationNumber> expected = Arrays.asList(new BusinessRegistrationNumber().name("test1"));

        try {
            List<BusinessRegistrationNumber> result = configurationApi.getBusinessRegistrationNumbers("trial", "US",
                    "CA");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/businessregistrationnumbers/US/CA HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getBusinessRegistrationNumbersAsync("trial", "US", "CA",
                    new SuccessfulCallback<List<BusinessRegistrationNumber>>() {
                        public void onSuccess(List<BusinessRegistrationNumber> resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/businessregistrationnumbers/US/CA HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetBusinessRegistrationNumbersUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> configurationApi.getBusinessRegistrationNumbers("trial", "US", "CA"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetBusinessRegistrationNumbersNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> configurationApi.getBusinessRegistrationNumbers(null, "US", "CA"));
        assertEquals("Missing the required parameter 'mode' when calling getBusinessRegistrationNumbers(Async)",
                e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> configurationApi.getBusinessRegistrationNumbers("trial", null, "CA"));
        assertEquals("Missing the required parameter 'countryCode' when calling getBusinessRegistrationNumbers(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> configurationApi.getBusinessRegistrationNumbers("trial", "US", null));
        assertEquals(
                "Missing the required parameter 'jurisdictionCode' when calling getBusinessRegistrationNumbers(Async)",
                e3.getMessage());
    }

    /* Test getConsents */

    @Test
    public void testGetConsentsSuccess() throws InterruptedException {
        JsonArray body = new JsonArray();
        body.add("California Driver's Licence");

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        List<String> expected = Arrays.asList("California Driver's Licence");

        try {
            List<String> result = configurationApi.getConsents("trial", "Identity Verification", "US");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/consents/Identity%20Verification/US HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getConsentsAsync("trial", "Identity Verification", "US",
                    new SuccessfulCallback<List<String>>() {
                        public void onSuccess(List<String> resultAsync, int status, Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/consents/Identity%20Verification/US HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetConsentsUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> configurationApi.getConsents("trial", "Identity Verification", "US"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetConsentsNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> configurationApi.getConsents(null, "Identity Verification", "US"));
        assertEquals("Missing the required parameter 'mode' when calling getConsents(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> configurationApi.getConsents("trial", null, "US"));
        assertEquals("Missing the required parameter 'configurationName' when calling getConsents(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> configurationApi.getConsents("trial", "Identity Verification", null));
        assertEquals("Missing the required parameter 'countryCode' when calling getConsents(Async)", e3.getMessage());
    }

    /* Test getCountryCodes */

    @Test
    public void testGetCountryCodesSuccess() throws InterruptedException {
        JsonArray body = new JsonArray();
        body.add("US");

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        List<String> expected = Arrays.asList("US");

        try {
            List<String> result = configurationApi.getCountryCodes("trial", "Identity Verification");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/countrycodes/Identity%20Verification HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getCountryCodesAsync("trial", "Identity Verification",
                    new SuccessfulCallback<List<String>>() {
                        public void onSuccess(List<String> resultAsync, int status, Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/countrycodes/Identity%20Verification HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetCountryCodesUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> configurationApi.getCountryCodes("trial", "Identity Verification"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetCountryCodesNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> configurationApi.getCountryCodes(null, "Identity Verification"));
        assertEquals("Missing the required parameter 'mode' when calling getCountryCodes(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> configurationApi.getCountryCodes("trial", null));
        assertEquals("Missing the required parameter 'configurationName' when calling getCountryCodes(Async)",
                e2.getMessage());
    }

    /* Test getCountrySubdivisions */

    @Test
    public void testGetCountrySubdivisionsSuccess() throws InterruptedException {
        JsonArray body = new JsonArray();
        JsonObject body0 = new JsonObject();
        body0.addProperty("Name", "California");
        body0.addProperty("Code", "US-CA");
        body0.addProperty("ParentCode", "US");
        body.add(body0);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        List<CountrySubdivision> expected = Arrays
                .asList(new CountrySubdivision().name("California").code("US-CA").parentCode("US"));

        try {
            List<CountrySubdivision> result = configurationApi.getCountrySubdivisions("trial", "US");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/countrysubdivisions/US HTTP/1.1", request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getCountrySubdivisionsAsync("trial", "US",
                    new SuccessfulCallback<List<CountrySubdivision>>() {
                        public void onSuccess(List<CountrySubdivision> resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/countrysubdivisions/US HTTP/1.1", requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetCountrySubdivisionsUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class, () -> configurationApi.getCountrySubdivisions("trial", "US"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetCountrySubdivisionsNullParams() {
        ApiException e1 = assertThrows(ApiException.class, () -> configurationApi.getCountrySubdivisions(null, "US"));
        assertEquals("Missing the required parameter 'mode' when calling getCountrySubdivisions(Async)",
                e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> configurationApi.getCountrySubdivisions("trial", null));
        assertEquals("Missing the required parameter 'countryCode' when calling getCountrySubdivisions(Async)",
                e2.getMessage());
    }

    /* Test getDatasources */

    @Test
    public void testGetDatasourcesSuccess() throws InterruptedException {
        JsonArray body = new JsonArray();
        JsonObject body0 = new JsonObject();
        body0.addProperty("Name", "Credit Agency");
        body0.addProperty("Description", "Test");
        body0.addProperty("Coverage", "25%");
        body.add(body0);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        List<NormalizedDatasourceGroupCountry> expected = Arrays.asList(
                new NormalizedDatasourceGroupCountry().name("Credit Agency").description("Test").coverage("25%"));

        try {
            List<NormalizedDatasourceGroupCountry> result = configurationApi.getDatasources("trial",
                    "Identity Verification", "US");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/datasources/Identity%20Verification/US HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getDatasourcesAsync("trial", "Identity Verification", "US",
                    new SuccessfulCallback<List<NormalizedDatasourceGroupCountry>>() {
                        public void onSuccess(List<NormalizedDatasourceGroupCountry> resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/datasources/Identity%20Verification/US HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetDatasourcesUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> configurationApi.getDatasources("trial", "Identity Verification", "US"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetDatasourcesNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> configurationApi.getDatasources(null, "Identity Verification", "US"));
        assertEquals("Missing the required parameter 'mode' when calling getDatasources(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> configurationApi.getDatasources("trial", null, "US"));
        assertEquals("Missing the required parameter 'configurationName' when calling getDatasources(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> configurationApi.getDatasources("trial", "Identity Verification", null));
        assertEquals("Missing the required parameter 'countryCode' when calling getDatasources(Async)",
                e3.getMessage());
    }

    /* Test getDetailedConsents */

    @Test
    public void testGetDetailedConsentsSuccess() throws InterruptedException {
        JsonArray body = new JsonArray();
        JsonObject body0 = new JsonObject();
        body0.addProperty("Name", "California Driver's License");
        body0.addProperty("Text", "Test");
        body.add(body0);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        List<Consent> expected = Arrays.asList(new Consent().name("California Driver's License").text("Test"));

        try {
            List<Consent> result = configurationApi.getDetailedConsents("trial", "Identity Verification", "US");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/detailedConsents/Identity%20Verification/US HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getDetailedConsentsAsync("trial", "Identity Verification", "US",
                    new SuccessfulCallback<List<Consent>>() {
                        public void onSuccess(List<Consent> resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/detailedConsents/Identity%20Verification/US HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetDetailedConsentsUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> configurationApi.getDetailedConsents("trial", "Identity Verification", "US"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetDetailedConsentsNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> configurationApi.getDetailedConsents(null, "Identity Verification", "US"));
        assertEquals("Missing the required parameter 'mode' when calling getDetailedConsents(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> configurationApi.getDetailedConsents("trial", null, "US"));
        assertEquals("Missing the required parameter 'configurationName' when calling getDetailedConsents(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> configurationApi.getDetailedConsents("trial", "Identity Verification", null));
        assertEquals("Missing the required parameter 'countryCode' when calling getDetailedConsents(Async)",
                e3.getMessage());
    }

    /* Test getDocumentTypes */

    @Test
    public void testGetDocumentTypesSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        JsonArray bodyUS = new JsonArray();
        bodyUS.add("Passport");
        body.add("US", bodyUS);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        Map<String, List<String>> expected = new HashMap<String, List<String>>();
        expected.put("US", Arrays.asList("Passport"));

        try {
            Map<String, List<String>> result = configurationApi.getDocumentTypes("trial", "US");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/documentTypes/US HTTP/1.1", request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getDocumentTypesAsync("trial", "US", new SuccessfulCallback<Map<String, List<String>>>() {
                public void onSuccess(Map<String, List<String>> resultAsync, int status,
                        Map<String, List<String>> headers) {
                    assertEquals(expected, resultAsync);
                }
            });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/documentTypes/US HTTP/1.1", requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetDocumentTypesUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class, () -> configurationApi.getDocumentTypes("trial", "US"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetDocumentTypesNullParams() {
        ApiException e1 = assertThrows(ApiException.class, () -> configurationApi.getDocumentTypes(null, "US"));
        assertEquals("Missing the required parameter 'mode' when calling getDocumentTypes(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> configurationApi.getDocumentTypes("trial", null));
        assertEquals("Missing the required parameter 'countryCode' when calling getDocumentTypes(Async)",
                e2.getMessage());
    }

    /* Test getFields */

    @Test
    @SuppressWarnings("unchecked")
    public void testGetFieldsSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("title", "DataFields");
        body.addProperty("type", "object");
        JsonObject bodyProperties = new JsonObject();
        bodyProperties.add("PersonInfo", new JsonObject());
        body.add("properties", bodyProperties);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        LinkedTreeMap<String, Object> expected = new LinkedTreeMap<String, Object>();
        expected.put("title", "DataFields");
        expected.put("type", "object");
        LinkedTreeMap<String, Object> expectedProperties = new LinkedTreeMap<String, Object>();
        expectedProperties.put("PersonInfo", new LinkedTreeMap<String, Object>());
        expected.put("properties", expectedProperties);

        try {
            LinkedTreeMap<String, Object> result = (LinkedTreeMap<String, Object>) configurationApi.getFields("trial",
                    "Identity Verification", "US");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/fields/Identity%20Verification/US HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getFieldsAsync("trial", "Identity Verification", "US", new SuccessfulCallback<Object>() {
                public void onSuccess(Object resultAsync, int status, Map<String, List<String>> headers) {
                    assertEquals(expected, resultAsync);
                }
            });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/fields/Identity%20Verification/US HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetFieldsUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> configurationApi.getFields("trial", "Identity Verification", "US"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetFieldsNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> configurationApi.getFields(null, "Identity Verification", "US"));
        assertEquals("Missing the required parameter 'mode' when calling getFields(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> configurationApi.getFields("trial", null, "US"));
        assertEquals("Missing the required parameter 'configurationName' when calling getFields(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> configurationApi.getFields("trial", "Identity Verification", null));
        assertEquals("Missing the required parameter 'countryCode' when calling getFields(Async)", e3.getMessage());
    }

    /* Test getRecommendedFields */

    @Test
    @SuppressWarnings("unchecked")
    public void testGetRecommendedFieldsSuccess() throws InterruptedException {
        JsonObject body = new JsonObject();
        body.addProperty("title", "DataFields");
        body.addProperty("type", "object");
        JsonObject bodyProperties = new JsonObject();
        bodyProperties.add("PersonInfo", new JsonObject());
        body.add("properties", bodyProperties);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        LinkedTreeMap<String, Object> expected = new LinkedTreeMap<String, Object>();
        expected.put("title", "DataFields");
        expected.put("type", "object");
        LinkedTreeMap<String, Object> expectedProperties = new LinkedTreeMap<String, Object>();
        expectedProperties.put("PersonInfo", new LinkedTreeMap<String, Object>());
        expected.put("properties", expectedProperties);

        try {
            LinkedTreeMap<String, Object> result = (LinkedTreeMap<String, Object>) configurationApi
                    .getRecommendedFields("trial", "Identity Verification", "US");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/recommendedfields/Identity%20Verification/US HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getRecommendedFieldsAsync("trial", "Identity Verification", "US",
                    new SuccessfulCallback<Object>() {
                        public void onSuccess(Object resultAsync, int status, Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/recommendedfields/Identity%20Verification/US HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetRecommendedFieldsUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> configurationApi.getRecommendedFields("trial", "Identity Verification", "US"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetRecommendedFieldsNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> configurationApi.getRecommendedFields(null, "Identity Verification", "US"));
        assertEquals("Missing the required parameter 'mode' when calling getRecommendedFields(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class,
                () -> configurationApi.getRecommendedFields("trial", null, "US"));
        assertEquals("Missing the required parameter 'configurationName' when calling getRecommendedFields(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> configurationApi.getRecommendedFields("trial", "Identity Verification", null));
        assertEquals("Missing the required parameter 'countryCode' when calling getRecommendedFields(Async)",
                e3.getMessage());
    }

    /* Test getTestEntities */

    @Test
    public void testGetTestEntitiesSuccess() throws InterruptedException {
        JsonArray body = new JsonArray();
        JsonObject body0 = new JsonObject();
        JsonObject body0PersonInfo = new JsonObject();
        body0PersonInfo.addProperty("FirstGivenName", "Test");
        body0.add("PersonInfo", body0PersonInfo);
        JsonObject body0Location = new JsonObject();
        body0Location.addProperty("BuildingNumber", "10");
        body0.add("Location", body0Location);
        JsonObject body0Communication = new JsonObject();
        body0Communication.addProperty("MobileNumber", "076310691");
        body0.add("Communication", body0Communication);
        body.add(body0);

        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));
        server.enqueue(new MockResponse().setResponseCode(200).setBody(body.toString()));

        TestEntityDataFields testEntityDataFields0 = new TestEntityDataFields();
        testEntityDataFields0.setPersonInfo(new PersonInfo().firstGivenName("Test"));
        testEntityDataFields0.setLocation(new Location().buildingNumber("10"));
        testEntityDataFields0.setCommunication(new Communication().mobileNumber("076310691"));
        List<TestEntityDataFields> expected = Arrays.asList(testEntityDataFields0);

        try {
            List<TestEntityDataFields> result = configurationApi.getTestEntities("trial", "Identity Verification",
                    "US");
            RecordedRequest request = server.takeRequest();

            assertEquals(expected, result);
            assertEquals("GET /trial/configuration/v1/testentities/Identity%20Verification/US HTTP/1.1",
                    request.getRequestLine());
            assertEquals("test-api-key", request.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }

        try {
            configurationApi.getTestEntitiesAsync("trial", "Identity Verification", "US",
                    new SuccessfulCallback<List<TestEntityDataFields>>() {
                        public void onSuccess(List<TestEntityDataFields> resultAsync, int status,
                                Map<String, List<String>> headers) {
                            assertEquals(expected, resultAsync);
                        }
                    });
            RecordedRequest requestAsync = server.takeRequest();

            assertEquals("GET /trial/configuration/v1/testentities/Identity%20Verification/US HTTP/1.1",
                    requestAsync.getRequestLine());
            assertEquals("test-api-key", requestAsync.getHeaders().get("x-trulioo-api-key"));
        } catch (ApiException e) {
            fail("Unexpected ApiException");
        }
    }

    @Test
    public void testGetTestEntitiesUnauthorized() throws InterruptedException {
        server.enqueue(new MockResponse().setResponseCode(401));

        ApiException e = assertThrows(ApiException.class,
                () -> configurationApi.getTestEntities("trial", "Identity Verification", "US"));
        assertEquals(401, e.getCode());
        assertEquals("Client Error", e.getMessage());
    }

    @Test
    public void testGetTestEntitiesNullParams() {
        ApiException e1 = assertThrows(ApiException.class,
                () -> configurationApi.getTestEntities(null, "Identity Verification", "US"));
        assertEquals("Missing the required parameter 'mode' when calling getTestEntities(Async)", e1.getMessage());

        ApiException e2 = assertThrows(ApiException.class, () -> configurationApi.getTestEntities("trial", null, "US"));
        assertEquals("Missing the required parameter 'configurationName' when calling getTestEntities(Async)",
                e2.getMessage());

        ApiException e3 = assertThrows(ApiException.class,
                () -> configurationApi.getTestEntities("trial", "Identity Verification", null));
        assertEquals("Missing the required parameter 'countryCode' when calling getTestEntities(Async)",
                e3.getMessage());
    }
}
