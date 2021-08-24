import expect from 'expect';
import DataField from '../../src/model/DataField';

describe('DataField', () => {
  it('should construct an instance of DataField', () => {
    const dataField = DataField.constructFromObject({}, undefined);

    expect(dataField).toBeInstanceOf(DataField);
  });

  it('should not construct with no data', () => {
    const dataField = DataField.constructFromObject(undefined, null);

    expect(dataField).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      FieldName: 'FirstGivenName',
      Value: 'test',
      FieldGroup: 'Group1',
    };
    const dataField = DataField.constructFromObject(data);

    expect(dataField.FieldName).toBe(data.FieldName);
    expect(dataField.Value).toBe(data.Value);
    expect(dataField.FieldGroup).toBe(data.FieldGroup);
  });
});
