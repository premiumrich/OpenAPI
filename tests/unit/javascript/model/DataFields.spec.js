import expect from 'expect';
import Business from '../../src/model/Business';
import Communication from '../../src/model/Communication';
import DataFields from '../../src/model/DataFields';
import Document from '../../src/model/Document';
import DriverLicence from '../../src/model/DriverLicence';
import Location from '../../src/model/Location';
import NationalId from '../../src/model/NationalId';
import Passport from '../../src/model/Passport';
import PersonInfo from '../../src/model/PersonInfo';

describe('DataFields', () => {
  it('should construct an instance of DataFields', () => {
    const dataFields = DataFields.constructFromObject({}, undefined);

    expect(dataFields).toBeInstanceOf(DataFields);
  });

  it('should not construct with no data', () => {
    const dataFields = DataFields.constructFromObject(undefined, null);

    expect(dataFields).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      PersonInfo: PersonInfo.constructFromObject({ FirstGivenName: 'A' }),
      Location: Location.constructFromObject({ City: 'Shibuya' }),
      Communication: Communication.constructFromObject({ EmailAddress: 'support@trulioo.com' }),
      DriverLicence: DriverLicence.constructFromObject({ Number: '123' }),
      NationalIds: [NationalId.constructFromObject({ Number: '123' })],
      Passport: Passport.constructFromObject({ Number: '123' }),
      Document: Document.constructFromObject({ DocumentFrontImage: 'base64' }),
      Business: Business.constructFromObject({ BusinessName: 'test' }),
      CountrySpecific: {
        data: {
          field: 'value',
        },
      },
    };
    const dataFields = DataFields.constructFromObject(data);

    expect(dataFields.PersonInfo).toStrictEqual(data.PersonInfo);
    expect(dataFields.Location).toStrictEqual(data.Location);
    expect(dataFields.Communication).toStrictEqual(data.Communication);
    expect(dataFields.DriverLicence).toStrictEqual(data.DriverLicence);
    expect(dataFields.NationalIds).toStrictEqual(data.NationalIds);
    expect(dataFields.Passport).toStrictEqual(data.Passport);
    expect(dataFields.Document).toStrictEqual(data.Document);
    expect(dataFields.Business).toStrictEqual(data.Business);
    expect(dataFields.CountrySpecific).toStrictEqual(data.CountrySpecific);
  });
});
