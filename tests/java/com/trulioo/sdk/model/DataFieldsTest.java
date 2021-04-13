package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;
import java.util.Map;
import java.util.HashMap;

public class DataFieldsTest {
    private DataFields dataFields;

    @BeforeEach
    public void beforeEach() {
        dataFields = new DataFields();
    }

    @Test
    public void testPersonInfo() {
        PersonInfo personInfo = new PersonInfo().firstGivenName("test");
        dataFields.setPersonInfo(personInfo);

        assertEquals(personInfo, dataFields.getPersonInfo());
        assertEquals(personInfo, new DataFields().personInfo(personInfo).getPersonInfo());
    }

    @Test
    public void testLocation() {
        Location location = new Location().city("Shibuya");
        dataFields.setLocation(location);

        assertEquals(location, dataFields.getLocation());
        assertEquals(location, new DataFields().location(location).getLocation());
    }

    @Test
    public void testCommunication() {
        Communication communication = new Communication().emailAddress("support@trulioo.com");
        dataFields.setCommunication(communication);

        assertEquals(communication, dataFields.getCommunication());
        assertEquals(communication, new DataFields().communication(communication).getCommunication());
    }

    @Test
    public void testDriverLicence() {
        DriverLicence driverLicence = new DriverLicence().number("123");
        dataFields.setDriverLicence(driverLicence);

        assertEquals(driverLicence, dataFields.getDriverLicence());
        assertEquals(driverLicence, new DataFields().driverLicence(driverLicence).getDriverLicence());
    }

    @Test
    public void testNationalIds() {
        dataFields.addNationalIdsItem(new NationalId());
        dataFields.addNationalIdsItem(new NationalId());
        List<NationalId> nationalIds = Arrays.asList(new NationalId().number("123"));
        dataFields.setNationalIds(nationalIds);

        assertEquals(nationalIds, dataFields.getNationalIds());
        assertEquals(nationalIds, new DataFields().nationalIds(nationalIds).getNationalIds());
    }

    @Test
    public void testPassport() {
        Passport passport = new Passport().mrz1("<<test>>");
        dataFields.setPassport(passport);

        assertEquals(passport, dataFields.getPassport());
        assertEquals(passport, new DataFields().passport(passport).getPassport());
    }

    @Test
    public void testDocument() {
        Document document = new Document().documentType("NationalId");
        dataFields.setDocument(document);

        assertEquals(document, dataFields.getDocument());
        assertEquals(document, new DataFields().document(document).getDocument());
    }

    @Test
    public void testBusiness() {
        Business business = new Business().businessName("test");
        dataFields.setBusiness(business);

        assertEquals(business, dataFields.getBusiness());
        assertEquals(business, new DataFields().business(business).getBusiness());
    }

    @Test
    public void testCountrySpecific() {
        dataFields.putCountrySpecificItem("a", new HashMap<String, String>());
        Map<String, Map<String, String>> countrySpecific = new HashMap<String, Map<String, String>>() {
            {
                put("country_code", new HashMap<String, String>() {
                    {
                        put("field", "value");
                    }
                });
            }
        };
        dataFields.setCountrySpecific(countrySpecific);
        dataFields.putCountrySpecificItem("b", new HashMap<String, String>());

        assertEquals(countrySpecific, dataFields.getCountrySpecific());
        assertEquals(countrySpecific, new DataFields().countrySpecific(countrySpecific).getCountrySpecific());
    }

    @Test
    public void testEquals() {
        PersonInfo personInfo = new PersonInfo().firstGivenName("test");
        DataFields dataFields1 = new DataFields().personInfo(personInfo);

        assertEquals(dataFields1, dataFields1);
        assertEquals(dataFields1, new DataFields().personInfo(personInfo));
        assertNotEquals(dataFields1, new DataFields().personInfo(new PersonInfo().firstSurName("a")));
        assertNotEquals(dataFields1, null);
    }

    @Test
    public void testHashcode() {
        PersonInfo personInfo = new PersonInfo().firstGivenName("test");

        assertEquals(new DataFields().personInfo(personInfo).hashCode(),
                new DataFields().personInfo(personInfo).hashCode());
    }

    @Test
    public void testToString() {
        PersonInfo personInfo = new PersonInfo().firstGivenName("test");

        assertEquals(new DataFields().personInfo(personInfo).toString(),
                new DataFields().personInfo(personInfo).toString());
    }
}
