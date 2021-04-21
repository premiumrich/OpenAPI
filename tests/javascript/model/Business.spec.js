import expect from 'expect';
import Business from '../../src/model/Business';

describe('Business', () => {
  it('should construct an instance of Business', () => {
    const business = Business.constructFromObject({}, undefined);

    expect(business).toBeInstanceOf(Business);
  });

  it('should not construct with no data', () => {
    const business = Business.constructFromObject(undefined, null);

    expect(business).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      BusinessName: 'test',
      BusinessRegistrationNumber: '123',
      DayOfIncorporation: 15,
      MonthOfIncorporation: 9,
      YearOfIncorporation: 2020,
      JurisdictionOfIncorporation: 'Alberta',
      ShareholderListDocument: true,
      FinancialInformationDocument: false,
      DunsNumber: '123',
      Entities: true,
    };
    const business = Business.constructFromObject(data);

    expect(business.BusinessName).toBe(data.BusinessName);
    expect(business.BusinessRegistrationNumber).toBe(data.BusinessRegistrationNumber);
    expect(business.DayOfIncorporation).toBe(data.DayOfIncorporation);
    expect(business.MonthOfIncorporation).toBe(data.MonthOfIncorporation);
    expect(business.YearOfIncorporation).toBe(data.YearOfIncorporation);
    expect(business.JurisdictionOfIncorporation).toBe(data.JurisdictionOfIncorporation);
    expect(business.ShareholderListDocument).toBe(data.ShareholderListDocument);
    expect(business.FinancialInformationDocument).toBe(data.FinancialInformationDocument);
    expect(business.DunsNumber).toBe(data.DunsNumber);
    expect(business.Entities).toBe(data.Entities);
  });
});
