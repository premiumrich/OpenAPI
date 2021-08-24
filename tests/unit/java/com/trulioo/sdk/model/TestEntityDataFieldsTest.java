package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;
import java.util.Map;
import java.util.HashMap;

public class TestEntityDataFieldsTest {
    private TestEntityDataFields testEntityDataFields;

    @BeforeEach
    public void beforeEach() {
        testEntityDataFields = new TestEntityDataFields();
    }

    @Test
    public void testLocation() {
        Location location = new Location().city("Shibuya");
        testEntityDataFields.setLocation(location);

        assertEquals(location, testEntityDataFields.getLocation());
        assertEquals(location, new TestEntityDataFields().location(location).getLocation());
    }

    @Test
    public void testTestEntityName() {
        String testEntityName = "test";
        testEntityDataFields.setTestEntityName(testEntityName);

        assertEquals(testEntityName, testEntityDataFields.getTestEntityName());
        assertEquals(testEntityName, new TestEntityDataFields().testEntityName(testEntityName).getTestEntityName());
    }

    @Test
    public void testPersonInfo() {
        PersonInfo personInfo = new PersonInfo().firstGivenName("test");
        testEntityDataFields.setPersonInfo(personInfo);

        assertEquals(personInfo, testEntityDataFields.getPersonInfo());
        assertEquals(personInfo, new TestEntityDataFields().personInfo(personInfo).getPersonInfo());
    }

    @Test
    public void testCommunication() {
        Communication communication = new Communication().emailAddress("support@trulioo.com");
        testEntityDataFields.setCommunication(communication);

        assertEquals(communication, testEntityDataFields.getCommunication());
        assertEquals(communication, new TestEntityDataFields().communication(communication).getCommunication());
    }

    @Test
    public void testDriverLicence() {
        DriverLicence driverLicence = new DriverLicence().number("123");
        testEntityDataFields.setDriverLicence(driverLicence);

        assertEquals(driverLicence, testEntityDataFields.getDriverLicence());
        assertEquals(driverLicence, new TestEntityDataFields().driverLicence(driverLicence).getDriverLicence());
    }

    @Test
    public void testNationalIds() {
        testEntityDataFields.addNationalIdsItem(new NationalId());
        testEntityDataFields.addNationalIdsItem(new NationalId());
        List<NationalId> nationalIds = Arrays.asList(new NationalId().number("123"));
        testEntityDataFields.setNationalIds(nationalIds);

        assertEquals(nationalIds, testEntityDataFields.getNationalIds());
        assertEquals(nationalIds, new TestEntityDataFields().nationalIds(nationalIds).getNationalIds());
    }

    @Test
    public void testPassport() {
        Passport passport = new Passport().mrz1("<<test>>");
        testEntityDataFields.setPassport(passport);

        assertEquals(passport, testEntityDataFields.getPassport());
        assertEquals(passport, new TestEntityDataFields().passport(passport).getPassport());
    }

    @Test
    public void testDocument() {
        Document document = new Document().documentType("NationalId");
        testEntityDataFields.setDocument(document);

        assertEquals(document, testEntityDataFields.getDocument());
        assertEquals(document, new TestEntityDataFields().document(document).getDocument());
    }

    @Test
    public void testBusiness() {
        Business business = new Business().businessName("test");
        testEntityDataFields.setBusiness(business);

        assertEquals(business, testEntityDataFields.getBusiness());
        assertEquals(business, new TestEntityDataFields().business(business).getBusiness());
    }

    @Test
    public void testCountrySpecific() {
        testEntityDataFields.putCountrySpecificItem("a", new HashMap<String, String>());
        Map<String, Map<String, String>> countrySpecific = new HashMap<String, Map<String, String>>() {
            {
                put("country_code", new HashMap<String, String>() {
                    {
                        put("field", "value");
                    }
                });
            }
        };
        testEntityDataFields.setCountrySpecific(countrySpecific);
        testEntityDataFields.putCountrySpecificItem("b", new HashMap<String, String>());

        assertEquals(countrySpecific, testEntityDataFields.getCountrySpecific());
        assertEquals(countrySpecific, new TestEntityDataFields().countrySpecific(countrySpecific).getCountrySpecific());
    }

    @Test
    public void testEquals() {
        Location location = new Location().city("Shibuya");
        TestEntityDataFields testEntityDataFields1 = new TestEntityDataFields().location(location);

        assertEquals(testEntityDataFields1, testEntityDataFields1);
        assertEquals(testEntityDataFields1, new TestEntityDataFields().location(location));
        assertNotEquals(testEntityDataFields1, new TestEntityDataFields().location(new Location().city("different")));
        assertNotEquals(testEntityDataFields1, null);
    }

    @Test
    public void testHashcode() {
        Location location = new Location().city("Shibuya");

        assertEquals(new TestEntityDataFields().location(location).hashCode(),
                new TestEntityDataFields().location(location).hashCode());
    }

    @Test
    public void testToString() {
        Location location = new Location().city("Shibuya");

        assertEquals(new TestEntityDataFields().location(location).toString(),
                new TestEntityDataFields().location(location).toString());
    }
}
