package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class BusinessRecordTest {
    private BusinessRecord businessRecord;

    @BeforeEach
    public void beforeEach() {
        businessRecord = new BusinessRecord();
    }

    @Test
    public void testTransactionRecordID() {
        String transactionRecordID = "test-transaction-guid";
        businessRecord.setTransactionRecordID(transactionRecordID);

        assertEquals(transactionRecordID, businessRecord.getTransactionRecordID());
        assertEquals(transactionRecordID,
                new BusinessRecord().transactionRecordID(transactionRecordID).getTransactionRecordID());
    }

    @Test
    public void testRecordStatus() {
        String recordStatus = "match";
        businessRecord.setRecordStatus(recordStatus);

        assertEquals(recordStatus, businessRecord.getRecordStatus());
        assertEquals(recordStatus, new BusinessRecord().recordStatus(recordStatus).getRecordStatus());
    }

    @Test
    public void testDatasourceResults() {
        businessRecord.addDatasourceResultsItem(new BusinessResult());
        businessRecord.addDatasourceResultsItem(new BusinessResult());
        List<BusinessResult> datasourceResults = Arrays.asList(new BusinessResult().datasourceName("test"));
        businessRecord.setDatasourceResults(datasourceResults);

        assertEquals(datasourceResults, businessRecord.getDatasourceResults());
        assertEquals(datasourceResults,
                new BusinessRecord().datasourceResults(datasourceResults).getDatasourceResults());
    }

    @Test
    public void testErrors() {
        businessRecord.addErrorsItem(new ServiceError());
        businessRecord.addErrorsItem(new ServiceError());
        List<ServiceError> errors = Arrays.asList(new ServiceError().message("test"));
        businessRecord.setErrors(errors);

        assertEquals(errors, businessRecord.getErrors());
        assertEquals(errors, new BusinessRecord().errors(errors).getErrors());
    }

    @Test
    public void testEquals() {
        String transactionRecordID = "test-transaction-guid";
        BusinessRecord businessRecord1 = new BusinessRecord().transactionRecordID(transactionRecordID);

        assertEquals(businessRecord1, businessRecord1);
        assertEquals(businessRecord1, new BusinessRecord().transactionRecordID(transactionRecordID));
        assertNotEquals(businessRecord1, new BusinessRecord().transactionRecordID(transactionRecordID + "1"));
        assertNotEquals(businessRecord1, null);
    }

    @Test
    public void testHashcode() {
        String transactionRecordID = "test-transaction-guid";

        assertEquals(new BusinessRecord().transactionRecordID(transactionRecordID).hashCode(),
                new BusinessRecord().transactionRecordID(transactionRecordID).hashCode());
    }

    @Test
    public void testToString() {
        String transactionRecordID = "test-transaction-guid";

        assertEquals(new BusinessRecord().transactionRecordID(transactionRecordID).toString(),
                new BusinessRecord().transactionRecordID(transactionRecordID).toString());
    }
}
