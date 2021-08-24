import expect from 'expect';
import nock from 'nock';
import ApiClient from '../../src/ApiClient';
import ConnectionApi from '../../src/api/ConnectionApi';
import TransactionStatus from '../../src/model/TransactionStatus';

describe('ConnectionApi', () => {
  let connectionApi;

  beforeEach(() => {
    const apiClient = new ApiClient();
    apiClient.authentications['ApiKeyAuth'].apiKey = 'test-api-key';
    connectionApi = new ConnectionApi(apiClient);
  });

  it('should construct with default ApiClient', () => {
    expect(new ConnectionApi().apiClient).toStrictEqual(ApiClient.instance);
  });

  describe('#connectionAsyncCallbackUrl', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { badheaders: ['x-trulioo-api-key'] })
        .post('/trial/connection/v1/async-callback')
        .reply(200, {});

      const result = await connectionApi.connectionAsyncCallbackUrl('trial', new TransactionStatus());

      expect(result).toStrictEqual('{}');
    });

    it('should throw an error if the API returns 500 server error', async () => {
      nock('https://gateway.trulioo.com', { badheaders: ['x-trulioo-api-key'] })
        .post('/trial/connection/v1/async-callback')
        .reply(500);

      try {
        await connectionApi.connectionAsyncCallbackUrl('trial', new TransactionStatus());
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(500);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => connectionApi.connectionAsyncCallbackUrl(undefined, 'Trulioo User')).toThrow(
        new Error("Missing the required parameter 'mode' when calling connectionAsyncCallbackUrl")
      );
      expect(() => connectionApi.connectionAsyncCallbackUrl('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'transactionStatus' when calling connectionAsyncCallbackUrl")
      );
    });
  });

  describe('#sayHello', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { badheaders: ['x-trulioo-api-key'] })
        .get('/trial/connection/v1/sayhello/Trulioo%20User')
        .reply(200, 'Hello Trulioo User');

      const result = await connectionApi.sayHello('trial', 'Trulioo User');

      expect(result).toStrictEqual('Hello Trulioo User');
    });

    it('should throw an error if the API returns 500 server error', async () => {
      nock('https://gateway.trulioo.com', { badheaders: ['x-trulioo-api-key'] })
        .get('/trial/connection/v1/sayhello/Trulioo%20User')
        .reply(500);

      try {
        await connectionApi.sayHello('trial', 'Trulioo User');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(500);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => connectionApi.sayHello(undefined, 'Trulioo User')).toThrow(
        new Error("Missing the required parameter 'mode' when calling sayHello")
      );
      expect(() => connectionApi.sayHello('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'name' when calling sayHello")
      );
    });
  });

  describe('#testAuthentication', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/connection/v1/testauthentication')
        .reply(200, 'Hello Trulioo User');

      const result = await connectionApi.testAuthentication('trial');

      expect(result).toStrictEqual('Hello Trulioo User');
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/connection/v1/testauthentication')
        .reply(401);

      try {
        await connectionApi.testAuthentication('trial');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => connectionApi.testAuthentication(undefined)).toThrow(
        new Error("Missing the required parameter 'mode' when calling testAuthentication")
      );
    });
  });
});
