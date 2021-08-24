package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import java.time.OffsetDateTime;
import java.util.List;
import java.util.Arrays;

import org.junit.jupiter.api.*;

public class BusinessSearchResponseTest {
    private BusinessSearchResponse businessSearchResponse;

    @BeforeEach
    public void beforeEach() {
        businessSearchResponse = new BusinessSearchResponse();
    }

    @Test
    public void testTransactionID() {
        String transactionID = "test-transaction-guid";
        businessSearchResponse.setTransactionID(transactionID);

        assertEquals(transactionID, businessSearchResponse.getTransactionID());
        assertEquals(transactionID, new BusinessSearchResponse().transactionID(transactionID).getTransactionID());
    }

    @Test
    public void testUploadedDt() {
        OffsetDateTime uploadedDt = OffsetDateTime.parse("2020-09-15T00:00:00+00:00");
        businessSearchResponse.setUploadedDt(uploadedDt);

        assertEquals(uploadedDt, businessSearchResponse.getUploadedDt());
        assertEquals(uploadedDt, new BusinessSearchResponse().uploadedDt(uploadedDt).getUploadedDt());
    }

    @Test
    public void testCountryCode() {
        String countryCode = "CA";
        businessSearchResponse.setCountryCode(countryCode);

        assertEquals(countryCode, businessSearchResponse.getCountryCode());
        assertEquals(countryCode, new BusinessSearchResponse().countryCode(countryCode).getCountryCode());
    }

    @Test
    public void testProductName() {
        String productName = "Identity Verification";
        businessSearchResponse.setProductName(productName);

        assertEquals(productName, businessSearchResponse.getProductName());
        assertEquals(productName, new BusinessSearchResponse().productName(productName).getProductName());
    }

    @Test
    public void testRecord() {
        BusinessRecord record = new BusinessRecord().recordStatus("match");
        businessSearchResponse.setRecord(record);

        assertEquals(record, businessSearchResponse.getRecord());
        assertEquals(record, new BusinessSearchResponse().record(record).getRecord());
    }

    @Test
    public void testErrors() {
        businessSearchResponse.addErrorsItem(new ServiceError());
        businessSearchResponse.addErrorsItem(new ServiceError());
        List<ServiceError> errors = Arrays.asList(new ServiceError().message("test"));
        businessSearchResponse.setErrors(errors);

        assertEquals(errors, businessSearchResponse.getErrors());
        assertEquals(errors, new BusinessSearchResponse().errors(errors).getErrors());
    }

    @Test
    public void testEquals() {
        String transactionID = "test-transaction-guid";
        BusinessSearchResponse businessSearchResponse1 = new BusinessSearchResponse().transactionID(transactionID);

        assertEquals(businessSearchResponse1, businessSearchResponse1);
        assertEquals(businessSearchResponse1, new BusinessSearchResponse().transactionID(transactionID));
        assertNotEquals(businessSearchResponse1, new BusinessSearchResponse().transactionID(transactionID + "1"));
        assertNotEquals(businessSearchResponse1, null);
    }

    @Test
    public void testHashcode() {
        String transactionID = "test-transaction-guid";

        assertEquals(new BusinessSearchResponse().transactionID(transactionID).hashCode(),
                new BusinessSearchResponse().transactionID(transactionID).hashCode());
    }

    @Test
    public void testToString() {
        String transactionID = "test-transaction-guid";

        assertEquals(new BusinessSearchResponse().transactionID(transactionID).toString(),
                new BusinessSearchResponse().transactionID(transactionID).toString());
    }
}
