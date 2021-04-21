import expect from 'expect';
import ServiceError from '../../src/model/ServiceError';

describe('ServiceError', () => {
  it('should construct an instance of ServiceError', () => {
    const serviceError = ServiceError.constructFromObject({}, undefined);

    expect(serviceError).toBeInstanceOf(ServiceError);
  });

  it('should not construct with no data', () => {
    const serviceError = ServiceError.constructFromObject(undefined, null);

    expect(serviceError).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Code: '1001',
      Message: 'test',
    };
    const serviceError = ServiceError.constructFromObject(data);

    expect(serviceError.Code).toBe(data.Code);
    expect(serviceError.Message).toBe(data.Message);
  });
});
