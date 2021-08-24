import expect from 'expect';
import DataField from '../../src/model/DataField';
import TransactionRecordResultAllOf from '../../src/model/TransactionRecordResultAllOf';

describe('TransactionRecordResultAllOf', () => {
  it('should construct an instance of TransactionRecordResultAllOf', () => {
    const transactionRecordResultAllOf = TransactionRecordResultAllOf.constructFromObject({}, undefined);

    expect(transactionRecordResultAllOf).toBeInstanceOf(TransactionRecordResultAllOf);
  });

  it('should not construct with no data', () => {
    const transactionRecordResultAllOf = TransactionRecordResultAllOf.constructFromObject(undefined, null);

    expect(transactionRecordResultAllOf).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      InputFields: [DataField.constructFromObject({ FieldName: 'FirstGivenName' })],
    };
    const transactionRecordResultAllOf = TransactionRecordResultAllOf.constructFromObject(data);

    expect(transactionRecordResultAllOf.InputFields).toStrictEqual(data.InputFields);
  });
});
