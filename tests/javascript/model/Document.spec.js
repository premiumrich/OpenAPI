import expect from 'expect';
import Document from '../../src/model/Document';

describe('Document', () => {
  it('should construct an instance of Document', () => {
    const document = Document.constructFromObject({}, undefined);

    expect(document).toBeInstanceOf(Document);
  });

  it('should not construct with no data', () => {
    const document = Document.constructFromObject(undefined, null);

    expect(document).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      DocumentFrontImage: 'base64',
      DocumentBackImage: 'base64',
      LivePhoto: 'base64',
      DocumentType: 'NationalId',
      AcceptIncompleteDocument: false,
      ValidateDocumentImageQuality: true,
    };
    const document = Document.constructFromObject(data);

    expect(document.DocumentFrontImage).toBe(data.DocumentFrontImage);
    expect(document.DocumentBackImage).toBe(data.DocumentBackImage);
    expect(document.LivePhoto).toBe(data.LivePhoto);
    expect(document.DocumentType).toBe(data.DocumentType);
    expect(document.AcceptIncompleteDocument).toBe(data.AcceptIncompleteDocument);
    expect(document.ValidateDocumentImageQuality).toBe(data.ValidateDocumentImageQuality);
  });
});
