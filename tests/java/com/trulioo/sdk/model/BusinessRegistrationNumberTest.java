package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class BusinessRegistrationNumberTest {
    private BusinessRegistrationNumber businessRegistrationNumber;

    @BeforeEach
    public void beforeEach() {
        businessRegistrationNumber = new BusinessRegistrationNumber();
    }

    @Test
    public void testName() {
        String name = "test";
        businessRegistrationNumber.setName(name);

        assertEquals(name, businessRegistrationNumber.getName());
        assertEquals(name, new BusinessRegistrationNumber().name(name).getName());
    }

    @Test
    public void testDescription() {
        String description = "desc";
        businessRegistrationNumber.setDescription(description);

        assertEquals(description, businessRegistrationNumber.getDescription());
        assertEquals(description, new BusinessRegistrationNumber().description(description).getDescription());
    }

    @Test
    public void testCountry() {
        String country = "Canada";
        businessRegistrationNumber.setCountry(country);

        assertEquals(country, businessRegistrationNumber.getCountry());
        assertEquals(country, new BusinessRegistrationNumber().country(country).getCountry());
    }

    @Test
    public void testJurisdiction() {
        String jurisdiction = "Alberta";
        businessRegistrationNumber.setJurisdiction(jurisdiction);

        assertEquals(jurisdiction, businessRegistrationNumber.getJurisdiction());
        assertEquals(jurisdiction, new BusinessRegistrationNumber().jurisdiction(jurisdiction).getJurisdiction());
    }

    @Test
    public void testSupported() {
        Boolean supported = true;
        businessRegistrationNumber.setSupported(supported);

        assertEquals(supported, businessRegistrationNumber.getSupported());
        assertEquals(supported, new BusinessRegistrationNumber().supported(supported).getSupported());
    }

    @Test
    public void testType() {
        String type = "type";
        businessRegistrationNumber.setType(type);

        assertEquals(type, businessRegistrationNumber.getType());
        assertEquals(type, new BusinessRegistrationNumber().type(type).getType());
    }

    @Test
    public void testMasks() {
        businessRegistrationNumber.addMasksItem(new BusinessRegistrationNumberMask());
        businessRegistrationNumber.addMasksItem(new BusinessRegistrationNumberMask());
        List<BusinessRegistrationNumberMask> masks = Arrays.asList(new BusinessRegistrationNumberMask().mask("AAA"));
        businessRegistrationNumber.setMasks(masks);

        assertEquals(masks, businessRegistrationNumber.getMasks());
        assertEquals(masks, new BusinessRegistrationNumber().masks(masks).getMasks());
    }

    @Test
    public void testEquals() {
        String name = "test";
        BusinessRegistrationNumber businessRegistrationNumber1 = new BusinessRegistrationNumber().name(name);

        assertEquals(businessRegistrationNumber1, businessRegistrationNumber1);
        assertEquals(businessRegistrationNumber1, new BusinessRegistrationNumber().name(name));
        assertNotEquals(businessRegistrationNumber1, new BusinessRegistrationNumber().name(name + "1"));
        assertNotEquals(businessRegistrationNumber1, null);
    }

    @Test
    public void testHashcode() {
        String name = "test";

        assertEquals(new BusinessRegistrationNumber().name(name).hashCode(),
                new BusinessRegistrationNumber().name(name).hashCode());
    }

    @Test
    public void testToString() {
        String name = "test";

        assertEquals(new BusinessRegistrationNumber().name(name).toString(),
                new BusinessRegistrationNumber().name(name).toString());
    }
}
