import expect from 'expect';
import nock from 'nock';
import ApiClient from '../../src/ApiClient';
import VerificationsApi from '../../src/api/VerificationsApi';
import TransactionRecordResult from '../../src/model/TransactionRecordResult';
import DataField from '../../src/model/DataField';
import Record from '../../src/model/Record';
import DatasourceResult from '../../src/model/DatasourceResult';
import DatasourceField from '../../src/model/DatasourceField';
import TransactionStatus from '../../src/model/TransactionStatus';
import VerifyRequest from '../../src/model/VerifyRequest';
import VerifyResult from '../../src/model/VerifyResult';

describe('VerificationsApi', () => {
  let verificationsApi;

  beforeEach(() => {
    const apiClient = new ApiClient();
    apiClient.authentications['ApiKeyAuth'].apiKey = 'test-api-key';
    verificationsApi = new VerificationsApi(apiClient);
  });

  it('should construct with default ApiClient', () => {
    expect(new VerificationsApi().apiClient).toStrictEqual(ApiClient.instance);
  });

  describe('#documentDownload', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage')
        .reply(200, { Image: 'base64' });

      const result = await verificationsApi.documentDownload('trial', 'test-transaction-guid', 'DocumentFrontImage');

      expect(result).toStrictEqual({ Image: 'base64' });
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage')
        .reply(401);

      try {
        await verificationsApi.documentDownload('trial', 'test-transaction-guid', 'DocumentFrontImage');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => verificationsApi.documentDownload(undefined, 'test-transaction-guid', 'DocumentFrontImage')).toThrow(
        new Error("Missing the required parameter 'mode' when calling documentDownload")
      );
      expect(() => verificationsApi.documentDownload('trial', undefined, 'DocumentFrontImage')).toThrow(
        new Error("Missing the required parameter 'transactionRecordId' when calling documentDownload")
      );
      expect(() => verificationsApi.documentDownload('trial', 'test-transaction-guid', undefined)).toThrow(
        new Error("Missing the required parameter 'fieldName' when calling documentDownload")
      );
    });
  });

  describe('#getTransactionRecord', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transactionrecord/test-transaction-guid')
        .reply(200, {
          InputFields: [
            {
              FieldName: 'FirstGivenName',
              Value: 'Test',
            },
          ],
          UploadedDt: '2017-07-11T21:47:50.778124',
          Record: {
            TransactionRecordID: 'test-transaction-guid',
            RecordStatus: 'match',
            DatasourceResults: [
              {
                DatasourceFields: [
                  {
                    FieldName: 'FirstGivenName',
                    Status: 'match',
                  },
                ],
              },
            ],
          },
          Errors: [],
        });

      const result = await verificationsApi.getTransactionRecord('trial', 'test-transaction-guid');

      expect(result).toStrictEqual(
        TransactionRecordResult.constructFromObject({
          InputFields: [
            DataField.constructFromObject({
              FieldName: 'FirstGivenName',
              Value: 'Test',
            }),
          ],
          UploadedDt: '2017-07-11T21:47:50.778124',
          Record: Record.constructFromObject({
            TransactionRecordID: 'test-transaction-guid',
            RecordStatus: 'match',
            DatasourceResults: [
              DatasourceResult.constructFromObject({
                DatasourceFields: [
                  DatasourceField.constructFromObject({
                    FieldName: 'FirstGivenName',
                    Status: 'match',
                  }),
                ],
              }),
            ],
          }),
          Errors: [],
        })
      );
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transactionrecord/test-transaction-guid')
        .reply(401);

      try {
        await verificationsApi.getTransactionRecord('trial', 'test-transaction-guid');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => verificationsApi.getTransactionRecord(undefined, 'test-transaction-guid')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getTransactionRecord")
      );
      expect(() => verificationsApi.getTransactionRecord('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'id' when calling getTransactionRecord")
      );
    });
  });

  describe('#getTransactionRecordAddress', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress')
        .reply(200, {
          InputFields: [
            {
              FieldName: 'FirstGivenName',
              Value: 'Test',
            },
          ],
          UploadedDt: '2017-07-11T21:47:50.778124',
          Record: {
            TransactionRecordID: 'test-transaction-guid',
            RecordStatus: 'match',
            DatasourceResults: [
              {
                DatasourceName: 'Datasource',
                DatasourceFields: [],
                AppendedFields: [],
                FieldGroups: [],
              },
            ],
            Errors: [],
          },
          Errors: [],
        });

      const result = await verificationsApi.getTransactionRecordAddress('trial', 'test-transaction-guid');

      expect(result).toStrictEqual(
        TransactionRecordResult.constructFromObject({
          InputFields: [
            DataField.constructFromObject({
              FieldName: 'FirstGivenName',
              Value: 'Test',
            }),
          ],
          UploadedDt: '2017-07-11T21:47:50.778124',
          Record: Record.constructFromObject({
            TransactionRecordID: 'test-transaction-guid',
            RecordStatus: 'match',
            DatasourceResults: [
              DatasourceResult.constructFromObject({
                DatasourceName: 'Datasource',
                DatasourceFields: [],
                AppendedFields: [],
                FieldGroups: [],
              }),
            ],
            Errors: [],
          }),
          Errors: [],
        })
      );
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress')
        .reply(401);

      try {
        await verificationsApi.getTransactionRecordAddress('trial', 'test-transaction-guid');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => verificationsApi.getTransactionRecordAddress(undefined, 'test-transaction-guid')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getTransactionRecordAddress")
      );
      expect(() => verificationsApi.getTransactionRecordAddress('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'id' when calling getTransactionRecordAddress")
      );
    });
  });

  describe('#getTransactionRecordDocument', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage')
        .reply(200, 'base64');

      const result = await verificationsApi.getTransactionRecordDocument(
        'trial',
        'test-transaction-guid',
        'DocumentFrontImage'
      );

      expect(result).toStrictEqual('base64');
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage')
        .reply(401);

      try {
        await verificationsApi.getTransactionRecordDocument('trial', 'test-transaction-guid', 'DocumentFrontImage');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() =>
        verificationsApi.getTransactionRecordDocument(undefined, 'test-transaction-guid', 'DocumentFrontImage')
      ).toThrow(new Error("Missing the required parameter 'mode' when calling getTransactionRecordDocument"));
      expect(() => verificationsApi.getTransactionRecordDocument('trial', undefined, 'DocumentFrontImage')).toThrow(
        new Error("Missing the required parameter 'transactionRecordID' when calling getTransactionRecordDocument")
      );
      expect(() => verificationsApi.getTransactionRecordDocument('trial', 'test-transaction-guid', undefined)).toThrow(
        new Error("Missing the required parameter 'documentField' when calling getTransactionRecordDocument")
      );
    });
  });

  describe('#getTransactionRecordVerbose', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transactionrecord/test-transaction-guid/verbose')
        .reply(200, {
          InputFields: [
            {
              FieldName: 'FirstGivenName',
              Value: 'Test',
            },
          ],
          UploadedDt: '2017-07-11T21:47:50.778124',
          Record: {
            TransactionRecordID: 'test-transaction-guid',
            RecordStatus: 'match',
            DatasourceResults: [
              {
                DatasourceName: 'Datasource',
                DatasourceFields: [],
                AppendedFields: [],
                FieldGroups: [],
              },
            ],
            Errors: [],
          },
          Errors: [],
        });

      const result = await verificationsApi.getTransactionRecordVerbose('trial', 'test-transaction-guid');

      expect(result).toStrictEqual(
        TransactionRecordResult.constructFromObject({
          InputFields: [
            DataField.constructFromObject({
              FieldName: 'FirstGivenName',
              Value: 'Test',
            }),
          ],
          UploadedDt: '2017-07-11T21:47:50.778124',
          Record: Record.constructFromObject({
            TransactionRecordID: 'test-transaction-guid',
            RecordStatus: 'match',
            DatasourceResults: [
              DatasourceResult.constructFromObject({
                DatasourceName: 'Datasource',
                DatasourceFields: [],
                AppendedFields: [],
                FieldGroups: [],
              }),
            ],
            Errors: [],
          }),
          Errors: [],
        })
      );
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transactionrecord/test-transaction-guid/verbose')
        .reply(401);

      try {
        await verificationsApi.getTransactionRecordVerbose('trial', 'test-transaction-guid');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => verificationsApi.getTransactionRecordVerbose(undefined, 'test-transaction-guid')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getTransactionRecordVerbose")
      );
      expect(() => verificationsApi.getTransactionRecordVerbose('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'id' when calling getTransactionRecordVerbose")
      );
    });
  });

  describe('#getTransactionStatus', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transaction/test-transaction-guid/status')
        .reply(200, {
          TransactionId: 'test-transaction-guid',
          TransactionRecordId: 'test-transaction-record-guid',
          Status: 'InProgress',
          UploadedDt: '2017-07-11T21:47:50.778124',
          IsTimedOut: false,
        });

      const result = await verificationsApi.getTransactionStatus('trial', 'test-transaction-guid');

      expect(result).toStrictEqual(
        TransactionStatus.constructFromObject({
          TransactionId: 'test-transaction-guid',
          TransactionRecordId: 'test-transaction-record-guid',
          Status: 'InProgress',
          UploadedDt: '2017-07-11T21:47:50.778124',
          IsTimedOut: false,
        })
      );
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .get('/trial/verifications/v1/transaction/test-transaction-guid/status')
        .reply(401);

      try {
        await verificationsApi.getTransactionStatus('trial', 'test-transaction-guid');
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => verificationsApi.getTransactionStatus(undefined, 'test-transaction-guid')).toThrow(
        new Error("Missing the required parameter 'mode' when calling getTransactionStatus")
      );
      expect(() => verificationsApi.getTransactionStatus('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'id' when calling getTransactionStatus")
      );
    });
  });

  describe('#verify', () => {
    it('should correctly call the API and deserialize the response', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .post('/trial/verifications/v1/verify')
        .reply(200, {
          TransactionID: 'test-transaction-guid',
          UploadedDt: '2017-07-11T21:47:50.778124',
          Record: {
            TransactionRecordID: 'test-transaction-record-guid',
            RecordStatus: 'match',
            DatasourceResults: [
              {
                DatasourceName: 'Datasource',
                DatasourceFields: [
                  {
                    FieldName: 'FirstGivenName',
                    Status: 'match',
                  },
                ],
              },
            ],
            Errors: [],
          },
          CustomerReferenceID: 'ref-123',
          Errors: [],
        });

      const result = await verificationsApi.verify('trial', new VerifyRequest());

      expect(result).toStrictEqual(
        VerifyResult.constructFromObject({
          TransactionID: 'test-transaction-guid',
          UploadedDt: '2017-07-11T21:47:50.778124',
          Record: Record.constructFromObject({
            TransactionRecordID: 'test-transaction-record-guid',
            RecordStatus: 'match',
            DatasourceResults: [
              DatasourceResult.constructFromObject({
                DatasourceName: 'Datasource',
                DatasourceFields: [
                  DatasourceField.constructFromObject({
                    FieldName: 'FirstGivenName',
                    Status: 'match',
                  }),
                ],
              }),
            ],
            Errors: [],
          }),
          CustomerReferenceID: 'ref-123',
          Errors: [],
        })
      );
    });

    it('should throw an error if the API returns 401 unauthorized', async () => {
      nock('https://gateway.trulioo.com', { reqheaders: { 'x-trulioo-api-key': 'test-api-key' } })
        .post('/trial/verifications/v1/verify')
        .reply(401);

      try {
        await verificationsApi.verify('trial', new VerifyRequest());
        throw new Error('Expected error');
      } catch (error) {
        expect(error.status).toBe(401);
      }
    });

    it('should throw an error if a required parameter is undefined', () => {
      expect(() => verificationsApi.verify(undefined, new VerifyRequest())).toThrow(
        new Error("Missing the required parameter 'mode' when calling verify")
      );
      expect(() => verificationsApi.verify('trial', undefined)).toThrow(
        new Error("Missing the required parameter 'verifyRequest' when calling verify")
      );
    });
  });
});
