import expect from 'expect';
import NormalizedDatasourceField from '../../src/model/NormalizedDatasourceField';

describe('NormalizedDatasourceField', () => {
  it('should construct an instance of NormalizedDatasourceField', () => {
    const normalizedDatasourceField = NormalizedDatasourceField.constructFromObject({}, undefined);

    expect(normalizedDatasourceField).toBeInstanceOf(NormalizedDatasourceField);
  });

  it('should not construct with no data', () => {
    const normalizedDatasourceField = NormalizedDatasourceField.constructFromObject(undefined, null);

    expect(normalizedDatasourceField).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      FieldName: 'FirstGivenName',
      Type: 'String',
    };
    const normalizedDatasourceField = NormalizedDatasourceField.constructFromObject(data);

    expect(normalizedDatasourceField.FieldName).toBe(data.FieldName);
    expect(normalizedDatasourceField.Type).toBe(data.Type);
  });
});
