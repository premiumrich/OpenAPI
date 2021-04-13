package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class PersonInfoAdditionalFieldsTest {
    private PersonInfoAdditionalFields personInfoAdditionalFields;

    @BeforeEach
    public void beforeEach() {
        personInfoAdditionalFields = new PersonInfoAdditionalFields();
    }

    @Test
    public void testFullName() {
        String fullName = "A B C";
        personInfoAdditionalFields.setFullName(fullName);

        assertEquals(fullName, personInfoAdditionalFields.getFullName());
        assertEquals(fullName, new PersonInfoAdditionalFields().fullName(fullName).getFullName());
    }

    @Test
    public void testEquals() {
        String fullName = "A B C";
        PersonInfoAdditionalFields personInfoAdditionalFields1 = new PersonInfoAdditionalFields().fullName(fullName);

        assertEquals(personInfoAdditionalFields1, personInfoAdditionalFields1);
        assertEquals(personInfoAdditionalFields1, new PersonInfoAdditionalFields().fullName(fullName));
        assertNotEquals(personInfoAdditionalFields1, new PersonInfoAdditionalFields().fullName(fullName + "1"));
        assertNotEquals(personInfoAdditionalFields1, null);
    }

    @Test
    public void testHashcode() {
        String fullName = "A B C";

        assertEquals(new PersonInfoAdditionalFields().fullName(fullName).hashCode(),
                new PersonInfoAdditionalFields().fullName(fullName).hashCode());
    }

    @Test
    public void testToString() {
        String fullName = "A B C";

        assertEquals(new PersonInfoAdditionalFields().fullName(fullName).toString(),
                new PersonInfoAdditionalFields().fullName(fullName).toString());

        assertEquals(new PersonInfoAdditionalFields().toString(), new PersonInfoAdditionalFields().toString());
    }
}
