package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.time.OffsetDateTime;

public class TransactionStatusTest {
    private TransactionStatus transactionStatus;

    @BeforeEach
    public void beforeEach() {
        transactionStatus = new TransactionStatus();
    }

    @Test
    public void testTransactionId() {
        String transactionId = "test-transaction-guid";
        transactionStatus.setTransactionId(transactionId);

        assertEquals(transactionId, transactionStatus.getTransactionId());
        assertEquals(transactionId, new TransactionStatus().transactionId(transactionId).getTransactionId());
    }

    @Test
    public void testTransactionRecordId() {
        String transactionRecordId = "test-transaction-guid";
        transactionStatus.setTransactionRecordId(transactionRecordId);

        assertEquals(transactionRecordId, transactionStatus.getTransactionRecordId());
        assertEquals(transactionRecordId,
                new TransactionStatus().transactionRecordId(transactionRecordId).getTransactionRecordId());
    }

    @Test
    public void testStatus() {
        String status = "match";
        transactionStatus.setStatus(status);

        assertEquals(status, transactionStatus.getStatus());
        assertEquals(status, new TransactionStatus().status(status).getStatus());
    }

    @Test
    public void testUploadedDt() {
        OffsetDateTime uploadedDt = OffsetDateTime.parse("2020-09-15T00:00:00+00:00");
        transactionStatus.setUploadedDt(uploadedDt);

        assertEquals(uploadedDt, transactionStatus.getUploadedDt());
        assertEquals(uploadedDt, new TransactionStatus().uploadedDt(uploadedDt).getUploadedDt());
    }

    @Test
    public void testIsTimedOut() {
        Boolean isTimedOut = false;
        transactionStatus.setIsTimedOut(isTimedOut);

        assertEquals(isTimedOut, transactionStatus.getIsTimedOut());
        assertEquals(isTimedOut, new TransactionStatus().isTimedOut(isTimedOut).getIsTimedOut());
    }

    @Test
    public void testEquals() {
        String transactionId = "test-transaction-guid";
        TransactionStatus transactionStatus1 = new TransactionStatus().transactionId(transactionId);

        assertEquals(transactionStatus1, transactionStatus1);
        assertEquals(transactionStatus1, new TransactionStatus().transactionId(transactionId));
        assertNotEquals(transactionStatus1, new TransactionStatus().transactionId(transactionId + "1"));
        assertNotEquals(transactionStatus1, null);
    }

    @Test
    public void testHashcode() {
        String transactionId = "test-transaction-guid";

        assertEquals(new TransactionStatus().transactionId(transactionId).hashCode(),
                new TransactionStatus().transactionId(transactionId).hashCode());
    }

    @Test
    public void testToString() {
        String transactionId = "test-transaction-guid";

        assertEquals(new TransactionStatus().transactionId(transactionId).toString(),
                new TransactionStatus().transactionId(transactionId).toString());
    }
}
