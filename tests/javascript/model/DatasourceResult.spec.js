import expect from 'expect';
import AppendedField from '../../src/model/AppendedField';
import DatasourceField from '../../src/model/DatasourceField';
import DatasourceResult from '../../src/model/DatasourceResult';
import ServiceError from '../../src/model/ServiceError';

describe('DatasourceResult', () => {
  it('should construct an instance of DatasourceResult', () => {
    const datasourceResult = DatasourceResult.constructFromObject({}, undefined);

    expect(datasourceResult).toBeInstanceOf(DatasourceResult);
  });

  it('should not construct with no data', () => {
    const datasourceResult = DatasourceResult.constructFromObject(undefined, null);

    expect(datasourceResult).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      DatasourceStatus: 'match',
      DatasourceName: 'Credit Agency',
      DatasourceFields: [DatasourceField.constructFromObject({ FieldName: 'FirstGivenName' })],
      AppendedFields: [AppendedField.constructFromObject({ FieldName: 'FirstGivenName' })],
      Errors: [ServiceError.constructFromObject({ message: 'test' })],
      FieldGroups: ['Group1'],
    };
    const datasourceResult = DatasourceResult.constructFromObject(data);

    expect(datasourceResult.DatasourceStatus).toBe(data.DatasourceStatus);
    expect(datasourceResult.DatasourceName).toBe(data.DatasourceName);
    expect(datasourceResult.DatasourceFields).toStrictEqual(data.DatasourceFields);
    expect(datasourceResult.AppendedFields).toStrictEqual(data.AppendedFields);
    expect(datasourceResult.Errors).toStrictEqual(data.Errors);
    expect(datasourceResult.FieldGroups).toStrictEqual(data.FieldGroups);
  });
});
