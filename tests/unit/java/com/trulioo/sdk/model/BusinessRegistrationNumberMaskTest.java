package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class BusinessRegistrationNumberMaskTest {
    private BusinessRegistrationNumberMask businessRegistrationNumberMask;

    @BeforeEach
    public void beforeEach() {
        businessRegistrationNumberMask = new BusinessRegistrationNumberMask();
    }

    @Test
    public void testMask() {
        String mask = "AAA";
        businessRegistrationNumberMask.setMask(mask);

        assertEquals(mask, businessRegistrationNumberMask.getMask());
        assertEquals(mask, new BusinessRegistrationNumberMask().mask(mask).getMask());
    }

    @Test
    public void testIgnoreWhitespace() {
        Boolean ignoreWhitespace = true;
        businessRegistrationNumberMask.setIgnoreWhitespace(ignoreWhitespace);

        assertEquals(ignoreWhitespace, businessRegistrationNumberMask.getIgnoreWhitespace());
        assertEquals(ignoreWhitespace,
                new BusinessRegistrationNumberMask().ignoreWhitespace(ignoreWhitespace).getIgnoreWhitespace());
    }

    @Test
    public void testIgnoreSpecialCharacter() {
        Boolean ignoreSpecialCharacter = false;
        businessRegistrationNumberMask.setIgnoreSpecialCharacter(ignoreSpecialCharacter);

        assertEquals(ignoreSpecialCharacter, businessRegistrationNumberMask.getIgnoreSpecialCharacter());
        assertEquals(ignoreSpecialCharacter, new BusinessRegistrationNumberMask()
                .ignoreSpecialCharacter(ignoreSpecialCharacter).getIgnoreSpecialCharacter());
    }

    @Test
    public void testEquals() {
        String mask = "AAA";
        BusinessRegistrationNumberMask businessRegistrationNumberMask1 = new BusinessRegistrationNumberMask()
                .mask(mask);

        assertEquals(businessRegistrationNumberMask1, businessRegistrationNumberMask1);
        assertEquals(businessRegistrationNumberMask1, new BusinessRegistrationNumberMask().mask(mask));
        assertNotEquals(businessRegistrationNumberMask1, new BusinessRegistrationNumberMask().mask(mask + "1"));
        assertNotEquals(businessRegistrationNumberMask1, null);
    }

    @Test
    public void testHashcode() {
        String mask = "AAA";

        assertEquals(new BusinessRegistrationNumberMask().mask(mask).hashCode(),
                new BusinessRegistrationNumberMask().mask(mask).hashCode());
    }

    @Test
    public void testToString() {
        String mask = "AAA";

        assertEquals(new BusinessRegistrationNumberMask().mask(mask).toString(),
                new BusinessRegistrationNumberMask().mask(mask).toString());
    }
}
