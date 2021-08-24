import expect from 'expect';
import CountrySubdivision from '../../src/model/CountrySubdivision';

describe('CountrySubdivision', () => {
  it('should construct an instance of CountrySubdivision', () => {
    const countrySubdivision = CountrySubdivision.constructFromObject({}, undefined);

    expect(countrySubdivision).toBeInstanceOf(CountrySubdivision);
  });

  it('should not construct with no data', () => {
    const countrySubdivision = CountrySubdivision.constructFromObject(undefined, null);

    expect(countrySubdivision).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Name: 'California',
      Code: 'US-CA',
      ParentCode: 'US',
    };
    const countrySubdivision = CountrySubdivision.constructFromObject(data);

    expect(countrySubdivision.Name).toBe(data.Name);
    expect(countrySubdivision.Code).toBe(data.Code);
    expect(countrySubdivision.ParentCode).toBe(data.ParentCode);
  });
});
