package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.time.OffsetDateTime;
import java.util.List;
import java.util.Arrays;

public class VerifyResultTest {
    private VerifyResult verifyResult;

    @BeforeEach
    public void beforeEach() {
        verifyResult = new VerifyResult();
    }

    @Test
    public void testTransactionID() {
        String transactionID = "test-transaction-guid";
        verifyResult.setTransactionID(transactionID);

        assertEquals(transactionID, verifyResult.getTransactionID());
        assertEquals(transactionID, new VerifyResult().transactionID(transactionID).getTransactionID());
    }

    @Test
    public void testUploadedDt() {
        OffsetDateTime uploadedDt = OffsetDateTime.parse("2020-09-15T00:00:00+00:00");
        verifyResult.setUploadedDt(uploadedDt);

        assertEquals(uploadedDt, verifyResult.getUploadedDt());
        assertEquals(uploadedDt, new VerifyResult().uploadedDt(uploadedDt).getUploadedDt());
    }

    @Test
    public void testCountryCode() {
        String countryCode = "CA";
        verifyResult.setCountryCode(countryCode);

        assertEquals(countryCode, verifyResult.getCountryCode());
        assertEquals(countryCode, new VerifyResult().countryCode(countryCode).getCountryCode());
    }

    @Test
    public void testProductName() {
        String productName = "Identity Verification";
        verifyResult.setProductName(productName);

        assertEquals(productName, verifyResult.getProductName());
        assertEquals(productName, new VerifyResult().productName(productName).getProductName());
    }

    @Test
    public void testRecord() {
        Record record = new Record().recordStatus("match");
        verifyResult.setRecord(record);

        assertEquals(record, verifyResult.getRecord());
        assertEquals(record, new VerifyResult().record(record).getRecord());
    }

    @Test
    public void testCustomerReferenceID() {
        String customerReferenceID = "ref-123";
        verifyResult.setCustomerReferenceID(customerReferenceID);

        assertEquals(customerReferenceID, verifyResult.getCustomerReferenceID());
        assertEquals(customerReferenceID,
                new VerifyResult().customerReferenceID(customerReferenceID).getCustomerReferenceID());
    }

    @Test
    public void testErrors() {
        verifyResult.addErrorsItem(new ServiceError());
        verifyResult.addErrorsItem(new ServiceError());
        List<ServiceError> errors = Arrays.asList(new ServiceError().message("test"));
        verifyResult.setErrors(errors);

        assertEquals(errors, verifyResult.getErrors());
        assertEquals(errors, new VerifyResult().errors(errors).getErrors());
    }

    @Test
    public void testEquals() {
        String transactionID = "test-transaction-guid";
        VerifyResult verifyResult1 = new VerifyResult().transactionID(transactionID);

        assertEquals(verifyResult1, verifyResult1);
        assertEquals(verifyResult1, new VerifyResult().transactionID(transactionID));
        assertNotEquals(verifyResult1, new VerifyResult().transactionID(transactionID + "1"));
        assertNotEquals(verifyResult1, null);
    }

    @Test
    public void testHashcode() {
        String transactionID = "test-transaction-guid";

        assertEquals(new VerifyResult().transactionID(transactionID).hashCode(),
                new VerifyResult().transactionID(transactionID).hashCode());
    }

    @Test
    public void testToString() {
        String transactionID = "test-transaction-guid";

        assertEquals(new VerifyResult().transactionID(transactionID).toString(),
                new VerifyResult().transactionID(transactionID).toString());
    }
}
