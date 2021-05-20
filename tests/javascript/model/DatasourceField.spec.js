import expect from 'expect';
import DatasourceField from '../../src/model/DatasourceField';

describe('DatasourceField', () => {
  it('should construct an instance of DatasourceField', () => {
    const datasourceField = DatasourceField.constructFromObject({}, undefined);

    expect(datasourceField).toBeInstanceOf(DatasourceField);
  });

  it('should not construct with no data', () => {
    const datasourceField = DatasourceField.constructFromObject(undefined, null);

    expect(datasourceField).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      FieldName: 'FirstGivenName',
      Status: 'match',
      FieldGroup: 'Group1',
      MatchPrecision: 'testMatchPrecision',
    };
    const datasourceField = DatasourceField.constructFromObject(data);

    expect(datasourceField.FieldName).toBe(data.FieldName);
    expect(datasourceField.Status).toBe(data.Status);
    expect(datasourceField.FieldGroup).toBe(data.FieldGroup);
    expect(datasourceField.MatchPrecision).toBe(data.MatchPrecision);
  });
});
