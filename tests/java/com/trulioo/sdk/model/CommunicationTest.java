package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class CommunicationTest {
    private Communication communication;

    @BeforeEach
    public void beforeEach() {
        communication = new Communication();
    }

    @Test
    public void testMobileNumber() {
        String mobileNumber = "18887730179";
        communication.setMobileNumber(mobileNumber);

        assertEquals(mobileNumber, communication.getMobileNumber());
        assertEquals(mobileNumber, new Communication().mobileNumber(mobileNumber).getMobileNumber());
    }

    @Test
    public void testTelephone() {
        String telephone = "18887730179";
        communication.setTelephone(telephone);

        assertEquals(telephone, communication.getTelephone());
        assertEquals(telephone, new Communication().telephone(telephone).getTelephone());
    }

    @Test
    public void testTelephone2() {
        String telephone2 = "18887730179";
        communication.setTelephone2(telephone2);

        assertEquals(telephone2, communication.getTelephone2());
        assertEquals(telephone2, new Communication().telephone2(telephone2).getTelephone2());
    }

    @Test
    public void testEmailAddress() {
        String emailAddress = "support@trulioo.com";
        communication.setEmailAddress(emailAddress);

        assertEquals(emailAddress, communication.getEmailAddress());
        assertEquals(emailAddress, new Communication().emailAddress(emailAddress).getEmailAddress());
    }

    @Test
    public void testEquals() {
        String mobileNumber = "18887730179";
        Communication communication1 = new Communication().mobileNumber(mobileNumber);

        assertEquals(communication1, communication1);
        assertEquals(communication1, new Communication().mobileNumber(mobileNumber));
        assertNotEquals(communication1, new Communication().mobileNumber(mobileNumber + "1"));
        assertNotEquals(communication1, null);
    }

    @Test
    public void testHashcode() {
        String mobileNumber = "18887730179";

        assertEquals(new Communication().mobileNumber(mobileNumber).hashCode(),
                new Communication().mobileNumber(mobileNumber).hashCode());
    }

    @Test
    public void testToString() {
        String mobileNumber = "18887730179";

        assertEquals(new Communication().mobileNumber(mobileNumber).toString(),
                new Communication().mobileNumber(mobileNumber).toString());
    }
}
