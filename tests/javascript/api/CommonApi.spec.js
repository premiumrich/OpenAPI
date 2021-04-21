import expect from 'expect';
import nock from 'nock';
import ApiClient from '../../src/ApiClient';
import CommonApi from '../../src/api/CommonApi';

describe('CommonApi', () => {
  let commonApi;

  beforeEach(() => {
    const apiClient = new ApiClient();
    apiClient.authentications['ApiKeyAuth'].apiKey = 'test-api-key';
    commonApi = new CommonApi(apiClient);
  });

  it('should construct with default ApiClient', () => {
    expect(new CommonApi().apiClient).toStrictEqual(ApiClient.instance);
  });

  describe('#commonIpInfo', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { badheaders: ['x-trulioo-api-key'] })
        .get('/trial/common/v1/ip-info')
        .reply(200, {
          IP: '0.0.0.0',
        });

      const result = await commonApi.commonIpInfo('trial');

      expect(result).toStrictEqual({
        IP: '0.0.0.0',
      });
    });

    it('should throw an error if the API returns 500 server error', async () => {
      nock('https://gateway.trulioo.com', { badheaders: ['x-trulioo-api-key'] })
        .get('/trial/common/v1/ip-info')
        .reply(500);

      try {
        await commonApi.commonIpInfo('trial');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(500);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => commonApi.commonIpInfo(undefined)).toThrow(
        new Error("Missing the required parameter 'mode' when calling commonIpInfo")
      );
    });
  });
});
