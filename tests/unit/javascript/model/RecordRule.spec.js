import expect from 'expect';
import RecordRule from '../../src/model/RecordRule';

describe('RecordRule', () => {
  it('should construct an instance of RecordRule', () => {
    const recordRule = RecordRule.constructFromObject({}, undefined);

    expect(recordRule).toBeInstanceOf(RecordRule);
  });

  it('should not construct with no data', () => {
    const recordRule = RecordRule.constructFromObject(undefined, null);

    expect(recordRule).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      RuleName: 'rule1',
      Note: 'test',
    };
    const recordRule = RecordRule.constructFromObject(data);

    expect(recordRule.RuleName).toBe(data.RuleName);
    expect(recordRule.Note).toBe(data.Note);
  });
});
