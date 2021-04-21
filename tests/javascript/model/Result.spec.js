import expect from 'expect';
import Address from '../../src/model/Address';
import BusinessSearchResponseIndustryCode from '../../src/model/BusinessSearchResponseIndustryCode';
import Result from '../../src/model/Result';

describe('Result', () => {
  it('should construct an instance of Result', () => {
    const result = Result.constructFromObject({}, undefined);

    expect(result).toBeInstanceOf(Result);
  });

  it('should not construct with no data', () => {
    const result = Result.constructFromObject(undefined, null);

    expect(result).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Index: '1',
      BusinessName: 'Test',
      MatchingScore: '100',
      BusinessRegistrationNumber: '123',
      DUNSNumber: '123',
      BusinessTaxIDNumber: '123',
      BusinessLicenseNumber: '123',
      JurisdictionOfIncorporation: 'Alberta',
      FullAddress: '1055 W Hastings St',
      BusinessStatus: 'Active',
      TradeStyleName: 'Test',
      BusinessType: 'Company',
      Address: Address.constructFromObject({ BuildingNumber: '1055' }),
      OtherBusinessNames: ['Test'],
      Website: 'https://trulioo.com',
      Telephone: '18887730179',
      TaxIDNumber: '123',
      TaxIDNumbers: ['123'],
      EmailAddress: 'support@trulioo.com',
      WebDomain: 'trulioo.com',
      WebDomains: ['trulioo.com'],
      NAICS: [BusinessSearchResponseIndustryCode.constructFromObject({ Code: 'abc' })],
      SIC: [BusinessSearchResponseIndustryCode.constructFromObject({ Code: 'abc' })],
    };
    const result = Result.constructFromObject(data);

    expect(result.Index).toBe(data.Index);
    expect(result.BusinessName).toBe(data.BusinessName);
    expect(result.MatchingScore).toBe(data.MatchingScore);
    expect(result.BusinessRegistrationNumber).toBe(data.BusinessRegistrationNumber);
    expect(result.DUNSNumber).toBe(data.DUNSNumber);
    expect(result.BusinessTaxIDNumber).toBe(data.BusinessTaxIDNumber);
    expect(result.BusinessLicenseNumber).toBe(data.BusinessLicenseNumber);
    expect(result.JurisdictionOfIncorporation).toBe(data.JurisdictionOfIncorporation);
    expect(result.FullAddress).toBe(data.FullAddress);
    expect(result.BusinessStatus).toBe(data.BusinessStatus);
    expect(result.TradeStyleName).toBe(data.TradeStyleName);
    expect(result.BusinessType).toBe(data.BusinessType);
    expect(result.Address).toStrictEqual(data.Address);
    expect(result.OtherBusinessNames).toStrictEqual(data.OtherBusinessNames);
    expect(result.Website).toBe(data.Website);
    expect(result.Telephone).toBe(data.Telephone);
    expect(result.TaxIDNumber).toBe(data.TaxIDNumber);
    expect(result.TaxIDNumbers).toStrictEqual(data.TaxIDNumbers);
    expect(result.EmailAddress).toBe(data.EmailAddress);
    expect(result.WebDomain).toBe(data.WebDomain);
    expect(result.WebDomains).toStrictEqual(data.WebDomains);
    expect(result.NAICS).toStrictEqual(data.NAICS);
    expect(result.SIC).toStrictEqual(data.SIC);
  });
});
