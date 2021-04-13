package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class RecordTest {
    private Record record;

    @BeforeEach
    public void beforeEach() {
        record = new Record();
    }

    @Test
    public void testTransactionRecordID() {
        String transactionRecordID = "test-transaction-guid";
        record.setTransactionRecordID(transactionRecordID);

        assertEquals(transactionRecordID, record.getTransactionRecordID());
        assertEquals(transactionRecordID,
                new Record().transactionRecordID(transactionRecordID).getTransactionRecordID());
    }

    @Test
    public void testRecordStatus() {
        String recordStatus = "match";
        record.setRecordStatus(recordStatus);

        assertEquals(recordStatus, record.getRecordStatus());
        assertEquals(recordStatus, new Record().recordStatus(recordStatus).getRecordStatus());
    }

    @Test
    public void testDatasourceResults() {
        record.addDatasourceResultsItem(new DatasourceResult());
        record.addDatasourceResultsItem(new DatasourceResult());
        List<DatasourceResult> datasourceResults = Arrays.asList(new DatasourceResult().datasourceStatus("match"));
        record.setDatasourceResults(datasourceResults);

        assertEquals(datasourceResults, record.getDatasourceResults());
        assertEquals(datasourceResults, new Record().datasourceResults(datasourceResults).getDatasourceResults());
    }

    @Test
    public void testErrors() {
        record.addErrorsItem(new ServiceError());
        record.addErrorsItem(new ServiceError());
        List<ServiceError> errors = Arrays.asList(new ServiceError().message("test"));
        record.setErrors(errors);

        assertEquals(errors, record.getErrors());
        assertEquals(errors, new Record().errors(errors).getErrors());
    }

    @Test
    public void testRule() {
        RecordRule rule = new RecordRule().ruleName("rule1");
        record.setRule(rule);

        assertEquals(rule, record.getRule());
        assertEquals(rule, new Record().rule(rule).getRule());
    }

    @Test
    public void testEquals() {
        String transactionRecordID = "test-transaction-guid";
        Record record1 = new Record().transactionRecordID(transactionRecordID);

        assertEquals(record1, record1);
        assertEquals(record1, new Record().transactionRecordID(transactionRecordID));
        assertNotEquals(record1, new Record().transactionRecordID(transactionRecordID + "1"));
        assertNotEquals(record1, null);
    }

    @Test
    public void testHashcode() {
        String transactionRecordID = "test-transaction-guid";

        assertEquals(new Record().transactionRecordID(transactionRecordID).hashCode(),
                new Record().transactionRecordID(transactionRecordID).hashCode());
    }

    @Test
    public void testToString() {
        String transactionRecordID = "test-transaction-guid";

        assertEquals(new Record().transactionRecordID(transactionRecordID).toString(),
                new Record().transactionRecordID(transactionRecordID).toString());
    }
}
