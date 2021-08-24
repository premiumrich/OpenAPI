package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class BusinessSearchRequestBusinessSearchModelTest {
    private BusinessSearchRequestBusinessSearchModel businessSearchRequestBusinessSearchModel;

    @BeforeEach
    public void beforeEach() {
        businessSearchRequestBusinessSearchModel = new BusinessSearchRequestBusinessSearchModel();
    }

    @Test
    public void testBusinessName() {
        String businessName = "name";
        businessSearchRequestBusinessSearchModel.setBusinessName(businessName);

        assertEquals(businessName, businessSearchRequestBusinessSearchModel.getBusinessName());
        assertEquals(businessName,
                new BusinessSearchRequestBusinessSearchModel().businessName(businessName).getBusinessName());
    }

    @Test
    public void testWebsite() {
        String website = "https://trulioo.com";
        businessSearchRequestBusinessSearchModel.setWebsite(website);

        assertEquals(website, businessSearchRequestBusinessSearchModel.getWebsite());
        assertEquals(website, new BusinessSearchRequestBusinessSearchModel().website(website).getWebsite());
    }

    @Test
    public void testJurisdictionOfIncorporation() {
        String jurisdictionOfIncorporation = "Alberta";
        businessSearchRequestBusinessSearchModel.setJurisdictionOfIncorporation(jurisdictionOfIncorporation);

        assertEquals(jurisdictionOfIncorporation,
                businessSearchRequestBusinessSearchModel.getJurisdictionOfIncorporation());
        assertEquals(jurisdictionOfIncorporation, new BusinessSearchRequestBusinessSearchModel()
                .jurisdictionOfIncorporation(jurisdictionOfIncorporation).getJurisdictionOfIncorporation());
    }

    @Test
    public void testDuNSNumber() {
        String duNSNumber = "123";
        businessSearchRequestBusinessSearchModel.setDuNSNumber(duNSNumber);

        assertEquals(duNSNumber, businessSearchRequestBusinessSearchModel.getDuNSNumber());
        assertEquals(duNSNumber, new BusinessSearchRequestBusinessSearchModel().duNSNumber(duNSNumber).getDuNSNumber());
    }

    @Test
    public void testLocation() {
        Location location = new Location().city("Shibuya");
        businessSearchRequestBusinessSearchModel.setLocation(location);

        assertEquals(location, businessSearchRequestBusinessSearchModel.getLocation());
        assertEquals(location, new BusinessSearchRequestBusinessSearchModel().location(location).getLocation());
    }

    @Test
    public void testEquals() {
        String businessName = "name";
        BusinessSearchRequestBusinessSearchModel businessSearchRequestBusinessSearchModel1 = new BusinessSearchRequestBusinessSearchModel()
                .businessName(businessName);

        assertEquals(businessSearchRequestBusinessSearchModel1, businessSearchRequestBusinessSearchModel1);
        assertEquals(businessSearchRequestBusinessSearchModel1,
                new BusinessSearchRequestBusinessSearchModel().businessName(businessName));
        assertNotEquals(businessSearchRequestBusinessSearchModel1,
                new BusinessSearchRequestBusinessSearchModel().businessName(businessName + "1"));
        assertNotEquals(businessSearchRequestBusinessSearchModel1, null);
    }

    @Test
    public void testHashcode() {
        String businessName = "name";

        assertEquals(new BusinessSearchRequestBusinessSearchModel().businessName(businessName).hashCode(),
                new BusinessSearchRequestBusinessSearchModel().businessName(businessName).hashCode());
    }

    @Test
    public void testToString() {
        String businessName = "name";

        assertEquals(new BusinessSearchRequestBusinessSearchModel().businessName(businessName).toString(),
                new BusinessSearchRequestBusinessSearchModel().businessName(businessName).toString());
    }
}
