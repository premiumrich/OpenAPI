import expect from 'expect';
import Consent from '../../src/model/Consent';

describe('Consent', () => {
  it('should construct an instance of Consent', () => {
    const consent = Consent.constructFromObject({}, undefined);

    expect(consent).toBeInstanceOf(Consent);
  });

  it('should not construct with no data', () => {
    const consent = Consent.constructFromObject(undefined, null);

    expect(consent).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Name: 'Credit Agency',
      Text: 'A credit agency',
      Url: 'https://trulioo.com',
    };
    const consent = Consent.constructFromObject(data);

    expect(consent.Name).toBe(data.Name);
    expect(consent.Text).toBe(data.Text);
    expect(consent.Url).toBe(data.Url);
  });
});
