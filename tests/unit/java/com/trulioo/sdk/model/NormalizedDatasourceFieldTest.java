package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class NormalizedDatasourceFieldTest {
    private NormalizedDatasourceField normalizedDatasourceField;

    @BeforeEach
    public void beforeEach() {
        normalizedDatasourceField = new NormalizedDatasourceField();
    }

    @Test
    public void testFieldName() {
        String fieldName = "field";
        normalizedDatasourceField.setFieldName(fieldName);

        assertEquals(fieldName, normalizedDatasourceField.getFieldName());
        assertEquals(fieldName, new NormalizedDatasourceField().fieldName(fieldName).getFieldName());
    }

    @Test
    public void testType() {
        String type = "type";
        normalizedDatasourceField.setType(type);

        assertEquals(type, normalizedDatasourceField.getType());
        assertEquals(type, new NormalizedDatasourceField().type(type).getType());
    }

    @Test
    public void testEquals() {
        String fieldName = "field";
        NormalizedDatasourceField normalizedDatasourceField1 = new NormalizedDatasourceField().fieldName(fieldName);

        assertEquals(normalizedDatasourceField1, normalizedDatasourceField1);
        assertEquals(normalizedDatasourceField1, new NormalizedDatasourceField().fieldName(fieldName));
        assertNotEquals(normalizedDatasourceField1, new NormalizedDatasourceField().fieldName(fieldName + "1"));
        assertNotEquals(normalizedDatasourceField1, null);
    }

    @Test
    public void testHashcode() {
        String fieldName = "field";

        assertEquals(new NormalizedDatasourceField().fieldName(fieldName).hashCode(),
                new NormalizedDatasourceField().fieldName(fieldName).hashCode());
    }

    @Test
    public void testToString() {
        String fieldName = "field";

        assertEquals(new NormalizedDatasourceField().fieldName(fieldName).toString(),
                new NormalizedDatasourceField().fieldName(fieldName).toString());
    }
}
