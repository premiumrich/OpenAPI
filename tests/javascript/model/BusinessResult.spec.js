import expect from 'expect';
import BusinessResult from '../../src/model/BusinessResult';
import Result from '../../src/model/Result';
import ServiceError from '../../src/model/ServiceError';

describe('BusinessResult', () => {
  it('should construct an instance of BusinessResult', () => {
    const businessResult = BusinessResult.constructFromObject({}, undefined);

    expect(businessResult).toBeInstanceOf(BusinessResult);
  });

  it('should not construct with no data', () => {
    const businessResult = BusinessResult.constructFromObject(undefined, null);

    expect(businessResult).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Results: [Result.constructFromObject({ MatchingScore: '100' })],
      DatasourceName: 'test',
      Errors: [ServiceError.constructFromObject({ message: 'test' })],
    };
    const businessResult = BusinessResult.constructFromObject(data);

    expect(businessResult.Results).toStrictEqual(data.Results);
    expect(businessResult.DatasourceName).toBe(data.DatasourceName);
    expect(businessResult.Errors).toStrictEqual(data.Errors);
  });
});
