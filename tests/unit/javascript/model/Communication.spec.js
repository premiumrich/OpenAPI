import expect from 'expect';
import Communication from '../../src/model/Communication';

describe('Communication', () => {
  it('should construct an instance of Communication', () => {
    const communication = Communication.constructFromObject({}, undefined);

    expect(communication).toBeInstanceOf(Communication);
  });

  it('should not construct with no data', () => {
    const communication = Communication.constructFromObject(undefined, null);

    expect(communication).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      MobileNumber: '18887730179',
      Telephone: '18887730179',
      Telephone2: '18887730179',
      EmailAddress: 'support@trulioo.com',
    };
    const communication = Communication.constructFromObject(data);

    expect(communication.MobileNumber).toBe(data.MobileNumber);
    expect(communication.Telephone).toBe(data.Telephone);
    expect(communication.Telephone2).toBe(data.Telephone2);
    expect(communication.EmailAddress).toBe(data.EmailAddress);
  });
});
