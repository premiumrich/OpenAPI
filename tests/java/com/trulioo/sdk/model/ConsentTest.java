package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class ConsentTest {
    private Consent consent;

    @BeforeEach
    public void beforeEach() {
        consent = new Consent();
    }

    @Test
    public void testName() {
        String name = "test";
        consent.setName(name);

        assertEquals(name, consent.getName());
        assertEquals(name, new Consent().name(name).getName());
    }

    @Test
    public void testText() {
        String text = "desc";
        consent.setText(text);

        assertEquals(text, consent.getText());
        assertEquals(text, new Consent().text(text).getText());
    }

    @Test
    public void testUrl() {
        String url = "https://trulioo.com";
        consent.setUrl(url);

        assertEquals(url, consent.getUrl());
        assertEquals(url, new Consent().url(url).getUrl());
    }

    @Test
    public void testEquals() {
        String name = "test";
        Consent consent1 = new Consent().name(name);

        assertEquals(consent1, consent1);
        assertEquals(consent1, new Consent().name(name));
        assertNotEquals(consent1, new Consent().name(name + "1"));
        assertNotEquals(consent1, null);
    }

    @Test
    public void testHashcode() {
        String name = "test";

        assertEquals(new Consent().name(name).hashCode(), new Consent().name(name).hashCode());
    }

    @Test
    public void testToString() {
        String name = "test";

        assertEquals(new Consent().name(name).toString(), new Consent().name(name).toString());
    }
}
