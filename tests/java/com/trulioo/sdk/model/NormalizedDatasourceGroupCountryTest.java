package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class NormalizedDatasourceGroupCountryTest {
    private NormalizedDatasourceGroupCountry normalizedDatasourceGroupCountry;

    @BeforeEach
    public void beforeEach() {
        normalizedDatasourceGroupCountry = new NormalizedDatasourceGroupCountry();
    }

    @Test
    public void testName() {
        String name = "test";
        normalizedDatasourceGroupCountry.setName(name);

        assertEquals(name, normalizedDatasourceGroupCountry.getName());
        assertEquals(name, new NormalizedDatasourceGroupCountry().name(name).getName());
    }

    @Test
    public void testDescription() {
        String description = "desc";
        normalizedDatasourceGroupCountry.setDescription(description);

        assertEquals(description, normalizedDatasourceGroupCountry.getDescription());
        assertEquals(description, new NormalizedDatasourceGroupCountry().description(description).getDescription());
    }

    @Test
    public void testRequiredFields() {
        normalizedDatasourceGroupCountry.addRequiredFieldsItem(new NormalizedDatasourceField());
        normalizedDatasourceGroupCountry.addRequiredFieldsItem(new NormalizedDatasourceField());
        List<NormalizedDatasourceField> requiredFields = Arrays
                .asList(new NormalizedDatasourceField().fieldName("required"));
        normalizedDatasourceGroupCountry.setRequiredFields(requiredFields);

        assertEquals(requiredFields, normalizedDatasourceGroupCountry.getRequiredFields());
        assertEquals(requiredFields,
                new NormalizedDatasourceGroupCountry().requiredFields(requiredFields).getRequiredFields());
    }

    @Test
    public void testOptionalFields() {
        normalizedDatasourceGroupCountry.addOptionalFieldsItem(new NormalizedDatasourceField());
        normalizedDatasourceGroupCountry.addOptionalFieldsItem(new NormalizedDatasourceField());
        List<NormalizedDatasourceField> optionalFields = Arrays
                .asList(new NormalizedDatasourceField().fieldName("optional"));
        normalizedDatasourceGroupCountry.setOptionalFields(optionalFields);

        assertEquals(optionalFields, normalizedDatasourceGroupCountry.getOptionalFields());
        assertEquals(optionalFields,
                new NormalizedDatasourceGroupCountry().optionalFields(optionalFields).getOptionalFields());
    }

    @Test
    public void testAppendedFields() {
        normalizedDatasourceGroupCountry.addAppendedFieldsItem(new NormalizedDatasourceField());
        normalizedDatasourceGroupCountry.addAppendedFieldsItem(new NormalizedDatasourceField());
        List<NormalizedDatasourceField> appendedFields = Arrays
                .asList(new NormalizedDatasourceField().fieldName("appended"));
        normalizedDatasourceGroupCountry.setAppendedFields(appendedFields);

        assertEquals(appendedFields, normalizedDatasourceGroupCountry.getAppendedFields());
        assertEquals(appendedFields,
                new NormalizedDatasourceGroupCountry().appendedFields(appendedFields).getAppendedFields());
    }

    @Test
    public void testOutputFields() {
        normalizedDatasourceGroupCountry.addOutputFieldsItem(new NormalizedDatasourceField());
        normalizedDatasourceGroupCountry.addOutputFieldsItem(new NormalizedDatasourceField());
        List<NormalizedDatasourceField> outputFields = Arrays
                .asList(new NormalizedDatasourceField().fieldName("output"));
        normalizedDatasourceGroupCountry.setOutputFields(outputFields);

        assertEquals(outputFields, normalizedDatasourceGroupCountry.getOutputFields());
        assertEquals(outputFields, new NormalizedDatasourceGroupCountry().outputFields(outputFields).getOutputFields());
    }

    @Test
    public void testSourceType() {
        String sourceType = "source";
        normalizedDatasourceGroupCountry.setSourceType(sourceType);

        assertEquals(sourceType, normalizedDatasourceGroupCountry.getSourceType());
        assertEquals(sourceType, new NormalizedDatasourceGroupCountry().sourceType(sourceType).getSourceType());
    }

    @Test
    public void testUpdateFrequency() {
        String updateFrequency = "3600";
        normalizedDatasourceGroupCountry.setUpdateFrequency(updateFrequency);

        assertEquals(updateFrequency, normalizedDatasourceGroupCountry.getUpdateFrequency());
        assertEquals(updateFrequency,
                new NormalizedDatasourceGroupCountry().updateFrequency(updateFrequency).getUpdateFrequency());
    }

    @Test
    public void testCoverage() {
        String coverage = "25%";
        normalizedDatasourceGroupCountry.setCoverage(coverage);

        assertEquals(coverage, normalizedDatasourceGroupCountry.getCoverage());
        assertEquals(coverage, new NormalizedDatasourceGroupCountry().coverage(coverage).getCoverage());
    }

    @Test
    public void testEquals() {
        String name = "test";
        NormalizedDatasourceGroupCountry normalizedDatasourceGroupCountry1 = new NormalizedDatasourceGroupCountry()
                .name(name);

        assertEquals(normalizedDatasourceGroupCountry1, normalizedDatasourceGroupCountry1);
        assertEquals(normalizedDatasourceGroupCountry1, new NormalizedDatasourceGroupCountry().name(name));
        assertNotEquals(normalizedDatasourceGroupCountry1, new NormalizedDatasourceGroupCountry().name(name + "1"));
        assertNotEquals(normalizedDatasourceGroupCountry1, null);
    }

    @Test
    public void testHashcode() {
        String name = "test";

        assertEquals(new NormalizedDatasourceGroupCountry().name(name).hashCode(),
                new NormalizedDatasourceGroupCountry().name(name).hashCode());
    }

    @Test
    public void testToString() {
        String name = "test";

        assertEquals(new NormalizedDatasourceGroupCountry().name(name).toString(),
                new NormalizedDatasourceGroupCountry().name(name).toString());
    }
}
