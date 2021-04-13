package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class DriverLicenceTest {
    private DriverLicence driverLicence;

    @BeforeEach
    public void beforeEach() {
        driverLicence = new DriverLicence();
    }

    @Test
    public void testNumber() {
        String number = "123";
        driverLicence.setNumber(number);

        assertEquals(number, driverLicence.getNumber());
        assertEquals(number, new DriverLicence().number(number).getNumber());
    }

    @Test
    public void testState() {
        String state = "Alberta";
        driverLicence.setState(state);

        assertEquals(state, driverLicence.getState());
        assertEquals(state, new DriverLicence().state(state).getState());
    }

    @Test
    public void testDayOfExpiry() {
        Integer dayOfExpiry = 15;
        driverLicence.setDayOfExpiry(dayOfExpiry);

        assertEquals(dayOfExpiry, driverLicence.getDayOfExpiry());
        assertEquals(dayOfExpiry, new DriverLicence().dayOfExpiry(dayOfExpiry).getDayOfExpiry());
    }

    @Test
    public void testMonthOfExpiry() {
        Integer monthOfExpiry = 9;
        driverLicence.setMonthOfExpiry(monthOfExpiry);

        assertEquals(monthOfExpiry, driverLicence.getMonthOfExpiry());
        assertEquals(monthOfExpiry, new DriverLicence().monthOfExpiry(monthOfExpiry).getMonthOfExpiry());
    }

    @Test
    public void testYearOfExpiry() {
        Integer yearOfExpiry = 2020;
        driverLicence.setYearOfExpiry(yearOfExpiry);

        assertEquals(yearOfExpiry, driverLicence.getYearOfExpiry());
        assertEquals(yearOfExpiry, new DriverLicence().yearOfExpiry(yearOfExpiry).getYearOfExpiry());
    }

    @Test
    public void testEquals() {
        String number = "123";
        DriverLicence driverLicence1 = new DriverLicence().number(number);

        assertEquals(driverLicence1, driverLicence1);
        assertEquals(driverLicence1, new DriverLicence().number(number));
        assertNotEquals(driverLicence1, new DriverLicence().number(number + "1"));
        assertNotEquals(driverLicence1, null);
    }

    @Test
    public void testHashcode() {
        String number = "123";

        assertEquals(new DriverLicence().number(number).hashCode(), new DriverLicence().number(number).hashCode());
    }

    @Test
    public void testToString() {
        String number = "123";

        assertEquals(new DriverLicence().number(number).toString(), new DriverLicence().number(number).toString());
    }
}
