import expect from 'expect';
import Record from '../../src/model/Record';
import ServiceError from '../../src/model/ServiceError';
import VerifyResult from '../../src/model/VerifyResult';

describe('VerifyResult', () => {
  it('should construct an instance of VerifyResult', () => {
    const verifyResult = VerifyResult.constructFromObject({}, undefined);

    expect(verifyResult).toBeInstanceOf(VerifyResult);
  });

  it('should not construct with no data', () => {
    const verifyResult = VerifyResult.constructFromObject(undefined, null);

    expect(verifyResult).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      TransactionID: 'test-transaction-guid',
      UploadedDt: new Date('2017-07-11T21:47:50'),
      CountryCode: 'US',
      ProductName: 'Identity Verification',
      Record: Record.constructFromObject({ RecordStatus: 'match' }),
      CustomerReferenceID: 'ref-123',
      Errors: [ServiceError.constructFromObject({ message: 'test' })],
    };
    const verifyResult = VerifyResult.constructFromObject(data);

    expect(verifyResult.TransactionID).toBe(data.TransactionID);
    expect(verifyResult.UploadedDt).toStrictEqual(data.UploadedDt);
    expect(verifyResult.CountryCode).toBe(data.CountryCode);
    expect(verifyResult.ProductName).toBe(data.ProductName);
    expect(verifyResult.Record).toStrictEqual(data.Record);
    expect(verifyResult.CustomerReferenceID).toBe(data.CustomerReferenceID);
    expect(verifyResult.Errors).toStrictEqual(data.Errors);
  });
});
