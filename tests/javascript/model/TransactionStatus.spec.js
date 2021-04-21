import expect from 'expect';
import TransactionStatus from '../../src/model/TransactionStatus';

describe('TransactionStatus', () => {
  it('should construct an instance of TransactionStatus', () => {
    const transactionStatus = TransactionStatus.constructFromObject({}, undefined);

    expect(transactionStatus).toBeInstanceOf(TransactionStatus);
  });

  it('should not construct with no data', () => {
    const transactionStatus = TransactionStatus.constructFromObject(undefined, null);

    expect(transactionStatus).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      TransactionId: 'test-transaction-guid',
      TransactionRecordId: 'test-transaction-record-guid',
      Status: 'nomatch',
      UploadedDt: new Date('2017-07-11T21:47:50'),
      IsTimedOut: false,
    };
    const transactionStatus = TransactionStatus.constructFromObject(data);

    expect(transactionStatus.TransactionId).toBe(data.TransactionId);
    expect(transactionStatus.TransactionRecordId).toBe(data.TransactionRecordId);
    expect(transactionStatus.Status).toBe(data.Status);
    expect(transactionStatus.UploadedDt).toStrictEqual(data.UploadedDt);
    expect(transactionStatus.IsTimedOut).toBe(data.IsTimedOut);
  });
});
