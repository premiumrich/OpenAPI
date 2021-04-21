import expect from 'expect';
import BusinessRecord from '../../src/model/BusinessRecord';
import BusinessResult from '../../src/model/BusinessResult';
import ServiceError from '../../src/model/ServiceError';

describe('BusinessRecord', () => {
  it('should construct an instance of BusinessRecord', () => {
    const businessRecord = BusinessRecord.constructFromObject({}, undefined);

    expect(businessRecord).toBeInstanceOf(BusinessRecord);
  });

  it('should not construct with no data', () => {
    const businessRecord = BusinessRecord.constructFromObject(undefined, null);

    expect(businessRecord).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      TransactionRecordID: 'test-transaction-guid',
      RecordStatus: 'match',
      DatasourceResults: [BusinessResult.constructFromObject({ DatasourceName: 'test' })],
      Errors: [ServiceError.constructFromObject({ message: 'test' })],
    };
    const businessRecord = BusinessRecord.constructFromObject(data);

    expect(businessRecord.TransactionRecordID).toBe(data.TransactionRecordID);
    expect(businessRecord.RecordStatus).toBe(data.RecordStatus);
    expect(businessRecord.DatasourceResults).toStrictEqual(data.DatasourceResults);
    expect(businessRecord.Errors).toStrictEqual(data.Errors);
  });
});
