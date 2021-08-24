package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class DataFieldTest {
    private DataField dataField;

    @BeforeEach
    public void beforeEach() {
        dataField = new DataField();
    }

    @Test
    public void testFieldName() {
        String fieldName = "field";
        dataField.setFieldName(fieldName);

        assertEquals(fieldName, dataField.getFieldName());
        assertEquals(fieldName, new DataField().fieldName(fieldName).getFieldName());
    }

    @Test
    public void testValue() {
        String value = "test";
        dataField.setValue(value);

        assertEquals(value, dataField.getValue());
        assertEquals(value, new DataField().value(value).getValue());
    }

    @Test
    public void testFieldGroup() {
        String fieldGroup = "group";
        dataField.setFieldGroup(fieldGroup);

        assertEquals(fieldGroup, dataField.getFieldGroup());
        assertEquals(fieldGroup, new DataField().fieldGroup(fieldGroup).getFieldGroup());
    }

    @Test
    public void testEquals() {
        String fieldName = "field";
        DataField dataField1 = new DataField().fieldName(fieldName);

        assertEquals(dataField1, dataField1);
        assertEquals(dataField1, new DataField().fieldName(fieldName));
        assertNotEquals(dataField1, new DataField().fieldName(fieldName + "1"));
        assertNotEquals(dataField1, null);
    }

    @Test
    public void testHashcode() {
        String fieldName = "field";

        assertEquals(new DataField().fieldName(fieldName).hashCode(), new DataField().fieldName(fieldName).hashCode());
    }

    @Test
    public void testToString() {
        String fieldName = "field";

        assertEquals(new DataField().fieldName(fieldName).toString(), new DataField().fieldName(fieldName).toString());
    }
}
