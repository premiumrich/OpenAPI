import expect from 'expect';
import AppendedField from '../../src/model/AppendedField';

describe('AppendedField', () => {
  it('should construct an instance of AppendedField', () => {
    const appendedField = AppendedField.constructFromObject({}, undefined);

    expect(appendedField).toBeInstanceOf(AppendedField);
  });

  it('should not construct with no data', () => {
    const appendedField = AppendedField.constructFromObject(undefined, null);

    expect(appendedField).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      FieldName: 'FirstGivenName',
      Data: 'test',
    };
    const appendedField = AppendedField.constructFromObject(data);

    expect(appendedField.FieldName).toBe(data.FieldName);
    expect(appendedField.Data).toBe(data.Data);
  });
});
