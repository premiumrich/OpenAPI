package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class LocationAdditionalFieldsTest {
    private LocationAdditionalFields locationAdditionalFields;

    @BeforeEach
    public void beforeEach() {
        locationAdditionalFields = new LocationAdditionalFields();
    }

    @Test
    public void testAddress1() {
        String address1 = "123 Seasame St";
        locationAdditionalFields.setAddress1(address1);

        assertEquals(address1, locationAdditionalFields.getAddress1());
        assertEquals(address1, new LocationAdditionalFields().address1(address1).getAddress1());
    }

    @Test
    public void testEquals() {
        String address1 = "123 Seasame St";
        LocationAdditionalFields locationAdditionalFields1 = new LocationAdditionalFields().address1(address1);

        assertEquals(locationAdditionalFields1, locationAdditionalFields1);
        assertEquals(locationAdditionalFields1, new LocationAdditionalFields().address1(address1));
        assertNotEquals(locationAdditionalFields1, new LocationAdditionalFields().address1(address1 + "1"));
        assertNotEquals(locationAdditionalFields1, null);
    }

    @Test
    public void testHashcode() {
        String address1 = "123 Seasame St";

        assertEquals(new LocationAdditionalFields().address1(address1).hashCode(),
                new LocationAdditionalFields().address1(address1).hashCode());
    }

    @Test
    public void testToString() {
        String address1 = "123 Seasame St";

        assertEquals(new LocationAdditionalFields().address1(address1).toString(),
                new LocationAdditionalFields().address1(address1).toString());

        assertEquals(new LocationAdditionalFields().toString(), new LocationAdditionalFields().toString());
    }
}
