package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class LocationTest {
    private Location location;

    @BeforeEach
    public void beforeEach() {
        location = new Location();
    }

    @Test
    public void testBuildingNumber() {
        String buildingNumber = "123";
        location.setBuildingNumber(buildingNumber);

        assertEquals(buildingNumber, location.getBuildingNumber());
        assertEquals(buildingNumber, new Location().buildingNumber(buildingNumber).getBuildingNumber());
    }

    @Test
    public void testBuildingName() {
        String buildingName = "Guinness";
        location.setBuildingName(buildingName);

        assertEquals(buildingName, location.getBuildingName());
        assertEquals(buildingName, new Location().buildingName(buildingName).getBuildingName());
    }

    @Test
    public void testUnitNumber() {
        String unitNumber = "10";
        location.setUnitNumber(unitNumber);

        assertEquals(unitNumber, location.getUnitNumber());
        assertEquals(unitNumber, new Location().unitNumber(unitNumber).getUnitNumber());
    }

    @Test
    public void testStreetName() {
        String streetName = "Seasame";
        location.setStreetName(streetName);

        assertEquals(streetName, location.getStreetName());
        assertEquals(streetName, new Location().streetName(streetName).getStreetName());
    }

    @Test
    public void testStreetType() {
        String streetType = "St";
        location.setStreetType(streetType);

        assertEquals(streetType, location.getStreetType());
        assertEquals(streetType, new Location().streetType(streetType).getStreetType());
    }

    @Test
    public void testCity() {
        String city = "Shibuya";
        location.setCity(city);

        assertEquals(city, location.getCity());
        assertEquals(city, new Location().city(city).getCity());
    }

    @Test
    public void testSuburb() {
        String suburb = "West";
        location.setSuburb(suburb);

        assertEquals(suburb, location.getSuburb());
        assertEquals(suburb, new Location().suburb(suburb).getSuburb());
    }

    @Test
    public void testCounty() {
        String county = "District 12";
        location.setCounty(county);

        assertEquals(county, location.getCounty());
        assertEquals(county, new Location().county(county).getCounty());
    }

    @Test
    public void testStateProvinceCode() {
        String stateProvinceCode = "AB";
        location.setStateProvinceCode(stateProvinceCode);

        assertEquals(stateProvinceCode, location.getStateProvinceCode());
        assertEquals(stateProvinceCode, new Location().stateProvinceCode(stateProvinceCode).getStateProvinceCode());
    }

    @Test
    public void testCountry() {
        String country = "Canada";
        location.setCountry(country);

        assertEquals(country, location.getCountry());
        assertEquals(country, new Location().country(country).getCountry());
    }

    @Test
    public void testPostalCode() {
        String postalCode = "H0H0H0";
        location.setPostalCode(postalCode);

        assertEquals(postalCode, location.getPostalCode());
        assertEquals(postalCode, new Location().postalCode(postalCode).getPostalCode());
    }

    @Test
    public void testPoBox() {
        String poBox = "10001";
        location.setPoBox(poBox);

        assertEquals(poBox, location.getPoBox());
        assertEquals(poBox, new Location().poBox(poBox).getPoBox());
    }

    @Test
    public void testAdditionalFields() {
        LocationAdditionalFields additionalFields = new LocationAdditionalFields().address1("123 Seasame St");
        location.setAdditionalFields(additionalFields);

        assertEquals(additionalFields, location.getAdditionalFields());
        assertEquals(additionalFields, new Location().additionalFields(additionalFields).getAdditionalFields());
    }

    @Test
    public void testEquals() {
        String buildingNumber = "123";
        Location location1 = new Location().buildingNumber(buildingNumber);

        assertEquals(location1, location1);
        assertEquals(location1, new Location().buildingNumber(buildingNumber));
        assertNotEquals(location1, new Location().buildingNumber(buildingNumber + "1"));
        assertNotEquals(location1, null);
    }

    @Test
    public void testHashcode() {
        String buildingNumber = "123";

        assertEquals(new Location().buildingNumber(buildingNumber).hashCode(),
                new Location().buildingNumber(buildingNumber).hashCode());
    }

    @Test
    public void testToString() {
        String buildingNumber = "123";

        assertEquals(new Location().buildingNumber(buildingNumber).toString(),
                new Location().buildingNumber(buildingNumber).toString());
    }
}
