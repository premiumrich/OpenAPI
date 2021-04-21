import expect from 'expect';
import LocationAdditionalFields from '../../src/model/LocationAdditionalFields';

describe('LocationAdditionalFields', () => {
  it('should construct an instance of LocationAdditionalFields', () => {
    const locationAdditionalFields = LocationAdditionalFields.constructFromObject({}, undefined);

    expect(locationAdditionalFields).toBeInstanceOf(LocationAdditionalFields);
  });

  it('should not construct with no data', () => {
    const locationAdditionalFields = LocationAdditionalFields.constructFromObject(undefined, null);

    expect(locationAdditionalFields).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Address1: '1055 W Hastings St',
    };
    const locationAdditionalFields = LocationAdditionalFields.constructFromObject(data);

    expect(locationAdditionalFields.Address1).toBe(data.Address1);
  });
});
