import expect from 'expect';
import Address from '../../src/model/Address';

describe('Address', () => {
  it('should construct an instance of Address', () => {
    const address = Address.constructFromObject({}, undefined);

    expect(address).toBeInstanceOf(Address);
  });

  it('should not construct with no data', () => {
    const address = Address.constructFromObject(undefined, null);

    expect(address).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      UnitNumber: '10',
      BuildingNumber: '1055',
      BuildingName: 'Guinness',
      StreetName: 'W Hastings',
      StreetType: 'St',
      City: 'Shibuya',
      Suburb: 'West',
      StateProvinceCode: 'BC',
      PostalCode: 'H0H0H0',
      Address1: '1055 W Hastings St',
      AddressType: 'Work',
      StateProvince: 'British Columbia',
      Country: 'Canada',
      CountryCode: 'CA',
    };
    const address = Address.constructFromObject(data);

    expect(address.UnitNumber).toBe(data.UnitNumber);
    expect(address.BuildingNumber).toBe(data.BuildingNumber);
    expect(address.BuildingName).toBe(data.BuildingName);
    expect(address.StreetName).toBe(data.StreetName);
    expect(address.StreetType).toBe(data.StreetType);
    expect(address.City).toBe(data.City);
    expect(address.Suburb).toBe(data.Suburb);
    expect(address.StateProvinceCode).toBe(data.StateProvinceCode);
    expect(address.PostalCode).toBe(data.PostalCode);
    expect(address.Address1).toBe(data.Address1);
    expect(address.AddressType).toBe(data.AddressType);
    expect(address.StateProvince).toBe(data.StateProvince);
    expect(address.Country).toBe(data.Country);
    expect(address.CountryCode).toBe(data.CountryCode);
  });
});
