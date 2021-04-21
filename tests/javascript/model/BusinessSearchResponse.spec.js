import expect from 'expect';
import BusinessRecord from '../../src/model/BusinessRecord';
import BusinessSearchResponse from '../../src/model/BusinessSearchResponse';
import ServiceError from '../../src/model/ServiceError';

describe('BusinessSearchResponse', () => {
  it('should construct an instance of BusinessSearchResponse', () => {
    const businessSearchResponse = BusinessSearchResponse.constructFromObject({}, undefined);

    expect(businessSearchResponse).toBeInstanceOf(BusinessSearchResponse);
  });

  it('should not construct with no data', () => {
    const businessSearchResponse = BusinessSearchResponse.constructFromObject(undefined, null);

    expect(businessSearchResponse).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      TransactionID: 'test-transaction-guid',
      UploadedDt: new Date('2017-07-11T21:47:50'),
      CountryCode: 'US',
      ProductName: 'Identity Verification',
      Record: BusinessRecord.constructFromObject({ RecordStatus: 'match' }),
      Errors: [ServiceError.constructFromObject({ message: 'test' })],
    };
    const businessSearchResponse = BusinessSearchResponse.constructFromObject(data);

    expect(businessSearchResponse.TransactionID).toBe(data.TransactionID);
    expect(businessSearchResponse.UploadedDt).toStrictEqual(data.UploadedDt);
    expect(businessSearchResponse.CountryCode).toBe(data.CountryCode);
    expect(businessSearchResponse.ProductName).toBe(data.ProductName);
    expect(businessSearchResponse.Record).toStrictEqual(data.Record);
    expect(businessSearchResponse.Errors).toStrictEqual(data.Errors);
  });
});
