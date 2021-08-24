import expect from 'expect';
import BusinessSearchRequest from '../../src/model/BusinessSearchRequest';
import BusinessSearchRequestBusinessSearchModel from '../../src/model/BusinessSearchRequestBusinessSearchModel';

describe('BusinessSearchRequest', () => {
  it('should construct an instance of BusinessSearchRequest', () => {
    const businessSearchRequest = BusinessSearchRequest.constructFromObject({}, undefined);

    expect(businessSearchRequest).toBeInstanceOf(BusinessSearchRequest);
  });

  it('should not construct with no data', () => {
    const businessSearchRequest = BusinessSearchRequest.constructFromObject(undefined, null);

    expect(businessSearchRequest).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      AcceptTruliooTermsAndConditions: true,
      CallBackUrl: 'https://trulioo.com',
      Timeout: 3600,
      ConsentForDataSources: ['yes'],
      Business: BusinessSearchRequestBusinessSearchModel.constructFromObject({ BusinessName: 'test' }),
      CountryCode: 'US',
    };
    const businessSearchRequest = BusinessSearchRequest.constructFromObject(data);

    expect(businessSearchRequest.AcceptTruliooTermsAndConditions).toBe(data.AcceptTruliooTermsAndConditions);
    expect(businessSearchRequest.CallBackUrl).toBe(data.CallBackUrl);
    expect(businessSearchRequest.Timeout).toBe(data.Timeout);
    expect(businessSearchRequest.ConsentForDataSources).toStrictEqual(data.ConsentForDataSources);
    expect(businessSearchRequest.Business).toStrictEqual(data.Business);
    expect(businessSearchRequest.CountryCode).toBe(data.CountryCode);
  });
});
