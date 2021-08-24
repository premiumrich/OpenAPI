import expect from 'expect';
import Business from '../../src/model/Business';
import Communication from '../../src/model/Communication';
import Document from '../../src/model/Document';
import DriverLicence from '../../src/model/DriverLicence';
import Location from '../../src/model/Location';
import NationalId from '../../src/model/NationalId';
import Passport from '../../src/model/Passport';
import PersonInfo from '../../src/model/PersonInfo';
import TestEntityDataFields from '../../src/model/TestEntityDataFields';

describe('TestEntityDataFields', () => {
  it('should construct an instance of TestEntityDataFields', () => {
    const testEntityDataFields = TestEntityDataFields.constructFromObject({}, undefined);

    expect(testEntityDataFields).toBeInstanceOf(TestEntityDataFields);
  });

  it('should not construct with no data', () => {
    const testEntityDataFields = TestEntityDataFields.constructFromObject(undefined, null);

    expect(testEntityDataFields).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Location: Location.constructFromObject({ BuildingNumber: '1055' }),
      TestEntityName: 'Test1',
      PersonInfo: PersonInfo.constructFromObject({ FirstGivenName: 'A' }),
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
    const testEntityDataFields = TestEntityDataFields.constructFromObject(data);

    expect(testEntityDataFields.Location).toStrictEqual(data.Location);
    expect(testEntityDataFields.TestEntityName).toBe(data.TestEntityName);
    expect(testEntityDataFields.PersonInfo).toStrictEqual(data.PersonInfo);
    expect(testEntityDataFields.Communication).toStrictEqual(data.Communication);
    expect(testEntityDataFields.DriverLicence).toStrictEqual(data.DriverLicence);
    expect(testEntityDataFields.NationalIds).toStrictEqual(data.NationalIds);
    expect(testEntityDataFields.Passport).toStrictEqual(data.Passport);
    expect(testEntityDataFields.Document).toStrictEqual(data.Document);
    expect(testEntityDataFields.Business).toStrictEqual(data.Business);
    expect(testEntityDataFields.CountrySpecific).toStrictEqual(data.CountrySpecific);
  });
});
