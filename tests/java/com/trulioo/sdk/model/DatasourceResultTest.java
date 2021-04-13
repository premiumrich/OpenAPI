package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class DatasourceResultTest {
    private DatasourceResult datasourceResult;

    @BeforeEach
    public void beforeEach() {
        datasourceResult = new DatasourceResult();
    }

    @Test
    public void testDatasourceStatus() {
        String datasourceStatus = "nomatch";
        datasourceResult.setDatasourceStatus(datasourceStatus);

        assertEquals(datasourceStatus, datasourceResult.getDatasourceStatus());
        assertEquals(datasourceStatus, new DatasourceResult().datasourceStatus(datasourceStatus).getDatasourceStatus());
    }

    @Test
    public void testDatasourceName() {
        String datasourceName = "test";
        datasourceResult.setDatasourceName(datasourceName);

        assertEquals(datasourceName, datasourceResult.getDatasourceName());
        assertEquals(datasourceName, new DatasourceResult().datasourceName(datasourceName).getDatasourceName());
    }

    @Test
    public void testDatasourceFields() {
        datasourceResult.addDatasourceFieldsItem(new DatasourceField());
        datasourceResult.addDatasourceFieldsItem(new DatasourceField());
        List<DatasourceField> datasourceFields = Arrays.asList(new DatasourceField().fieldName("test"));
        datasourceResult.setDatasourceFields(datasourceFields);

        assertEquals(datasourceFields, datasourceResult.getDatasourceFields());
        assertEquals(datasourceFields, new DatasourceResult().datasourceFields(datasourceFields).getDatasourceFields());
    }

    @Test
    public void testAppendedFields() {
        datasourceResult.addAppendedFieldsItem(new AppendedField());
        datasourceResult.addAppendedFieldsItem(new AppendedField());
        List<AppendedField> appendedFields = Arrays.asList(new AppendedField().fieldName("test"));
        datasourceResult.setAppendedFields(appendedFields);

        assertEquals(appendedFields, datasourceResult.getAppendedFields());
        assertEquals(appendedFields, new DatasourceResult().appendedFields(appendedFields).getAppendedFields());
    }

    @Test
    public void testErrors() {
        datasourceResult.addErrorsItem(new ServiceError());
        datasourceResult.addErrorsItem(new ServiceError());
        List<ServiceError> errors = Arrays.asList(new ServiceError().message("test"));
        datasourceResult.setErrors(errors);

        assertEquals(errors, datasourceResult.getErrors());
        assertEquals(errors, new DatasourceResult().errors(errors).getErrors());
    }

    @Test
    public void testFieldGroups() {
        datasourceResult.addFieldGroupsItem("group1");
        datasourceResult.addFieldGroupsItem("group2");
        List<String> fieldGroups = Arrays.asList("group3");
        datasourceResult.setFieldGroups(fieldGroups);

        assertEquals(fieldGroups, datasourceResult.getFieldGroups());
        assertEquals(fieldGroups, new DatasourceResult().fieldGroups(fieldGroups).getFieldGroups());
    }

    @Test
    public void testEquals() {
        String datasourceStatus = "nomatch";
        DatasourceResult datasourceResult1 = new DatasourceResult().datasourceStatus(datasourceStatus);

        assertEquals(datasourceResult1, datasourceResult1);
        assertEquals(datasourceResult1, new DatasourceResult().datasourceStatus(datasourceStatus));
        assertNotEquals(datasourceResult1, new DatasourceResult().datasourceStatus(datasourceStatus + "1"));
        assertNotEquals(datasourceResult1, null);
    }

    @Test
    public void testHashcode() {
        String datasourceStatus = "nomatch";

        assertEquals(new DatasourceResult().datasourceStatus(datasourceStatus).hashCode(),
                new DatasourceResult().datasourceStatus(datasourceStatus).hashCode());
    }

    @Test
    public void testToString() {
        String datasourceStatus = "nomatch";

        assertEquals(new DatasourceResult().datasourceStatus(datasourceStatus).toString(),
                new DatasourceResult().datasourceStatus(datasourceStatus).toString());
    }
}
