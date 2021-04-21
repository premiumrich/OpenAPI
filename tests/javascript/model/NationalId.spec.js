import expect from 'expect';
import NationalId from '../../src/model/NationalId';

describe('NationalId', () => {
  it('should construct an instance of NationalId', () => {
    const nationalId = NationalId.constructFromObject({}, undefined);

    expect(nationalId).toBeInstanceOf(NationalId);
  });

  it('should not construct with no data', () => {
    const nationalId = NationalId.constructFromObject(undefined, null);

    expect(nationalId).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Number: '123',
      Type: 'Health',
      DistrictOfIssue: 'District 12',
      CityOfIssue: 'Shibuya',
      ProvinceOfIssue: 'CA',
      CountyOfIssue: 'Arroyo Negro',
    };
    const nationalId = NationalId.constructFromObject(data);

    expect(nationalId.Number).toBe(data.Number);
    expect(nationalId.Type).toBe(data.Type);
    expect(nationalId.DistrictOfIssue).toBe(data.DistrictOfIssue);
    expect(nationalId.CityOfIssue).toBe(data.CityOfIssue);
    expect(nationalId.ProvinceOfIssue).toBe(data.ProvinceOfIssue);
    expect(nationalId.CountyOfIssue).toBe(data.CountyOfIssue);
  });
});
