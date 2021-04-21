import expect from 'expect';
import Location from '../../src/model/Location';
import LocationAdditionalFields from '../../src/model/LocationAdditionalFields';

describe('Location', () => {
  it('should construct an instance of Location', () => {
    const location = Location.constructFromObject({}, undefined);

    expect(location).toBeInstanceOf(Location);
  });

  it('should not construct with no data', () => {
    const location = Location.constructFromObject(undefined, null);

    expect(location).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      BuildingNumber: '10',
      BuildingName: 'Guinness',
      UnitNumber: '1055',
      StreetName: 'W Hastings',
      StreetType: 'St',
      City: 'Shibuya',
      Suburb: 'West',
      County: 'District 12',
      StateProvinceCode: 'BC',
      Country: 'Canada',
      PostalCode: 'H0H0H0',
      POBox: '10001',
      AdditionalFields: LocationAdditionalFields.constructFromObject({ Address1: '1055 W Hastings St' }),
    };
    const location = Location.constructFromObject(data);

    expect(location.BuildingNumber).toBe(data.BuildingNumber);
    expect(location.BuildingName).toBe(data.BuildingName);
    expect(location.UnitNumber).toBe(data.UnitNumber);
    expect(location.StreetName).toBe(data.StreetName);
    expect(location.StreetType).toBe(data.StreetType);
    expect(location.City).toBe(data.City);
    expect(location.Suburb).toBe(data.Suburb);
    expect(location.County).toBe(data.County);
    expect(location.StateProvinceCode).toBe(data.StateProvinceCode);
    expect(location.Country).toBe(data.Country);
    expect(location.PostalCode).toBe(data.PostalCode);
    expect(location.POBox).toBe(data.POBox);
    expect(location.AdditionalFields).toStrictEqual(data.AdditionalFields);
  });
});
