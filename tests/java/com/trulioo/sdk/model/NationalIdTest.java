package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class NationalIdTest {
    private NationalId nationalId;

    @BeforeEach
    public void beforeEach() {
        nationalId = new NationalId();
    }

    @Test
    public void testNumber() {
        String number = "123";
        nationalId.setNumber(number);

        assertEquals(number, nationalId.getNumber());
        assertEquals(number, new NationalId().number(number).getNumber());
    }

    @Test
    public void testType() {
        String type = "type";
        nationalId.setType(type);

        assertEquals(type, nationalId.getType());
        assertEquals(type, new NationalId().type(type).getType());
    }

    @Test
    public void testDistrictOfIssue() {
        String districtOfIssue = "district";
        nationalId.setDistrictOfIssue(districtOfIssue);

        assertEquals(districtOfIssue, nationalId.getDistrictOfIssue());
        assertEquals(districtOfIssue, new NationalId().districtOfIssue(districtOfIssue).getDistrictOfIssue());
    }

    @Test
    public void testCityOfIssue() {
        String cityOfIssue = "city";
        nationalId.setCityOfIssue(cityOfIssue);

        assertEquals(cityOfIssue, nationalId.getCityOfIssue());
        assertEquals(cityOfIssue, new NationalId().cityOfIssue(cityOfIssue).getCityOfIssue());
    }

    @Test
    public void testProvinceOfIssue() {
        String provinceOfIssue = "province";
        nationalId.setProvinceOfIssue(provinceOfIssue);

        assertEquals(provinceOfIssue, nationalId.getProvinceOfIssue());
        assertEquals(provinceOfIssue, new NationalId().provinceOfIssue(provinceOfIssue).getProvinceOfIssue());
    }

    @Test
    public void testCountyOfIssue() {
        String countyOfIssue = "county";
        nationalId.setCountyOfIssue(countyOfIssue);

        assertEquals(countyOfIssue, nationalId.getCountyOfIssue());
        assertEquals(countyOfIssue, new NationalId().countyOfIssue(countyOfIssue).getCountyOfIssue());
    }

    @Test
    public void testEquals() {
        String number = "123";
        NationalId nationalId1 = new NationalId().number(number);

        assertEquals(nationalId1, nationalId1);
        assertEquals(nationalId1, new NationalId().number(number));
        assertNotEquals(nationalId1, new NationalId().number(number + "1"));
        assertNotEquals(nationalId1, null);
    }

    @Test
    public void testHashcode() {
        String number = "123";

        assertEquals(new NationalId().number(number).hashCode(), new NationalId().number(number).hashCode());
    }

    @Test
    public void testToString() {
        String number = "123";

        assertEquals(new NationalId().number(number).toString(), new NationalId().number(number).toString());
    }
}
