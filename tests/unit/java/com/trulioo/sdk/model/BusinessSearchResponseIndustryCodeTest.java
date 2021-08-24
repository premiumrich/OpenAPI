package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class BusinessSearchResponseIndustryCodeTest {
    private BusinessSearchResponseIndustryCode businessSearchResponseIndustryCode;

    @BeforeEach
    public void beforeEach() {
        businessSearchResponseIndustryCode = new BusinessSearchResponseIndustryCode();
    }

    @Test
    public void testCode() {
        String code = "abc";
        businessSearchResponseIndustryCode.setCode(code);

        assertEquals(code, businessSearchResponseIndustryCode.getCode());
        assertEquals(code, new BusinessSearchResponseIndustryCode().code(code).getCode());
    }

    @Test
    public void testDescription() {
        String description = "desc";
        businessSearchResponseIndustryCode.setDescription(description);

        assertEquals(description, businessSearchResponseIndustryCode.getDescription());
        assertEquals(description, new BusinessSearchResponseIndustryCode().description(description).getDescription());
    }

    @Test
    public void testEquals() {
        String code = "abc";
        BusinessSearchResponseIndustryCode businessSearchResponseIndustryCode1 = new BusinessSearchResponseIndustryCode()
                .code(code);

        assertEquals(businessSearchResponseIndustryCode1, businessSearchResponseIndustryCode1);
        assertEquals(businessSearchResponseIndustryCode1, new BusinessSearchResponseIndustryCode().code(code));
        assertNotEquals(businessSearchResponseIndustryCode1, new BusinessSearchResponseIndustryCode().code(code + "1"));
        assertNotEquals(businessSearchResponseIndustryCode1, null);
    }

    @Test
    public void testHashcode() {
        String code = "abc";

        assertEquals(new BusinessSearchResponseIndustryCode().code(code).hashCode(),
                new BusinessSearchResponseIndustryCode().code(code).hashCode());
    }

    @Test
    public void testToString() {
        String code = "abc";

        assertEquals(new BusinessSearchResponseIndustryCode().code(code).toString(),
                new BusinessSearchResponseIndustryCode().code(code).toString());
    }
}
