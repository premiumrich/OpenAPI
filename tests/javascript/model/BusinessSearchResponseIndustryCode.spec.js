import expect from 'expect';
import BusinessSearchResponseIndustryCode from '../../src/model/BusinessSearchResponseIndustryCode';

describe('BusinessSearchResponseIndustryCode', () => {
  it('should construct an instance of BusinessSearchResponseIndustryCode', () => {
    const businessSearchResponseIndustryCode = BusinessSearchResponseIndustryCode.constructFromObject({}, undefined);

    expect(businessSearchResponseIndustryCode).toBeInstanceOf(BusinessSearchResponseIndustryCode);
  });

  it('should not construct with no data', () => {
    const businessSearchResponseIndustryCode = BusinessSearchResponseIndustryCode.constructFromObject(undefined, null);

    expect(businessSearchResponseIndustryCode).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Code: 'abc',
      Description: 'desc',
    };
    const businessSearchResponseIndustryCode = BusinessSearchResponseIndustryCode.constructFromObject(data);

    expect(businessSearchResponseIndustryCode.Code).toBe(data.Code);
    expect(businessSearchResponseIndustryCode.Description).toBe(data.Description);
  });
});
