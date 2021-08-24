package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

import java.util.List;
import java.util.Arrays;

public class BusinessResultTest {
    private BusinessResult businessResult;

    @BeforeEach
    public void beforeEach() {
        businessResult = new BusinessResult();
    }

    @Test
    public void testResults() {
        businessResult.addResultsItem(new Result());
        businessResult.addResultsItem(new Result());
        List<Result> results = Arrays.asList(new Result().businessName("name"));
        businessResult.setResults(results);

        assertEquals(results, businessResult.getResults());
        assertEquals(results, new BusinessResult().results(results).getResults());
    }

    @Test
    public void testDatasourceName() {
        String datasourceName = "test";
        businessResult.setDatasourceName(datasourceName);

        assertEquals(datasourceName, businessResult.getDatasourceName());
        assertEquals(datasourceName, new BusinessResult().datasourceName(datasourceName).getDatasourceName());
    }

    @Test
    public void testErrors() {
        assertEquals(null, businessResult.getErrors());
    }

    @Test
    public void testEquals() {
        String datasourceName = "test";
        BusinessResult businessResult1 = new BusinessResult().datasourceName(datasourceName);

        assertEquals(businessResult1, businessResult1);
        assertEquals(businessResult1, new BusinessResult().datasourceName(datasourceName));
        assertNotEquals(businessResult1, new BusinessResult().datasourceName(datasourceName + "1"));
        assertNotEquals(businessResult1, null);
    }

    @Test
    public void testHashcode() {
        String datasourceName = "test";

        assertEquals(new BusinessResult().datasourceName(datasourceName).hashCode(),
                new BusinessResult().datasourceName(datasourceName).hashCode());
    }

    @Test
    public void testToString() {
        String datasourceName = "test";

        assertEquals(new BusinessResult().datasourceName(datasourceName).toString(),
                new BusinessResult().datasourceName(datasourceName).toString());
    }
}
