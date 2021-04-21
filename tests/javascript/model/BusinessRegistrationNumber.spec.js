import expect from 'expect';
import BusinessRegistrationNumber from '../../src/model/BusinessRegistrationNumber';
import BusinessRegistrationNumberMask from '../../src/model/BusinessRegistrationNumberMask';

describe('BusinessRegistrationNumber', () => {
  it('should construct an instance of BusinessRegistrationNumber', () => {
    const businessRegistrationNumber = BusinessRegistrationNumber.constructFromObject({}, undefined);

    expect(businessRegistrationNumber).toBeInstanceOf(BusinessRegistrationNumber);
  });

  it('should not construct with no data', () => {
    const businessRegistrationNumber = BusinessRegistrationNumber.constructFromObject(undefined, null);

    expect(businessRegistrationNumber).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Name: 'test',
      Description: 'desc',
      Country: 'Canada',
      Jurisdiction: 'Alberta',
      Supported: true,
      Type: 'type',
      Masks: [BusinessRegistrationNumberMask.constructFromObject({ mask: 'AAA' })],
    };
    const businessRegistrationNumber = BusinessRegistrationNumber.constructFromObject(data);

    expect(businessRegistrationNumber.Name).toBe(data.Name);
    expect(businessRegistrationNumber.Description).toBe(data.Description);
    expect(businessRegistrationNumber.Country).toBe(data.Country);
    expect(businessRegistrationNumber.Jurisdiction).toBe(data.Jurisdiction);
    expect(businessRegistrationNumber.Supported).toBe(data.Supported);
    expect(businessRegistrationNumber.Type).toBe(data.Type);
    expect(businessRegistrationNumber.Masks).toStrictEqual(data.Masks);
  });
});
