package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class DatasourceFieldTest {
    private DatasourceField datasourceField;

    @BeforeEach
    public void beforeEach() {
        datasourceField = new DatasourceField();
    }

    @Test
    public void testFieldName() {
        String fieldName = "field";
        datasourceField.setFieldName(fieldName);

        assertEquals(fieldName, datasourceField.getFieldName());
        assertEquals(fieldName, new DatasourceField().fieldName(fieldName).getFieldName());
    }

    @Test
    public void testStatus() {
        String status = "match";
        datasourceField.setStatus(status);

        assertEquals(status, datasourceField.getStatus());
        assertEquals(status, new DatasourceField().status(status).getStatus());
    }

    @Test
    public void testFieldGroup() {
        String fieldGroup = "group";
        datasourceField.setFieldGroup(fieldGroup);

        assertEquals(fieldGroup, datasourceField.getFieldGroup());
        assertEquals(fieldGroup, new DatasourceField().fieldGroup(fieldGroup).getFieldGroup());
    }

    @Test
    public void testEquals() {
        String fieldName = "field";
        DatasourceField datasourceField1 = new DatasourceField().fieldName(fieldName);

        assertEquals(datasourceField1, datasourceField1);
        assertEquals(datasourceField1, new DatasourceField().fieldName(fieldName));
        assertNotEquals(datasourceField1, new DatasourceField().fieldName(fieldName + "1"));
        assertNotEquals(datasourceField1, null);
    }

    @Test
    public void testHashcode() {
        String fieldName = "field";

        assertEquals(new DatasourceField().fieldName(fieldName).hashCode(),
                new DatasourceField().fieldName(fieldName).hashCode());
    }

    @Test
    public void testToString() {
        String fieldName = "field";

        assertEquals(new DatasourceField().fieldName(fieldName).toString(),
                new DatasourceField().fieldName(fieldName).toString());
    }
}
