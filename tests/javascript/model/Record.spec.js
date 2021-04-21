import expect from 'expect';
import DatasourceResult from '../../src/model/DatasourceResult';
import Record from '../../src/model/Record';
import RecordRule from '../../src/model/RecordRule';
import ServiceError from '../../src/model/ServiceError';

describe('Record', () => {
  it('should construct an instance of Record', () => {
    const record = Record.constructFromObject({}, undefined);

    expect(record).toBeInstanceOf(Record);
  });

  it('should not construct with no data', () => {
    const record = Record.constructFromObject(undefined, null);

    expect(record).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      TransactionRecordID: 'test-transaction-guid',
      RecordStatus: 'match',
      DatasourceResults: [DatasourceResult.constructFromObject({ DatasourceStatus: 'match' })],
      Errors: [ServiceError.constructFromObject({ message: 'test' })],
      Rule: RecordRule.constructFromObject({ RuleName: 'rule1' }),
    };
    const record = Record.constructFromObject(data);

    expect(record.TransactionRecordID).toBe(data.TransactionRecordID);
    expect(record.RecordStatus).toBe(data.RecordStatus);
    expect(record.DatasourceResults).toStrictEqual(data.DatasourceResults);
    expect(record.Errors).toStrictEqual(data.Errors);
    expect(record.Rule).toStrictEqual(data.Rule);
  });
});
