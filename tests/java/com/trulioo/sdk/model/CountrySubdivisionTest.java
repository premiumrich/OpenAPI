package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class CountrySubdivisionTest {
    private CountrySubdivision countrySubdivision;

    @BeforeEach
    public void beforeEach() {
        countrySubdivision = new CountrySubdivision();
    }

    @Test
    public void testName() {
        String name = "British Columbia";
        countrySubdivision.setName(name);

        assertEquals(name, countrySubdivision.getName());
        assertEquals(name, new CountrySubdivision().name(name).getName());
    }

    @Test
    public void testCode() {
        String code = "BC";
        countrySubdivision.setCode(code);

        assertEquals(code, countrySubdivision.getCode());
        assertEquals(code, new CountrySubdivision().code(code).getCode());
    }

    @Test
    public void testParentCode() {
        String parentCode = "CA-BC";
        countrySubdivision.setParentCode(parentCode);

        assertEquals(parentCode, countrySubdivision.getParentCode());
        assertEquals(parentCode, new CountrySubdivision().parentCode(parentCode).getParentCode());
    }

    @Test
    public void testEquals() {
        String name = "British Columbia";
        CountrySubdivision countrySubdivision1 = new CountrySubdivision().name(name);

        assertEquals(countrySubdivision1, countrySubdivision1);
        assertEquals(countrySubdivision1, new CountrySubdivision().name(name));
        assertNotEquals(countrySubdivision1, new CountrySubdivision().name(name + "1"));
        assertNotEquals(countrySubdivision1, null);
    }

    @Test
    public void testHashcode() {
        String name = "British Columbia";

        assertEquals(new CountrySubdivision().name(name).hashCode(), new CountrySubdivision().name(name).hashCode());
    }

    @Test
    public void testToString() {
        String name = "British Columbia";

        assertEquals(new CountrySubdivision().name(name).toString(), new CountrySubdivision().name(name).toString());
    }
}
