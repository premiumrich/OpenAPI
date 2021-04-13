package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class ServiceErrorTest {
    private ServiceError serviceError;

    @BeforeEach
    public void beforeEach() {
        serviceError = new ServiceError();
    }

    @Test
    public void testCode() {
        String code = "123";
        serviceError.setCode(code);

        assertEquals(code, serviceError.getCode());
        assertEquals(code, new ServiceError().code(code).getCode());
    }

    @Test
    public void testMessage() {
        String message = "test";
        serviceError.setMessage(message);

        assertEquals(message, serviceError.getMessage());
        assertEquals(message, new ServiceError().message(message).getMessage());
    }

    @Test
    public void testEquals() {
        String code = "123";
        ServiceError serviceError1 = new ServiceError().code(code);

        assertEquals(serviceError1, serviceError1);
        assertEquals(serviceError1, new ServiceError().code(code));
        assertNotEquals(serviceError1, new ServiceError().code(code + "1"));
        assertNotEquals(serviceError1, null);
    }

    @Test
    public void testHashcode() {
        String code = "123";

        assertEquals(new ServiceError().code(code).hashCode(), new ServiceError().code(code).hashCode());
    }

    @Test
    public void testToString() {
        String code = "123";

        assertEquals(new ServiceError().code(code).toString(), new ServiceError().code(code).toString());
    }
}
