package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class ResultTest {
    private Result result;

    @BeforeEach
    public void beforeEach() {
        result = new Result();
    }

    @Test
    public void testIndex() {
        String index = "1";
        result.setIndex(index);

        assertEquals(index, result.getIndex());
        assertEquals(index, new Result().index(index).getIndex());
    }

    @Test
    public void testBusinessName() {
        String businessName = "test";
        result.setBusinessName(businessName);

        assertEquals(businessName, result.getBusinessName());
        assertEquals(businessName, new Result().businessName(businessName).getBusinessName());
    }

    @Test
    public void testMatchingScore() {
        String matchingScore = "100%";
        result.setMatchingScore(matchingScore);

        assertEquals(matchingScore, result.getMatchingScore());
        assertEquals(matchingScore, new Result().matchingScore(matchingScore).getMatchingScore());
    }

    @Test
    public void testBusinessRegistrationNumber() {
        String businessRegistrationNumber = "123";
        result.setBusinessRegistrationNumber(businessRegistrationNumber);

        assertEquals(businessRegistrationNumber, result.getBusinessRegistrationNumber());
        assertEquals(businessRegistrationNumber,
                new Result().businessRegistrationNumber(businessRegistrationNumber).getBusinessRegistrationNumber());
    }

    @Test
    public void testDuNSNumber() {
        String duNSNumber = "123";
        result.setDuNSNumber(duNSNumber);

        assertEquals(duNSNumber, result.getDuNSNumber());
        assertEquals(duNSNumber, new Result().duNSNumber(duNSNumber).getDuNSNumber());
    }

    @Test
    public void testBusinessTaxIDNumber() {
        String businessTaxIDNumber = "123";
        result.setBusinessTaxIDNumber(businessTaxIDNumber);

        assertEquals(businessTaxIDNumber, result.getBusinessTaxIDNumber());
        assertEquals(businessTaxIDNumber,
                new Result().businessTaxIDNumber(businessTaxIDNumber).getBusinessTaxIDNumber());
    }

    @Test
    public void testBusinessLicenseNumber() {
        String businessLicenseNumber = "123";
        result.setBusinessLicenseNumber(businessLicenseNumber);

        assertEquals(businessLicenseNumber, result.getBusinessLicenseNumber());
        assertEquals(businessLicenseNumber,
                new Result().businessLicenseNumber(businessLicenseNumber).getBusinessLicenseNumber());
    }

    @Test
    public void testJurisdictionOfIncorporation() {
        String jurisdictionOfIncorporation = "Alberta";
        result.setJurisdictionOfIncorporation(jurisdictionOfIncorporation);

        assertEquals(jurisdictionOfIncorporation, result.getJurisdictionOfIncorporation());
        assertEquals(jurisdictionOfIncorporation,
                new Result().jurisdictionOfIncorporation(jurisdictionOfIncorporation).getJurisdictionOfIncorporation());
    }

    @Test
    public void testFullAddress() {
        String fullAddress = "123 Seasame St";
        result.setFullAddress(fullAddress);

        assertEquals(fullAddress, result.getFullAddress());
        assertEquals(fullAddress, new Result().fullAddress(fullAddress).getFullAddress());
    }

    @Test
    public void testBusinessStatus() {
        String businessStatus = "status";
        result.setBusinessStatus(businessStatus);

        assertEquals(businessStatus, result.getBusinessStatus());
        assertEquals(businessStatus, new Result().businessStatus(businessStatus).getBusinessStatus());
    }

    @Test
    public void testTradeStyleName() {
        String tradeStyleName = "name";
        result.setTradeStyleName(tradeStyleName);

        assertEquals(tradeStyleName, result.getTradeStyleName());
        assertEquals(tradeStyleName, new Result().tradeStyleName(tradeStyleName).getTradeStyleName());
    }

    @Test
    public void testBusinessType() {
        String businessType = "type";
        result.setBusinessType(businessType);

        assertEquals(businessType, result.getBusinessType());
        assertEquals(businessType, new Result().businessType(businessType).getBusinessType());
    }

    @Test
    public void testAddress() {
        Address address = new Address().buildingNumber("123");
        result.setAddress(address);

        assertEquals(address, result.getAddress());
        assertEquals(address, new Result().address(address).getAddress());
    }

    @Test
    public void testOtherBusinessNames() {
        result.addOtherBusinessNamesItem("abc");
        result.addOtherBusinessNamesItem("123");
        List<String> otherBusinessNames = Arrays.asList("other");
        result.setOtherBusinessNames(otherBusinessNames);

        assertEquals(otherBusinessNames, result.getOtherBusinessNames());
        assertEquals(otherBusinessNames, new Result().otherBusinessNames(otherBusinessNames).getOtherBusinessNames());
    }

    @Test
    public void testWebsite() {
        String website = "https://trulioo.com";
        result.setWebsite(website);

        assertEquals(website, result.getWebsite());
        assertEquals(website, new Result().website(website).getWebsite());
    }

    @Test
    public void testTelephone() {
        String telephone = "18887730179";
        result.setTelephone(telephone);

        assertEquals(telephone, result.getTelephone());
        assertEquals(telephone, new Result().telephone(telephone).getTelephone());
    }

    @Test
    public void testTaxIDNumber() {
        String taxIDNumber = "123";
        result.setTaxIDNumber(taxIDNumber);

        assertEquals(taxIDNumber, result.getTaxIDNumber());
        assertEquals(taxIDNumber, new Result().taxIDNumber(taxIDNumber).getTaxIDNumber());
    }

    @Test
    public void testTaxIDNumbers() {
        result.addTaxIDNumbersItem("123");
        result.addTaxIDNumbersItem("456");
        List<String> taxIDNumbers = Arrays.asList("789");
        result.setTaxIDNumbers(taxIDNumbers);

        assertEquals(taxIDNumbers, result.getTaxIDNumbers());
        assertEquals(taxIDNumbers, new Result().taxIDNumbers(taxIDNumbers).getTaxIDNumbers());
    }

    @Test
    public void testEmailAddress() {
        String emailAddress = "support@trulioo.com";
        result.setEmailAddress(emailAddress);

        assertEquals(emailAddress, result.getEmailAddress());
        assertEquals(emailAddress, new Result().emailAddress(emailAddress).getEmailAddress());
    }

    @Test
    public void testWebDomain() {
        String webDomain = "trulioo.com";
        result.setWebDomain(webDomain);

        assertEquals(webDomain, result.getWebDomain());
        assertEquals(webDomain, new Result().webDomain(webDomain).getWebDomain());
    }

    @Test
    public void testWebDomains() {
        result.addWebDomainsItem("google.com");
        result.addWebDomainsItem("amazon.com");
        List<String> webDomains = Arrays.asList("trulioo.com");
        result.setWebDomains(webDomains);

        assertEquals(webDomains, result.getWebDomains());
        assertEquals(webDomains, new Result().webDomains(webDomains).getWebDomains());
    }

    @Test
    public void testNAICS() {
        result.addNAICSItem(new BusinessSearchResponseIndustryCode());
        result.addNAICSItem(new BusinessSearchResponseIndustryCode());
        List<BusinessSearchResponseIndustryCode> NAICS = Arrays
                .asList(new BusinessSearchResponseIndustryCode().code("123"));
        result.setNAICS(NAICS);

        assertEquals(NAICS, result.getNAICS());
        assertEquals(NAICS, new Result().NAICS(NAICS).getNAICS());
    }

    @Test
    public void testSIC() {
        result.addSICItem(new BusinessSearchResponseIndustryCode());
        result.addSICItem(new BusinessSearchResponseIndustryCode());
        List<BusinessSearchResponseIndustryCode> SIC = Arrays
                .asList(new BusinessSearchResponseIndustryCode().code("123"));
        result.setSIC(SIC);

        assertEquals(SIC, result.getSIC());
        assertEquals(SIC, new Result().SIC(SIC).getSIC());
    }

    @Test
    public void testEquals() {
        String index = "1";
        Result result1 = new Result().index(index);

        assertEquals(result1, result1);
        assertEquals(result1, new Result().index(index));
        assertNotEquals(result1, new Result().index(index + "1"));
        assertNotEquals(result1, null);
    }

    @Test
    public void testHashcode() {
        String index = "1";

        assertEquals(new Result().index(index).hashCode(), new Result().index(index).hashCode());
    }

    @Test
    public void testToString() {
        String index = "1";

        assertEquals(new Result().index(index).toString(), new Result().index(index).toString());
    }
}
