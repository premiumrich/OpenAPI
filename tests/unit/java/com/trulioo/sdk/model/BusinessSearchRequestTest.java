package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class BusinessSearchRequestTest {
    private BusinessSearchRequest businessSearchRequest;

    @BeforeEach
    public void beforeEach() {
        businessSearchRequest = new BusinessSearchRequest();
    }

    @Test
    public void testAcceptTruliooTermsAndConditions() {
        Boolean acceptTruliooTermsAndConditions = true;
        businessSearchRequest.setAcceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions);

        assertEquals(acceptTruliooTermsAndConditions, businessSearchRequest.getAcceptTruliooTermsAndConditions());
        assertEquals(acceptTruliooTermsAndConditions, new BusinessSearchRequest()
                .acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions).getAcceptTruliooTermsAndConditions());
    }

    @Test
    public void testCallBackUrl() {
        String callBackUrl = "https://trulioo.com";
        businessSearchRequest.setCallBackUrl(callBackUrl);

        assertEquals(callBackUrl, businessSearchRequest.getCallBackUrl());
        assertEquals(callBackUrl, new BusinessSearchRequest().callBackUrl(callBackUrl).getCallBackUrl());
    }

    @Test
    public void testTimeout() {
        Integer timeout = 3600;
        businessSearchRequest.setTimeout(timeout);

        assertEquals(timeout, businessSearchRequest.getTimeout());
        assertEquals(timeout, new BusinessSearchRequest().timeout(timeout).getTimeout());
    }

    @Test
    public void testConsentForDataSources() {
        businessSearchRequest.addConsentForDataSourcesItem("no");
        businessSearchRequest.addConsentForDataSourcesItem("no");
        List<String> consentForDataSources = Arrays.asList("yes");
        businessSearchRequest.setConsentForDataSources(consentForDataSources);

        assertEquals(consentForDataSources, businessSearchRequest.getConsentForDataSources());
        assertEquals(consentForDataSources,
                new BusinessSearchRequest().consentForDataSources(consentForDataSources).getConsentForDataSources());
    }

    @Test
    public void testBusiness() {
        BusinessSearchRequestBusinessSearchModel business = new BusinessSearchRequestBusinessSearchModel()
                .businessName("test");
        businessSearchRequest.setBusiness(business);

        assertEquals(business, businessSearchRequest.getBusiness());
        assertEquals(business, new BusinessSearchRequest().business(business).getBusiness());
    }

    @Test
    public void testCountryCode() {
        String countryCode = "CA";
        businessSearchRequest.setCountryCode(countryCode);

        assertEquals(countryCode, businessSearchRequest.getCountryCode());
        assertEquals(countryCode, new BusinessSearchRequest().countryCode(countryCode).getCountryCode());
    }

    @Test
    public void testEquals() {
        Boolean acceptTruliooTermsAndConditions = true;
        BusinessSearchRequest businessSearchRequest1 = new BusinessSearchRequest()
                .acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions);

        assertEquals(businessSearchRequest1, businessSearchRequest1);
        assertEquals(businessSearchRequest1,
                new BusinessSearchRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions));
        assertNotEquals(businessSearchRequest1,
                new BusinessSearchRequest().acceptTruliooTermsAndConditions(!acceptTruliooTermsAndConditions));
        assertNotEquals(businessSearchRequest1, null);
    }

    @Test
    public void testHashcode() {
        Boolean acceptTruliooTermsAndConditions = true;

        assertEquals(
                new BusinessSearchRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions).hashCode(),
                new BusinessSearchRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions)
                        .hashCode());
    }

    @Test
    public void testToString() {
        Boolean acceptTruliooTermsAndConditions = true;

        assertEquals(
                new BusinessSearchRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions).toString(),
                new BusinessSearchRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions)
                        .toString());
    }
}
