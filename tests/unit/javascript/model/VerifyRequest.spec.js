import expect from 'expect';
import DataFields from '../../src/model/DataFields';
import PersonInfo from '../../src/model/PersonInfo';
import VerifyRequest from '../../src/model/VerifyRequest';

describe('VerifyRequest', () => {
  it('should construct an instance of VerifyRequest', () => {
    const verifyRequest = VerifyRequest.constructFromObject({}, undefined);

    expect(verifyRequest).toBeInstanceOf(VerifyRequest);
  });

  it('should not construct with no data', () => {
    const verifyRequest = VerifyRequest.constructFromObject(undefined, null);

    expect(verifyRequest).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      AcceptTruliooTermsAndConditions: true,
      Demo: false,
      CallBackUrl: 'https://trulioo.com',
      Timeout: 3600,
      CleansedAddress: true,
      ConfigurationName: 'Identity Verification',
      ConsentForDataSources: ['yes'],
      CountryCode: 'US',
      CustomerReferenceID: 'ref-123',
      DataFields: DataFields.constructFromObject({
        PersonInfo: PersonInfo.constructFromObject({ FirstGivenName: 'A' }),
      }),
      VerboseMode: false,
    };
    const verifyRequest = VerifyRequest.constructFromObject(data);

    expect(verifyRequest.AcceptTruliooTermsAndConditions).toBe(data.AcceptTruliooTermsAndConditions);
    expect(verifyRequest.Demo).toBe(data.Demo);
    expect(verifyRequest.CallBackUrl).toBe(data.CallBackUrl);
    expect(verifyRequest.Timeout).toBe(data.Timeout);
    expect(verifyRequest.CleansedAddress).toBe(data.CleansedAddress);
    expect(verifyRequest.ConfigurationName).toBe(data.ConfigurationName);
    expect(verifyRequest.ConsentForDataSources).toStrictEqual(data.ConsentForDataSources);
    expect(verifyRequest.CountryCode).toBe(data.CountryCode);
    expect(verifyRequest.CustomerReferenceID).toBe(data.CustomerReferenceID);
    expect(verifyRequest.DataFields).toStrictEqual(data.DataFields);
    expect(verifyRequest.VerboseMode).toBe(data.VerboseMode);
  });
});
