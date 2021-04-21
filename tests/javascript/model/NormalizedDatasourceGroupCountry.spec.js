import expect from 'expect';
import NormalizedDatasourceField from '../../src/model/NormalizedDatasourceField';
import NormalizedDatasourceGroupCountry from '../../src/model/NormalizedDatasourceGroupCountry';

describe('NormalizedDatasourceGroupCountry', () => {
  it('should construct an instance of NormalizedDatasourceGroupCountry', () => {
    const normalizedDatasourceGroupCountry = NormalizedDatasourceGroupCountry.constructFromObject({}, undefined);

    expect(normalizedDatasourceGroupCountry).toBeInstanceOf(NormalizedDatasourceGroupCountry);
  });

  it('should not construct with no data', () => {
    const normalizedDatasourceGroupCountry = NormalizedDatasourceGroupCountry.constructFromObject(undefined, null);

    expect(normalizedDatasourceGroupCountry).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Name: 'Group1',
      Description: 'test',
      RequiredFields: [NormalizedDatasourceField.constructFromObject({ FieldName: 'required' })],
      OptionalFields: [NormalizedDatasourceField.constructFromObject({ FieldName: 'optional' })],
      AppendedFields: [NormalizedDatasourceField.constructFromObject({ FieldName: 'appended' })],
      OutputFields: [NormalizedDatasourceField.constructFromObject({ FieldName: 'output' })],
      SourceType: 'Government',
      UpdateFrequency: '3600',
      Coverage: '25%',
    };
    const normalizedDatasourceGroupCountry = NormalizedDatasourceGroupCountry.constructFromObject(data);

    expect(normalizedDatasourceGroupCountry.Name).toBe(data.Name);
    expect(normalizedDatasourceGroupCountry.Description).toBe(data.Description);
    expect(normalizedDatasourceGroupCountry.RequiredFields).toStrictEqual(data.RequiredFields);
    expect(normalizedDatasourceGroupCountry.OptionalFields).toStrictEqual(data.OptionalFields);
    expect(normalizedDatasourceGroupCountry.AppendedFields).toStrictEqual(data.AppendedFields);
    expect(normalizedDatasourceGroupCountry.OutputFields).toStrictEqual(data.OutputFields);
    expect(normalizedDatasourceGroupCountry.SourceType).toBe(data.SourceType);
    expect(normalizedDatasourceGroupCountry.UpdateFrequency).toBe(data.UpdateFrequency);
    expect(normalizedDatasourceGroupCountry.Coverage).toBe(data.Coverage);
  });
});
