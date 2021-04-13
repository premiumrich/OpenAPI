package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class PassportTest {
    private Passport passport;

    @BeforeEach
    public void beforeEach() {
        passport = new Passport();
    }

    @Test
    public void testMrz1() {
        String mrz1 = "<<test>>";
        passport.setMrz1(mrz1);

        assertEquals(mrz1, passport.getMrz1());
        assertEquals(mrz1, new Passport().mrz1(mrz1).getMrz1());
    }

    @Test
    public void testMrz2() {
        String mrz2 = "<<test>>";
        passport.setMrz2(mrz2);

        assertEquals(mrz2, passport.getMrz2());
        assertEquals(mrz2, new Passport().mrz2(mrz2).getMrz2());
    }

    @Test
    public void testNumber() {
        String number = "123";
        passport.setNumber(number);

        assertEquals(number, passport.getNumber());
        assertEquals(number, new Passport().number(number).getNumber());
    }

    @Test
    public void testDayOfExpiry() {
        Integer dayOfExpiry = 15;
        passport.setDayOfExpiry(dayOfExpiry);

        assertEquals(dayOfExpiry, passport.getDayOfExpiry());
        assertEquals(dayOfExpiry, new Passport().dayOfExpiry(dayOfExpiry).getDayOfExpiry());
    }

    @Test
    public void testMonthOfExpiry() {
        Integer monthOfExpiry = 9;
        passport.setMonthOfExpiry(monthOfExpiry);

        assertEquals(monthOfExpiry, passport.getMonthOfExpiry());
        assertEquals(monthOfExpiry, new Passport().monthOfExpiry(monthOfExpiry).getMonthOfExpiry());
    }

    @Test
    public void testYearOfExpiry() {
        Integer yearOfExpiry = 2020;
        passport.setYearOfExpiry(yearOfExpiry);

        assertEquals(yearOfExpiry, passport.getYearOfExpiry());
        assertEquals(yearOfExpiry, new Passport().yearOfExpiry(yearOfExpiry).getYearOfExpiry());
    }

    @Test
    public void testEquals() {
        String mrz1 = "<<test>>";
        Passport passport1 = new Passport().mrz1(mrz1);

        assertEquals(passport1, passport1);
        assertEquals(passport1, new Passport().mrz1(mrz1));
        assertNotEquals(passport1, new Passport().mrz1(mrz1 + "1"));
        assertNotEquals(passport1, null);
    }

    @Test
    public void testHashcode() {
        String mrz1 = "<<test>>";

        assertEquals(new Passport().mrz1(mrz1).hashCode(), new Passport().mrz1(mrz1).hashCode());
    }

    @Test
    public void testToString() {
        String mrz1 = "<<test>>";

        assertEquals(new Passport().mrz1(mrz1).toString(), new Passport().mrz1(mrz1).toString());
    }
}
