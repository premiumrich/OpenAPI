package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class AddressTest {
    private Address address;

    @BeforeEach
    public void beforeEach() {
        address = new Address();
    }

    @Test
    public void testUnitNumber() {
        String unitNumber = "10";
        address.setUnitNumber(unitNumber);

        assertEquals(unitNumber, address.getUnitNumber());
        assertEquals(unitNumber, new Address().unitNumber(unitNumber).getUnitNumber());
    }

    @Test
    public void testBuildingNumber() {
        String buildingNumber = "123";
        address.setBuildingNumber(buildingNumber);

        assertEquals(buildingNumber, address.getBuildingNumber());
        assertEquals(buildingNumber, new Address().buildingNumber(buildingNumber).getBuildingNumber());
    }

    @Test
    public void testBuildingName() {
        String buildingName = "Guinness";
        address.setBuildingName(buildingName);

        assertEquals(buildingName, address.getBuildingName());
        assertEquals(buildingName, new Address().buildingName(buildingName).getBuildingName());
    }

    @Test
    public void testStreetName() {
        String streetName = "Seasame";
        address.setStreetName(streetName);

        assertEquals(streetName, address.getStreetName());
        assertEquals(streetName, new Address().streetName(streetName).getStreetName());
    }

    @Test
    public void testStreetType() {
        String streetType = "St";
        address.setStreetType(streetType);

        assertEquals(streetType, address.getStreetType());
        assertEquals(streetType, new Address().streetType(streetType).getStreetType());
    }

    @Test
    public void testCity() {
        String city = "Shibuya";
        address.setCity(city);

        assertEquals(city, address.getCity());
        assertEquals(city, new Address().city(city).getCity());
    }

    @Test
    public void testSuburb() {
        String suburb = "West";
        address.setSuburb(suburb);

        assertEquals(suburb, address.getSuburb());
        assertEquals(suburb, new Address().suburb(suburb).getSuburb());
    }

    @Test
    public void testStateProvinceCode() {
        String stateProvinceCode = "BC";
        address.setStateProvinceCode(stateProvinceCode);

        assertEquals(stateProvinceCode, address.getStateProvinceCode());
        assertEquals(stateProvinceCode, new Address().stateProvinceCode(stateProvinceCode).getStateProvinceCode());
    }

    @Test
    public void testPostalCode() {
        String postalCode = "H0H0H0";
        address.setPostalCode(postalCode);

        assertEquals(postalCode, address.getPostalCode());
        assertEquals(postalCode, new Address().postalCode(postalCode).getPostalCode());
    }

    @Test
    public void testAddress1() {
        String address1 = "123 Seasame St";
        address.setAddress1(address1);

        assertEquals(address1, address.getAddress1());
        assertEquals(address1, new Address().address1(address1).getAddress1());
    }

    @Test
    public void testAddressType() {
        String addressType = "Work";
        address.setAddressType(addressType);

        assertEquals(addressType, address.getAddressType());
        assertEquals(addressType, new Address().addressType(addressType).getAddressType());
    }

    @Test
    public void testStateProvince() {
        String stateProvince = "British Columbia";
        address.setStateProvince(stateProvince);

        assertEquals(stateProvince, address.getStateProvince());
        assertEquals(stateProvince, new Address().stateProvince(stateProvince).getStateProvince());
    }

    @Test
    public void testCountry() {
        String country = "Canada";
        address.setCountry(country);

        assertEquals(country, address.getCountry());
        assertEquals(country, new Address().country(country).getCountry());
    }

    @Test
    public void testCountryCode() {
        String countryCode = "CA";
        address.setCountryCode(countryCode);

        assertEquals(countryCode, address.getCountryCode());
        assertEquals(countryCode, new Address().countryCode(countryCode).getCountryCode());
    }

    @Test
    public void testEquals() {
        String unitNumber = "10";
        Address address1 = new Address().unitNumber(unitNumber);

        assertEquals(address1, address1);
        assertEquals(address1, new Address().unitNumber(unitNumber));
        assertNotEquals(address1, new Address().unitNumber(unitNumber + "1"));
        assertNotEquals(address1, null);
    }

    @Test
    public void testHashcode() {
        String unitNumber = "10";

        assertEquals(new Address().unitNumber(unitNumber).hashCode(), new Address().unitNumber(unitNumber).hashCode());
    }

    @Test
    public void testToString() {
        String unitNumber = "10";

        assertEquals(new Address().unitNumber(unitNumber).toString(), new Address().unitNumber(unitNumber).toString());
    }
}
