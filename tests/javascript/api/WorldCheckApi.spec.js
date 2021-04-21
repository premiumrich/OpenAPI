import expect from 'expect';
import nock from 'nock';
import ApiClient from '../../src/ApiClient';
import WorldCheckApi from '../../src/api/WorldCheckApi';

describe('WorldCheckApi', () => {
  let worldCheckApi;

  beforeEach(() => {
    const apiClient = new ApiClient();
    apiClient.authentications['ApiKeyAuth'].apiKey = 'test-api-key';
    worldCheckApi = new WorldCheckApi(apiClient);
  });

  it('should construct with default ApiClient', () => {
    expect(new WorldCheckApi().apiClient).toStrictEqual(ApiClient.instance);
  });

  describe('#getWorldCheckProfile', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/worldcheck/v1/profile/test-transaction-guid/ref-123')
        .reply(200, { content: 'test' });

      const result = await worldCheckApi.getWorldCheckProfile('trial', 'test-transaction-guid', 'ref-123');

      expect(result).toStrictEqual({ content: 'test' });
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/worldcheck/v1/profile/test-transaction-guid/ref-123')
        .reply(401);

      try {
        await worldCheckApi.getWorldCheckProfile('trial', 'test-transaction-guid', 'ref-123');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => worldCheckApi.getWorldCheckProfile(undefined, 'test-transaction-guid', 'ref-123')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getWorldCheckProfile")
      );
      expect(() => worldCheckApi.getWorldCheckProfile('trial', undefined, 'ref-123')).toThrow(
        new Error("Missing the required parameter 'originalTransactionID' when calling getWorldCheckProfile")
      );
      expect(() => worldCheckApi.getWorldCheckProfile('trial', 'test-transaction-guid', undefined)).toThrow(
        new Error("Missing the required parameter 'referenceID' when calling getWorldCheckProfile")
      );
    });
  });
});
