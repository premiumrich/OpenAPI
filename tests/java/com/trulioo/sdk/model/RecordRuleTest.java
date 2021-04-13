package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class RecordRuleTest {
    private RecordRule recordRule;

    @BeforeEach
    public void beforeEach() {
        recordRule = new RecordRule();
    }

    @Test
    public void testRuleName() {
        String ruleName = "rule";
        recordRule.setRuleName(ruleName);

        assertEquals(ruleName, recordRule.getRuleName());
        assertEquals(ruleName, new RecordRule().ruleName(ruleName).getRuleName());
    }

    @Test
    public void testNote() {
        String note = "note";
        recordRule.setNote(note);

        assertEquals(note, recordRule.getNote());
        assertEquals(note, new RecordRule().note(note).getNote());
    }

    @Test
    public void testEquals() {
        String ruleName = "rule";
        RecordRule recordRule1 = new RecordRule().ruleName(ruleName);

        assertEquals(recordRule1, recordRule1);
        assertEquals(recordRule1, new RecordRule().ruleName(ruleName));
        assertNotEquals(recordRule1, new RecordRule().ruleName(ruleName + "1"));
        assertNotEquals(recordRule1, null);
    }

    @Test
    public void testHashcode() {
        String ruleName = "rule";

        assertEquals(new RecordRule().ruleName(ruleName).hashCode(), new RecordRule().ruleName(ruleName).hashCode());
    }

    @Test
    public void testToString() {
        String ruleName = "rule";

        assertEquals(new RecordRule().ruleName(ruleName).toString(), new RecordRule().ruleName(ruleName).toString());
    }
}
