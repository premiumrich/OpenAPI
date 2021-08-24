package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class BusinessTest {
    private Business business;

    @BeforeEach
    public void beforeEach() {
        business = new Business();
    }

    @Test
    public void testBusinessName() {
        String businessName = "test";
        business.setBusinessName(businessName);

        assertEquals(businessName, business.getBusinessName());
        assertEquals(businessName, new Business().businessName(businessName).getBusinessName());
    }

    @Test
    public void testBusinessRegistrationNumber() {
        String businessRegistrationNumber = "123";
        business.setBusinessRegistrationNumber(businessRegistrationNumber);

        assertEquals(businessRegistrationNumber, business.getBusinessRegistrationNumber());
        assertEquals(businessRegistrationNumber,
                new Business().businessRegistrationNumber(businessRegistrationNumber).getBusinessRegistrationNumber());
    }

    @Test
    public void testDayOfIncorporation() {
        Integer dayOfIncorporation = 15;
        business.setDayOfIncorporation(dayOfIncorporation);

        assertEquals(dayOfIncorporation, business.getDayOfIncorporation());
        assertEquals(dayOfIncorporation, new Business().dayOfIncorporation(dayOfIncorporation).getDayOfIncorporation());
    }

    @Test
    public void testMonthOfIncorporation() {
        Integer monthOfIncorporation = 9;
        business.setMonthOfIncorporation(monthOfIncorporation);

        assertEquals(monthOfIncorporation, business.getMonthOfIncorporation());
        assertEquals(monthOfIncorporation,
                new Business().monthOfIncorporation(monthOfIncorporation).getMonthOfIncorporation());
    }

    @Test
    public void testYearOfIncorporation() {
        Integer yearOfIncorporation = 2020;
        business.setYearOfIncorporation(yearOfIncorporation);

        assertEquals(yearOfIncorporation, business.getYearOfIncorporation());
        assertEquals(yearOfIncorporation,
                new Business().yearOfIncorporation(yearOfIncorporation).getYearOfIncorporation());
    }

    @Test
    public void testJurisdictionOfIncorporation() {
        String jurisdictionOfIncorporation = "Alberta";
        business.setJurisdictionOfIncorporation(jurisdictionOfIncorporation);

        assertEquals(jurisdictionOfIncorporation, business.getJurisdictionOfIncorporation());
        assertEquals(jurisdictionOfIncorporation, new Business()
                .jurisdictionOfIncorporation(jurisdictionOfIncorporation).getJurisdictionOfIncorporation());
    }

    @Test
    public void testShareholderListDocument() {
        Boolean shareholderListDocument = true;
        business.setShareholderListDocument(shareholderListDocument);

        assertEquals(shareholderListDocument, business.getShareholderListDocument());
        assertEquals(shareholderListDocument,
                new Business().shareholderListDocument(shareholderListDocument).getShareholderListDocument());
    }

    @Test
    public void testFinancialInformationDocument() {
        Boolean financialInformationDocument = false;
        business.setFinancialInformationDocument(financialInformationDocument);

        assertEquals(financialInformationDocument, business.getFinancialInformationDocument());
        assertEquals(financialInformationDocument, new Business()
                .financialInformationDocument(financialInformationDocument).getFinancialInformationDocument());
    }

    @Test
    public void testDunsNumber() {
        String dunsNumber = "123";
        business.setDunsNumber(dunsNumber);

        assertEquals(dunsNumber, business.getDunsNumber());
        assertEquals(dunsNumber, new Business().dunsNumber(dunsNumber).getDunsNumber());
    }

    @Test
    public void testEntities() {
        Boolean entities = true;
        business.setEntities(entities);

        assertEquals(entities, business.getEntities());
        assertEquals(entities, new Business().entities(entities).getEntities());
    }

    @Test
    public void testEquals() {
        String businessName = "test";
        Business business1 = new Business().businessName(businessName);

        assertEquals(business1, business1);
        assertEquals(business1, new Business().businessName(businessName));
        assertNotEquals(business1, new Business().businessName(businessName + "1"));
        assertNotEquals(business1, null);
    }

    @Test
    public void testHashcode() {
        String businessName = "test";

        assertEquals(new Business().businessName(businessName).hashCode(),
                new Business().businessName(businessName).hashCode());
    }

    @Test
    public void testToString() {
        String businessName = "test";

        assertEquals(new Business().businessName(businessName).toString(),
                new Business().businessName(businessName).toString());
    }
}
