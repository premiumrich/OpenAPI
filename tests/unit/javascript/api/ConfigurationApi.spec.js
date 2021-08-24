import expect from 'expect';
import nock from 'nock';
import ApiClient from '../../src/ApiClient';
import ConfigurationApi from '../../src/api/ConfigurationApi';
import BusinessRegistrationNumber from '../../src/model/BusinessRegistrationNumber';
import CountrySubdivision from '../../src/model/CountrySubdivision';
import NormalizedDatasourceGroupCountry from '../../src/model/NormalizedDatasourceGroupCountry';
import Consent from '../../src/model/Consent';
import TestEntityDataFields from '../../src/model/TestEntityDataFields';
import PersonInfo from '../../src/model/PersonInfo';
import Location from '../../src/model/Location';
import Communication from '../../src/model/Communication';

describe('ConfigurationApi', () => {
  let configurationApi;

  beforeEach(() => {
    const apiClient = new ApiClient();
    apiClient.authentications['ApiKeyAuth'].apiKey = 'test-api-key';
    configurationApi = new ConfigurationApi(apiClient);
  });

  it('should construct with default ApiClient', () => {
    expect(new ConfigurationApi().apiClient).toStrictEqual(ApiClient.instance);
  });

  describe('#getBusinessRegistrationNumbers', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/businessregistrationnumbers/US/CA')
        .reply(200, [{ Name: 'test1' }]);

      const result = await configurationApi.getBusinessRegistrationNumbers('trial', 'US', 'CA');

      expect(result).toStrictEqual([BusinessRegistrationNumber.constructFromObject({ Name: 'test1' })]);
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/businessregistrationnumbers/US/CA')
        .reply(401);

      try {
        await configurationApi.getBusinessRegistrationNumbers('trial', 'US', 'CA');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getBusinessRegistrationNumbers(undefined, 'US', 'CA')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getBusinessRegistrationNumbers")
      );
      expect(() => configurationApi.getBusinessRegistrationNumbers('trial', undefined, 'CA')).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getBusinessRegistrationNumbers")
      );
      expect(() => configurationApi.getBusinessRegistrationNumbers('trial', 'US', undefined)).toThrow(
        new Error("Missing the required parameter 'jurisdictionCode' when calling getBusinessRegistrationNumbers")
      );
    });
  });

  describe('#getConsents', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/consents/Identity%20Verification/US')
        .reply(200, ["California Driver's Licence"]);

      const result = await configurationApi.getConsents('trial', 'Identity Verification', 'US');

      expect(result).toStrictEqual(["California Driver's Licence"]);
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/consents/Identity%20Verification/US')
        .reply(401);

      try {
        await configurationApi.getConsents('trial', 'Identity Verification', 'US');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getConsents(undefined, 'Identity Verification', 'US')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getConsents")
      );
      expect(() => configurationApi.getConsents('trial', undefined, 'US')).toThrow(
        new Error("Missing the required parameter 'configurationName' when calling getConsents")
      );
      expect(() => configurationApi.getConsents('trial', 'Identity Verification', undefined)).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getConsents")
      );
    });
  });

  describe('#getCountryCodes', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/countrycodes/Identity%20Verification')
        .reply(200, ['US']);

      const result = await configurationApi.getCountryCodes('trial', 'Identity Verification');

      expect(result).toStrictEqual(['US']);
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/countrycodes/Identity%20Verification')
        .reply(401);

      try {
        await configurationApi.getCountryCodes('trial', 'Identity Verification');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getCountryCodes(undefined, 'Identity Verification')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getCountryCodes")
      );
      expect(() => configurationApi.getCountryCodes('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'configurationName' when calling getCountryCodes")
      );
    });
  });

  describe('#getCountrySubdivisions', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/countrysubdivisions/US')
        .reply(200, [{ Name: 'California', Code: 'US-CA', ParentCode: 'US' }]);

      const result = await configurationApi.getCountrySubdivisions('trial', 'US');

      expect(result).toStrictEqual([
        CountrySubdivision.constructFromObject({ Name: 'California', Code: 'US-CA', ParentCode: 'US' }),
      ]);
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/countrysubdivisions/US')
        .reply(401);

      try {
        await configurationApi.getCountrySubdivisions('trial', 'US');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getCountrySubdivisions(undefined, 'US')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getCountrySubdivisions")
      );
      expect(() => configurationApi.getCountrySubdivisions('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getCountrySubdivisions")
      );
    });
  });

  describe('#getDatasources', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/datasources/Identity%20Verification/US')
        .reply(200, [{ Name: 'Credit Agency', Description: 'Test', Coverage: '25%' }]);

      const result = await configurationApi.getDatasources('trial', 'Identity Verification', 'US');

      expect(result).toStrictEqual([
        NormalizedDatasourceGroupCountry.constructFromObject({
          Name: 'Credit Agency',
          Description: 'Test',
          Coverage: '25%',
        }),
      ]);
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/datasources/Identity%20Verification/US')
        .reply(401);

      try {
        await configurationApi.getDatasources('trial', 'Identity Verification', 'US');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getDatasources(undefined, 'Identity Verification', 'US')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getDatasources")
      );
      expect(() => configurationApi.getDatasources('trial', undefined, 'US')).toThrow(
        new Error("Missing the required parameter 'configurationName' when calling getDatasources")
      );
      expect(() => configurationApi.getDatasources('trial', 'Identity Verification', undefined)).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getDatasources")
      );
    });
  });

  describe('#getDetailedConsents', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/detailedConsents/Identity%20Verification/US')
        .reply(200, [{ Name: "California Driver's Licence", Text: 'Test' }]);

      const result = await configurationApi.getDetailedConsents('trial', 'Identity Verification', 'US');

      expect(result).toStrictEqual([
        Consent.constructFromObject({ Name: "California Driver's Licence", Text: 'Test' }),
      ]);
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/detailedConsents/Identity%20Verification/US')
        .reply(401);

      try {
        await configurationApi.getDetailedConsents('trial', 'Identity Verification', 'US');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getDetailedConsents(undefined, 'Identity Verification', 'US')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getDetailedConsents")
      );
      expect(() => configurationApi.getDetailedConsents('trial', undefined, 'US')).toThrow(
        new Error("Missing the required parameter 'configurationName' when calling getDetailedConsents")
      );
      expect(() => configurationApi.getDetailedConsents('trial', 'Identity Verification', undefined)).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getDetailedConsents")
      );
    });
  });

  describe('#getDocumentTypes', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/documentTypes/US')
        .reply(200, { US: ['Passport'] });

      const result = await configurationApi.getDocumentTypes('trial', 'US');

      expect(result).toStrictEqual({ US: ['Passport'] });
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/documentTypes/US')
        .reply(401);

      try {
        await configurationApi.getDocumentTypes('trial', 'US');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getDocumentTypes(undefined, 'US')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getDocumentTypes")
      );
      expect(() => configurationApi.getDocumentTypes('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getDocumentTypes")
      );
    });
  });

  describe('#getFields', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/fields/Identity%20Verification/US')
        .reply(200, {
          title: 'DataFields',
          type: 'object',
          properties: {
            PersonInfo: {},
          },
        });

      const result = await configurationApi.getFields('trial', 'Identity Verification', 'US');

      expect(result).toStrictEqual({
        title: 'DataFields',
        type: 'object',
        properties: {
          PersonInfo: {},
        },
      });
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/fields/Identity%20Verification/US')
        .reply(401);

      try {
        await configurationApi.getFields('trial', 'Identity Verification', 'US');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getFields(undefined, 'Identity Verification', 'US')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getFields")
      );
      expect(() => configurationApi.getFields('trial', undefined, 'US')).toThrow(
        new Error("Missing the required parameter 'configurationName' when calling getFields")
      );
      expect(() => configurationApi.getFields('trial', 'Identity Verification', undefined)).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getFields")
      );
    });
  });

  describe('#getRecommendedFields', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/recommendedfields/Identity%20Verification/US')
        .reply(200, {
          title: 'DataFields',
          type: 'object',
          properties: {
            PersonInfo: {},
          },
        });

      const result = await configurationApi.getRecommendedFields('trial', 'Identity Verification', 'US');

      expect(result).toStrictEqual({
        title: 'DataFields',
        type: 'object',
        properties: {
          PersonInfo: {},
        },
      });
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/recommendedfields/Identity%20Verification/US')
        .reply(401);

      try {
        await configurationApi.getRecommendedFields('trial', 'Identity Verification', 'US');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getRecommendedFields(undefined, 'Identity Verification', 'US')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getRecommendedFields")
      );
      expect(() => configurationApi.getRecommendedFields('trial', undefined, 'US')).toThrow(
        new Error("Missing the required parameter 'configurationName' when calling getRecommendedFields")
      );
      expect(() => configurationApi.getRecommendedFields('trial', 'Identity Verification', undefined)).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getRecommendedFields")
      );
    });
  });

  describe('#getTestEntities', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/testentities/Identity%20Verification/US')
        .reply(200, [
          {
            PersonInfo: {
              FirstGivenName: 'Test',
            },
            Location: {
              BuildingNumber: '1055',
            },
            Communication: {
              MobileNumber: '076310691',
            },
          },
        ]);

      const result = await configurationApi.getTestEntities('trial', 'Identity Verification', 'US');

      expect(result).toStrictEqual([
        TestEntityDataFields.constructFromObject({
          PersonInfo: PersonInfo.constructFromObject({
            FirstGivenName: 'Test',
          }),
          Location: Location.constructFromObject({
            BuildingNumber: '1055',
          }),
          Communication: Communication.constructFromObject({
            MobileNumber: '076310691',
          }),
        }),
      ]);
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/configuration/v1/testentities/Identity%20Verification/US')
        .reply(401);

      try {
        await configurationApi.getTestEntities('trial', 'Identity Verification', 'US');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => configurationApi.getTestEntities(undefined, 'Identity Verification', 'US')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getTestEntities")
      );
      expect(() => configurationApi.getTestEntities('trial', undefined, 'US')).toThrow(
        new Error("Missing the required parameter 'configurationName' when calling getTestEntities")
      );
      expect(() => configurationApi.getTestEntities('trial', 'Identity Verification', undefined)).toThrow(
        new Error("Missing the required parameter 'countryCode' when calling getTestEntities")
      );
    });
  });
});
