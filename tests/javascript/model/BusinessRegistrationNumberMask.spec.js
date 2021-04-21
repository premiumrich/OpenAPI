import expect from 'expect';
import BusinessRegistrationNumberMask from '../../src/model/BusinessRegistrationNumberMask';

describe('BusinessRegistrationNumberMask', () => {
  it('should construct an instance of BusinessRegistrationNumberMask', () => {
    const businessRegistrationNumberMask = BusinessRegistrationNumberMask.constructFromObject({}, undefined);

    expect(businessRegistrationNumberMask).toBeInstanceOf(BusinessRegistrationNumberMask);
  });

  it('should not construct with no data', () => {
    const businessRegistrationNumberMask = BusinessRegistrationNumberMask.constructFromObject(undefined, null);

    expect(businessRegistrationNumberMask).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Mask: 'AAA',
      IgnoreWhitespace: true,
      IgnoreSpecialCharacter: false,
    };
    const businessRegistrationNumberMask = BusinessRegistrationNumberMask.constructFromObject(data);

    expect(businessRegistrationNumberMask.Mask).toBe(data.Mask);
    expect(businessRegistrationNumberMask.IgnoreWhitespace).toBe(data.IgnoreWhitespace);
    expect(businessRegistrationNumberMask.IgnoreSpecialCharacter).toBe(data.IgnoreSpecialCharacter);
  });
});
