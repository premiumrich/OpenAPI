package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.ArrayList;
import java.util.Arrays;

public class TransactionRecordResultAllOfTest {
    private TransactionRecordResultAllOf transactionRecordResultAllOf;

    @BeforeEach
    public void beforeEach() {
        transactionRecordResultAllOf = new TransactionRecordResultAllOf();
    }

    @Test
    public void testInputFields() {
        transactionRecordResultAllOf.addInputFieldsItem(new DataField());
        transactionRecordResultAllOf.addInputFieldsItem(new DataField());
        List<DataField> inputFields = Arrays.asList(new DataField().fieldName("test"));
        transactionRecordResultAllOf.setInputFields(inputFields);

        assertEquals(inputFields, transactionRecordResultAllOf.getInputFields());
        assertEquals(inputFields, new TransactionRecordResultAllOf().inputFields(inputFields).getInputFields());
    }

    @Test
    public void testEquals() {
        List<DataField> inputFields = Arrays.asList(new DataField().fieldName("test"));
        TransactionRecordResultAllOf transactionRecordResultAllOf1 = new TransactionRecordResultAllOf()
                .inputFields(inputFields);

        assertEquals(transactionRecordResultAllOf1, transactionRecordResultAllOf1);
        assertEquals(transactionRecordResultAllOf1, new TransactionRecordResultAllOf().inputFields(inputFields));
        assertNotEquals(transactionRecordResultAllOf1,
                new TransactionRecordResultAllOf().inputFields(new ArrayList<DataField>(inputFields) {
                    {
                        add(new DataField().fieldName("other"));
                    }
                }));
        assertNotEquals(transactionRecordResultAllOf1, null);
    }

    @Test
    public void testHashcode() {
        List<DataField> inputFields = Arrays.asList(new DataField().fieldName("test"));

        assertEquals(new TransactionRecordResultAllOf().inputFields(inputFields).hashCode(),
                new TransactionRecordResultAllOf().inputFields(inputFields).hashCode());
    }

    @Test
    public void testToString() {
        List<DataField> inputFields = Arrays.asList(new DataField().fieldName("test"));

        assertEquals(new TransactionRecordResultAllOf().inputFields(inputFields).toString(),
                new TransactionRecordResultAllOf().inputFields(inputFields).toString());

        assertEquals(new TransactionRecordResultAllOf().toString(), new TransactionRecordResultAllOf().toString());
    }
}
