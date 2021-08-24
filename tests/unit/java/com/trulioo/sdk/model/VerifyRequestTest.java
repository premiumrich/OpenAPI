package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class VerifyRequestTest {
    private VerifyRequest verifyRequest;

    @BeforeEach
    public void beforeEach() {
        verifyRequest = new VerifyRequest();
    }

    @Test
    public void testAcceptTruliooTermsAndConditions() {
        Boolean acceptTruliooTermsAndConditions = true;
        verifyRequest.setAcceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions);

        assertEquals(acceptTruliooTermsAndConditions, verifyRequest.getAcceptTruliooTermsAndConditions());
        assertEquals(acceptTruliooTermsAndConditions, new VerifyRequest()
                .acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions).getAcceptTruliooTermsAndConditions());
    }

    @Test
    public void testDemo() {
        Boolean demo = false;
        verifyRequest.setDemo(demo);

        assertEquals(demo, verifyRequest.getDemo());
        assertEquals(demo, new VerifyRequest().demo(demo).getDemo());
    }

    @Test
    public void testCallBackUrl() {
        String callBackUrl = "https://trulioo.com";
        verifyRequest.setCallBackUrl(callBackUrl);

        assertEquals(callBackUrl, verifyRequest.getCallBackUrl());
        assertEquals(callBackUrl, new VerifyRequest().callBackUrl(callBackUrl).getCallBackUrl());
    }

    @Test
    public void testTimeout() {
        Integer timeout = 3600;
        verifyRequest.setTimeout(timeout);

        assertEquals(timeout, verifyRequest.getTimeout());
        assertEquals(timeout, new VerifyRequest().timeout(timeout).getTimeout());
    }

    @Test
    public void testCleansedAddress() {
        Boolean cleansedAddress = false;
        verifyRequest.setCleansedAddress(cleansedAddress);

        assertEquals(cleansedAddress, verifyRequest.getCleansedAddress());
        assertEquals(cleansedAddress, new VerifyRequest().cleansedAddress(cleansedAddress).getCleansedAddress());
    }

    @Test
    public void testConfigurationName() {
        String configurationName = "Identity Verification";
        verifyRequest.setConfigurationName(configurationName);

        assertEquals(configurationName, verifyRequest.getConfigurationName());
        assertEquals(configurationName,
                new VerifyRequest().configurationName(configurationName).getConfigurationName());
    }

    @Test
    public void testConsentForDataSources() {
        verifyRequest.addConsentForDataSourcesItem("no");
        verifyRequest.addConsentForDataSourcesItem("no");
        List<String> consentForDataSources = Arrays.asList("yes");
        verifyRequest.setConsentForDataSources(consentForDataSources);

        assertEquals(consentForDataSources, verifyRequest.getConsentForDataSources());
        assertEquals(consentForDataSources,
                new VerifyRequest().consentForDataSources(consentForDataSources).getConsentForDataSources());
    }

    @Test
    public void testCountryCode() {
        String countryCode = "CA";
        verifyRequest.setCountryCode(countryCode);

        assertEquals(countryCode, verifyRequest.getCountryCode());
        assertEquals(countryCode, new VerifyRequest().countryCode(countryCode).getCountryCode());
    }

    @Test
    public void testCustomerReferenceID() {
        String customerReferenceID = "ref-123";
        verifyRequest.setCustomerReferenceID(customerReferenceID);

        assertEquals(customerReferenceID, verifyRequest.getCustomerReferenceID());
        assertEquals(customerReferenceID,
                new VerifyRequest().customerReferenceID(customerReferenceID).getCustomerReferenceID());
    }

    @Test
    public void testDataFields() {
        DataFields dataFields = new DataFields().personInfo(new PersonInfo().firstGivenName("A"));
        verifyRequest.setDataFields(dataFields);

        assertEquals(dataFields, verifyRequest.getDataFields());
        assertEquals(dataFields, new VerifyRequest().dataFields(dataFields).getDataFields());
    }

    @Test
    public void testVerboseMode() {
        Boolean verboseMode = false;
        verifyRequest.setVerboseMode(verboseMode);

        assertEquals(verboseMode, verifyRequest.getVerboseMode());
        assertEquals(verboseMode, new VerifyRequest().verboseMode(verboseMode).getVerboseMode());
    }

    @Test
    public void testEquals() {
        Boolean acceptTruliooTermsAndConditions = true;
        VerifyRequest verifyRequest1 = new VerifyRequest()
                .acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions);

        assertEquals(verifyRequest1, verifyRequest1);
        assertEquals(verifyRequest1,
                new VerifyRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions));
        assertNotEquals(verifyRequest1,
                new VerifyRequest().acceptTruliooTermsAndConditions(!acceptTruliooTermsAndConditions));
        assertNotEquals(verifyRequest1, null);
    }

    @Test
    public void testHashcode() {
        Boolean acceptTruliooTermsAndConditions = true;

        assertEquals(new VerifyRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions).hashCode(),
                new VerifyRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions).hashCode());
    }

    @Test
    public void testToString() {
        Boolean acceptTruliooTermsAndConditions = true;

        assertEquals(new VerifyRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions).toString(),
                new VerifyRequest().acceptTruliooTermsAndConditions(acceptTruliooTermsAndConditions).toString());
    }
}
