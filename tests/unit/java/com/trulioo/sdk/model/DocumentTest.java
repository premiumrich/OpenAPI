package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class DocumentTest {
    private Document document;

    @BeforeEach
    public void beforeEach() {
        document = new Document();
    }

    @Test
    public void testDocumentFrontImage() {
        byte[] documentFrontImage = "base64".getBytes();
        document.setDocumentFrontImage(documentFrontImage);

        assertEquals(documentFrontImage, document.getDocumentFrontImage());
        assertEquals(documentFrontImage, new Document().documentFrontImage(documentFrontImage).getDocumentFrontImage());
    }

    @Test
    public void testDocumentBackImage() {
        byte[] documentBackImage = "base64".getBytes();
        document.setDocumentBackImage(documentBackImage);

        assertEquals(documentBackImage, document.getDocumentBackImage());
        assertEquals(documentBackImage, new Document().documentBackImage(documentBackImage).getDocumentBackImage());
    }

    @Test
    public void testLivePhoto() {
        byte[] livePhoto = "base64".getBytes();
        document.setLivePhoto(livePhoto);

        assertEquals(livePhoto, document.getLivePhoto());
        assertEquals(livePhoto, new Document().livePhoto(livePhoto).getLivePhoto());
    }

    @Test
    public void testDocumentType() {
        String documentType = "NationalId";
        document.setDocumentType(documentType);

        assertEquals(documentType, document.getDocumentType());
        assertEquals(documentType, new Document().documentType(documentType).getDocumentType());
    }

    @Test
    public void testAcceptIncompleteDocument() {
        Boolean acceptIncompleteDocument = true;
        document.setAcceptIncompleteDocument(acceptIncompleteDocument);

        assertEquals(acceptIncompleteDocument, document.getAcceptIncompleteDocument());
        assertEquals(acceptIncompleteDocument,
                new Document().acceptIncompleteDocument(acceptIncompleteDocument).getAcceptIncompleteDocument());
    }

    @Test
    public void testValidateDocumentImageQuality() {
        Boolean validateDocumentImageQuality = false;
        document.setValidateDocumentImageQuality(validateDocumentImageQuality);

        assertEquals(validateDocumentImageQuality, document.getValidateDocumentImageQuality());
        assertEquals(validateDocumentImageQuality, new Document()
                .validateDocumentImageQuality(validateDocumentImageQuality).getValidateDocumentImageQuality());
    }

    @Test
    public void testEquals() {
        byte[] documentFrontImage = "base64".getBytes();
        Document document1 = new Document().documentFrontImage(documentFrontImage);

        assertEquals(document1, document1);
        assertEquals(document1, new Document().documentFrontImage(documentFrontImage));
        assertNotEquals(document1, new Document().documentFrontImage("different".getBytes()));
        assertNotEquals(document1, null);
    }

    @Test
    public void testHashcode() {
        byte[] documentFrontImage = "base64".getBytes();

        assertEquals(new Document().documentFrontImage(documentFrontImage).hashCode(),
                new Document().documentFrontImage(documentFrontImage).hashCode());
    }

    @Test
    public void testToString() {
        byte[] documentFrontImage = "base64".getBytes();

        assertEquals(new Document().documentFrontImage(documentFrontImage).toString(),
                new Document().documentFrontImage(documentFrontImage).toString());
    }
}
