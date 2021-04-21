import expect from 'expect';
import DataField from '../../src/model/DataField';
import Record from '../../src/model/Record';
import ServiceError from '../../src/model/ServiceError';
import TransactionRecordResult from '../../src/model/TransactionRecordResult';

describe('TransactionRecordResult', () => {
  it('should construct an instance of TransactionRecordResult', () => {
    const transactionRecordResult = TransactionRecordResult.constructFromObject({}, undefined);

    expect(transactionRecordResult).toBeInstanceOf(TransactionRecordResult);
  });

  it('should not construct with no data', () => {
    const transactionRecordResult = TransactionRecordResult.constructFromObject(undefined, null);

    expect(transactionRecordResult).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      TransactionID: 'test-transaction-guid',
      UploadedDt: new Date('2017-07-11T21:47:50'),
      CountryCode: 'US',
      ProductName: 'Identity Verification',
      Record: Record.constructFromObject({ RecordStatus: 'nomatch' }),
      CustomerReferenceID: 'ref-123',
      Errors: [ServiceError.constructFromObject({ message: 'test' })],
      InputFields: [DataField.constructFromObject({ FieldName: 'FirstGivenName' })],
    };
    const transactionRecordResult = TransactionRecordResult.constructFromObject(data);

    expect(transactionRecordResult.TransactionID).toBe(data.TransactionID);
    expect(transactionRecordResult.UploadedDt).toStrictEqual(data.UploadedDt);
    expect(transactionRecordResult.CountryCode).toBe(data.CountryCode);
    expect(transactionRecordResult.ProductName).toBe(data.ProductName);
    expect(transactionRecordResult.Record).toStrictEqual(data.Record);
    expect(transactionRecordResult.CustomerReferenceID).toBe(data.CustomerReferenceID);
    expect(transactionRecordResult.Errors).toStrictEqual(data.Errors);
    expect(transactionRecordResult.InputFields).toStrictEqual(data.InputFields);
  });
});
