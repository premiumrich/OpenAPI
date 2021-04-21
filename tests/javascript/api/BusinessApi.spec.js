import expect from 'expect';
import nock from 'nock';
import ApiClient from '../../src/ApiClient';
import BusinessApi from '../../src/api/BusinessApi';
import BusinessSearchResponse from '../../src/model/BusinessSearchResponse';
import BusinessRecord from '../../src/model/BusinessRecord';
import BusinessResult from '../../src/model/BusinessResult';
import Result from '../../src/model/Result';
import BusinessSearchRequest from '../../src/model/BusinessSearchRequest';
import Record from '../../src/model/Record';

describe('BusinessApi', () => {
  let businessApi;

  beforeEach(() => {
    const apiClient = new ApiClient();
    apiClient.authentications['ApiKeyAuth'].apiKey = 'test-api-key';
    businessApi = new BusinessApi(apiClient);
  });

  it('should construct with default ApiClient', () => {
    expect(new BusinessApi().apiClient).toStrictEqual(ApiClient.instance);
  });

  describe('#getBusinessSearchResult', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/business/v1/search/transactionrecord/test-transaction-guid')
        .reply(200, {
          TransactionID: 'test-transaction-guid',
          Record: {
            RecordStatus: 'match',
          },
        });

      const result = await businessApi.getBusinessSearchResult('trial', 'test-transaction-guid');

      expect(result).toStrictEqual(
        BusinessSearchResponse.constructFromObject({
          TransactionID: 'test-transaction-guid',
          Record: Record.constructFromObject({
            RecordStatus: 'match',
          }),
        })
      );
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/business/v1/search/transactionrecord/test-transaction-guid')
        .reply(401);

      try {
        await businessApi.getBusinessSearchResult('trial', 'test-transaction-guid');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => businessApi.getBusinessSearchResult(undefined, 'test-transaction-guid')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getBusinessSearchResult")
      );
      expect(() => businessApi.getBusinessSearchResult('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'id' when calling getBusinessSearchResult")
      );
    });
  });

  describe('#search', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .post('/trial/business/v1/search')
        .reply(200, {
          TransactionID: 'test-transaction-guid',
          UploadedDt: '2017-07-11T21:47:50.778124',
          ProductName: 'Business Search',
          Record: {
            DatasourceResults: [
              {
                DatasourceName: 'Datasource',
                Results: [
                  {
                    BusinessName: 'test',
                    MatchingScore: '1',
                  },
                ],
              },
            ],
            Errors: [],
          },
        });

      const result = await businessApi.search('trial', new BusinessSearchRequest());

      expect(result).toStrictEqual(
        BusinessSearchResponse.constructFromObject({
          TransactionID: 'test-transaction-guid',
          UploadedDt: '2017-07-11T21:47:50.778124',
          ProductName: 'Business Search',
          Record: BusinessRecord.constructFromObject({
            DatasourceResults: [
              BusinessResult.constructFromObject({
                DatasourceName: 'Datasource',
                Results: [
                  Result.constructFromObject({
                    BusinessName: 'test',
                    MatchingScore: '1',
                  }),
                ],
              }),
            ],
            Errors: [],
          }),
        })
      );
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .post('/trial/business/v1/search')
        .reply(401);

      try {
        await businessApi.search('trial', new BusinessSearchRequest());
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => businessApi.search(undefined, new BusinessSearchRequest())).toThrow(
        new Error("Missing the required parameter 'mode' when calling search")
      );
      expect(() => businessApi.search('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'businessSearchRequest' when calling search")
      );
    });
  });
});
