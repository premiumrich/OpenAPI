package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.time.OffsetDateTime;
import java.util.List;
import java.util.Arrays;

public class TransactionRecordResultTest {
    private TransactionRecordResult transactionRecordResult;

    @BeforeEach
    public void beforeEach() {
        transactionRecordResult = new TransactionRecordResult();
    }

    @Test
    public void testTransactionID() {
        String transactionID = "test-transaction-guid";
        transactionRecordResult.setTransactionID(transactionID);

        assertEquals(transactionID, transactionRecordResult.getTransactionID());
        assertEquals(transactionID, new TransactionRecordResult().transactionID(transactionID).getTransactionID());
    }

    @Test
    public void testUploadedDt() {
        OffsetDateTime uploadedDt = OffsetDateTime.parse("2020-09-15T00:00:00+00:00");
        transactionRecordResult.setUploadedDt(uploadedDt);

        assertEquals(uploadedDt, transactionRecordResult.getUploadedDt());
        assertEquals(uploadedDt, new TransactionRecordResult().uploadedDt(uploadedDt).getUploadedDt());
    }

    @Test
    public void testCountryCode() {
        String countryCode = "CA";
        transactionRecordResult.setCountryCode(countryCode);

        assertEquals(countryCode, transactionRecordResult.getCountryCode());
        assertEquals(countryCode, new TransactionRecordResult().countryCode(countryCode).getCountryCode());
    }

    @Test
    public void testProductName() {
        String productName = "Identity Verification";
        transactionRecordResult.setProductName(productName);

        assertEquals(productName, transactionRecordResult.getProductName());
        assertEquals(productName, new TransactionRecordResult().productName(productName).getProductName());
    }

    @Test
    public void testRecord() {
        Record record = new Record().recordStatus("nomatch");
        transactionRecordResult.setRecord(record);

        assertEquals(record, transactionRecordResult.getRecord());
        assertEquals(record, new TransactionRecordResult().record(record).getRecord());
    }

    @Test
    public void testCustomerReferenceID() {
        String customerReferenceID = "ref-123";
        transactionRecordResult.setCustomerReferenceID(customerReferenceID);

        assertEquals(customerReferenceID, transactionRecordResult.getCustomerReferenceID());
        assertEquals(customerReferenceID,
                new TransactionRecordResult().customerReferenceID(customerReferenceID).getCustomerReferenceID());
    }

    @Test
    public void testErrors() {
        transactionRecordResult.addErrorsItem(new ServiceError());
        transactionRecordResult.addErrorsItem(new ServiceError());
        List<ServiceError> errors = Arrays.asList(new ServiceError().message("test"));
        transactionRecordResult.setErrors(errors);

        assertEquals(errors, transactionRecordResult.getErrors());
        assertEquals(errors, new TransactionRecordResult().errors(errors).getErrors());
    }

    @Test
    public void testInputFields() {
        transactionRecordResult.addInputFieldsItem(new DataField());
        transactionRecordResult.addInputFieldsItem(new DataField());
        List<DataField> inputFields = Arrays.asList(new DataField().fieldName("field"));
        transactionRecordResult.setInputFields(inputFields);

        assertEquals(inputFields, transactionRecordResult.getInputFields());
        assertEquals(inputFields, new TransactionRecordResult().inputFields(inputFields).getInputFields());
    }

    @Test
    public void testEquals() {
        String transactionID = "test-transaction-guid";
        TransactionRecordResult transactionRecordResult1 = new TransactionRecordResult().transactionID(transactionID);

        assertEquals(transactionRecordResult1, transactionRecordResult1);
        assertEquals(transactionRecordResult1, new TransactionRecordResult().transactionID(transactionID));
        assertNotEquals(transactionRecordResult1, new TransactionRecordResult().transactionID(transactionID + "1"));
        assertNotEquals(transactionRecordResult1, null);
    }

    @Test
    public void testHashcode() {
        String transactionID = "test-transaction-guid";

        assertEquals(new TransactionRecordResult().transactionID(transactionID).hashCode(),
                new TransactionRecordResult().transactionID(transactionID).hashCode());
    }

    @Test
    public void testToString() {
        String transactionID = "test-transaction-guid";

        assertEquals(new TransactionRecordResult().transactionID(transactionID).toString(),
                new TransactionRecordResult().transactionID(transactionID).toString());
    }
}
