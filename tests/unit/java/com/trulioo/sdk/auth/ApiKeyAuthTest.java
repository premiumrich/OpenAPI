package com.trulioo.sdk.auth;

import static org.junit.jupiter.api.Assertions.*;

import java.util.List;
import java.util.ArrayList;
import java.util.Map;
import java.util.HashMap;

import org.junit.jupiter.api.*;

import com.trulioo.sdk.Pair;

public class ApiKeyAuthTest {
    private ApiKeyAuth apiKeyAuth;

    @BeforeEach
    public void beforeEach() {
        apiKeyAuth = new ApiKeyAuth("location", "paramName");
    }

    @Test
    public void testLocation() {
        assertEquals("location", apiKeyAuth.getLocation());
    }

    @Test
    public void testParamName() {
        assertEquals("paramName", apiKeyAuth.getParamName());
    }

    @Test
    public void testApiKey() {
        apiKeyAuth.setApiKey("test-api-key");

        assertEquals("test-api-key", apiKeyAuth.getApiKey());
    }

    @Test
    public void testApiKeyPrefix() {
        apiKeyAuth.setApiKeyPrefix("Token");

        assertEquals("Token", apiKeyAuth.getApiKeyPrefix());
    }

    @Test
    public void testApplyToParamsNullApiKey() {
        List<Pair> queryParams = new ArrayList<Pair>();
        Map<String, String> headerParams = new HashMap<String, String>();
        Map<String, String> cookieParams = new HashMap<String, String>();
        apiKeyAuth.setApiKey(null);

        apiKeyAuth.applyToParams(null, null, null);

        assertEquals(0, queryParams.size());
        assertEquals(0, headerParams.size());
        assertEquals(0, cookieParams.size());
    }

    @Test
    public void testApplyToParamsQuery() {
        List<Pair> queryParams = new ArrayList<Pair>();
        apiKeyAuth = new ApiKeyAuth("query", "name");
        apiKeyAuth.setApiKey("test-api-key");

        apiKeyAuth.applyToParams(queryParams, null, null);

        assertEquals(1, queryParams.size());
        assertEquals("name", queryParams.get(0).getName());
        assertEquals("test-api-key", queryParams.get(0).getValue());
    }

    @Test
    public void testApplyToParamsQueryWithApiKeyPrefix() {
        List<Pair> queryParams = new ArrayList<Pair>();
        apiKeyAuth = new ApiKeyAuth("query", "name");
        apiKeyAuth.setApiKey("test-api-key");
        apiKeyAuth.setApiKeyPrefix("Token");

        apiKeyAuth.applyToParams(queryParams, null, null);

        assertEquals(1, queryParams.size());
        assertEquals("name", queryParams.get(0).getName());
        assertEquals("Token test-api-key", queryParams.get(0).getValue());
    }

    @Test
    public void testApplyToParamsHeader() {
        Map<String, String> headerParams = new HashMap<String, String>();
        apiKeyAuth = new ApiKeyAuth("header", "name");
        apiKeyAuth.setApiKey("test-api-key");

        apiKeyAuth.applyToParams(null, headerParams, null);

        assertEquals(1, headerParams.size());
        assertEquals("test-api-key", headerParams.get("name"));
    }

    @Test
    public void testApplyToParamsCookie() {
        Map<String, String> cookieParams = new HashMap<String, String>();
        apiKeyAuth = new ApiKeyAuth("cookie", "name");
        apiKeyAuth.setApiKey("test-api-key");

        apiKeyAuth.applyToParams(null, null, cookieParams);

        assertEquals(1, cookieParams.size());
        assertEquals("test-api-key", cookieParams.get("name"));
    }
}
