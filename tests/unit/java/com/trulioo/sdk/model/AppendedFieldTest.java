package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class AppendedFieldTest {
    private AppendedField appendedField;

    @BeforeEach
    public void beforeEach() {
        appendedField = new AppendedField();
    }

    @Test
    public void testFieldName() {
        String fieldName = "field";
        appendedField.setFieldName(fieldName);

        assertEquals(fieldName, appendedField.getFieldName());
        assertEquals(fieldName, new AppendedField().fieldName(fieldName).getFieldName());
    }

    @Test
    public void testData() {
        String data = "value";
        appendedField.setData(data);

        assertEquals(data, appendedField.getData());
        assertEquals(data, new AppendedField().data(data).getData());
    }

    @Test
    public void testEquals() {
        String fieldName = "field";
        AppendedField appendedField1 = new AppendedField().fieldName(fieldName);

        assertEquals(appendedField1, appendedField1);
        assertEquals(appendedField1, new AppendedField().fieldName(fieldName));
        assertNotEquals(appendedField1, new AppendedField().fieldName(fieldName + "1"));
        assertNotEquals(appendedField1, null);
    }

    @Test
    public void testHashcode() {
        String fieldName = "field";

        assertEquals(new AppendedField().fieldName(fieldName).hashCode(),
                new AppendedField().fieldName(fieldName).hashCode());
    }

    @Test
    public void testToString() {
        String fieldName = "field";

        assertEquals(new AppendedField().fieldName(fieldName).toString(),
                new AppendedField().fieldName(fieldName).toString());
    }
}
