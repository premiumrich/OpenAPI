using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class DocumentTests
  {
    private Document document;

    public DocumentTests()
    {
      document = new Document();
    }

    [Fact]
    public void DocumentFrontImageTest()
    {
      byte[] documentFrontImage = Convert.FromBase64String("Zm9vYmFy");
      document.DocumentFrontImage = documentFrontImage;

      Assert.Equal(documentFrontImage, document.DocumentFrontImage);
      Assert.Equal(documentFrontImage, (new Document(documentFrontImage: documentFrontImage)).DocumentFrontImage);
    }

    [Fact]
    public void DocumentBackImageTest()
    {
      byte[] documentBackImage = Convert.FromBase64String("Zm9vYmFy");
      document.DocumentBackImage = documentBackImage;

      Assert.Equal(documentBackImage, document.DocumentBackImage);
      Assert.Equal(documentBackImage, (new Document(documentBackImage: documentBackImage)).DocumentBackImage);
    }

    [Fact]
    public void LivePhotoTest()
    {
      byte[] livePhoto = Convert.FromBase64String("Zm9vYmFy");
      document.LivePhoto = livePhoto;

      Assert.Equal(livePhoto, document.LivePhoto);
      Assert.Equal(livePhoto, (new Document(livePhoto: livePhoto)).LivePhoto);
    }

    [Fact]
    public void DocumentTypeTest()
    {
      string documentType = "test-documentType";
      document.DocumentType = documentType;

      Assert.Equal(documentType, document.DocumentType);
      Assert.Equal(documentType, (new Document(documentType: documentType)).DocumentType);
    }

    [Fact]
    public void AcceptIncompleteDocumentTest()
    {
      bool acceptIncompleteDocument = true;
      document.AcceptIncompleteDocument = acceptIncompleteDocument;

      Assert.Equal(acceptIncompleteDocument, document.AcceptIncompleteDocument);
      Assert.Equal(acceptIncompleteDocument, (new Document(acceptIncompleteDocument: acceptIncompleteDocument)).AcceptIncompleteDocument);
    }

    [Fact]
    public void ValidateDocumentImageQualityTest()
    {
      bool validateDocumentImageQuality = true;
      document.ValidateDocumentImageQuality = validateDocumentImageQuality;

      Assert.Equal(validateDocumentImageQuality, document.ValidateDocumentImageQuality);
      Assert.Equal(validateDocumentImageQuality, (new Document(validateDocumentImageQuality: validateDocumentImageQuality)).ValidateDocumentImageQuality);
    }

    [Fact]
    public void EqualsTest()
    {
      byte[] documentFrontImage = Convert.FromBase64String("Zm9vYmFy");
      Document documentFrontImage1 = new Document(documentFrontImage: documentFrontImage);

      Assert.Equal(documentFrontImage1, documentFrontImage1);
      Assert.Equal(documentFrontImage1, new Document(documentFrontImage: documentFrontImage));
      Assert.NotEqual(documentFrontImage1, new Document(documentFrontImage: Convert.FromBase64String("Zm9vYmFyZm9vYmFy")));
      Assert.False(documentFrontImage1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      byte[] documentFrontImage = Convert.FromBase64String("Zm9vYmFy");
      Document document = new Document(documentFrontImage: documentFrontImage);
      object obj = new Document(documentFrontImage: documentFrontImage);

      Assert.True(document.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      byte[] documentFrontImage = Convert.FromBase64String("Zm9vYmFy");
      byte[] documentBackImage = Convert.FromBase64String("Zm9vYmFy");
      byte[] livePhoto = Convert.FromBase64String("Zm9vYmFy");

      Document document1 = new Document();
      document1.DocumentType = "test-documentType";
      document1.AcceptIncompleteDocument = true;
      document1.ValidateDocumentImageQuality = true;
      document1.DocumentFrontImage = documentFrontImage;
      document1.DocumentBackImage = documentBackImage;
      document1.LivePhoto = livePhoto;

      Document document2 = new Document();
      document2.DocumentType = "test-documentType";
      document2.AcceptIncompleteDocument = true;
      document2.ValidateDocumentImageQuality = true;
      document2.DocumentFrontImage = documentFrontImage;
      document2.DocumentBackImage = documentBackImage;
      document2.LivePhoto = livePhoto;

      Assert.Equal(document1.GetHashCode(), document2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      byte[] documentFrontImage = Convert.FromBase64String("Zm9vYmFy");

      Assert.Equal(new Document(documentFrontImage: documentFrontImage).ToString(), new Document(documentFrontImage: documentFrontImage).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      byte[] documentFrontImage = Convert.FromBase64String("Zm9vYmFy");

      Assert.Equal(new Document(documentFrontImage: documentFrontImage).ToJson(), new Document(documentFrontImage: documentFrontImage).ToJson());
    }
  }
}