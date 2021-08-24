using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using WireMock.Util;
using Xunit;
using Trulioo.SDK.Api;
using Trulioo.SDK.Client;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class VerificationsApiTests : IDisposable
  {
    private VerificationsApi verificationsApi;
    private WireMockServer mockServer;
    private const string TEST_API_KEY = "test-api-key";

    public VerificationsApiTests()
    {
      int port = PortUtils.FindFreeTcpPort();
      Configuration config = new Configuration();
      config.BasePath = "http://localhost:" + port;
      config.ApiKey.Add("x-trulioo-api-key", TEST_API_KEY);
      verificationsApi = new VerificationsApi(config);

      mockServer = WireMockServer.Start(port);
    }

    public void Dispose() => Dispose(true);

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        mockServer.Stop();
        mockServer.Dispose();
      }
    }

    /* Test constructors */
    [Fact]
    public void VerificationsApiTest()
    {
      verificationsApi = new VerificationsApi();
      Assert.Equal("https://gateway.trulioo.com", verificationsApi.GetBasePath());
    }

    [Fact]
    public void VerificationsApiBasePathTest()
    {
      string basePath = "http://abc.io";
      verificationsApi = new VerificationsApi(basePath);
      Assert.Equal(basePath, verificationsApi.GetBasePath());
    }

    [Fact]
    public void VerificationsApiConfigurationTest()
    {
      Configuration config = new Configuration();
      config.BasePath = "http://abc.io";
      verificationsApi = new VerificationsApi(config);
      Assert.Equal(config.BasePath, verificationsApi.GetBasePath());
    }

    [Fact]
    public void VerificationsApiApiAllParamsTest()
    {
      Configuration config = new Configuration();
      ApiClient client = new ApiClient();
      ApiClient asyncClient = new ApiClient();
      verificationsApi = new VerificationsApi(client, asyncClient, config);
      Assert.Equal(config, verificationsApi.Configuration);
      Assert.Equal(client, verificationsApi.Client);
      Assert.Equal(asyncClient, verificationsApi.AsynchronousClient);
    }

    [Fact]
    public void VerificationsApiNullParamsTest()
    {
      ArgumentNullException e0 = Assert.Throws<ArgumentNullException>(() => new VerificationsApi((Configuration) null));
      Assert.Equal("Value cannot be null. (Parameter 'configuration')", e0.Message);

      ArgumentNullException e1 = Assert.Throws<ArgumentNullException>(() => new VerificationsApi((ApiClient) null, new ApiClient(), new Configuration()));
      Assert.Equal("Value cannot be null. (Parameter 'client')", e1.Message);

      ArgumentNullException e2 = Assert.Throws<ArgumentNullException>(() => new VerificationsApi(new ApiClient(), (ApiClient) null, new Configuration()));
      Assert.Equal("Value cannot be null. (Parameter 'asyncClient')", e2.Message);

      ArgumentNullException e3 = Assert.Throws<ArgumentNullException>(() => new VerificationsApi(new ApiClient(), new ApiClient(), (Configuration) null));
      Assert.Equal("Value cannot be null. (Parameter 'configuration')", e3.Message);
    }

    /* Test DocumentDownload */
    [Fact]
    public async Task DocumentDownloadTest()
    {
      JObject expected = new JObject();
      expected.Add("Image", "base64");

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
              Response.Create()
                  .WithStatusCode(200)
                  .WithHeader("Content-Type", "application/json")
                  .WithBody(JsonConvert.SerializeObject(expected))
          );

      try
      {
        Object result = verificationsApi.DocumentDownload("trial", "test-transaction-guid", "DocumentFrontImage");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        Object result = await verificationsApi.DocumentDownloadAsync("trial", "test-transaction-guid", "DocumentFrontImage");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void DocumentDownloadUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => verificationsApi.DocumentDownload("trial", "test-transaction-guid", "DocumentFrontImage"));
    }

    [Fact]
    public void DocumentDownloadNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => verificationsApi.DocumentDownload(null, "test-transaction-guid", "DocumentFrontImage"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->DocumentDownload", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => verificationsApi.DocumentDownload("trial", null, "DocumentFrontImage"));
      Assert.Equal("Missing required parameter 'transactionRecordId' when calling VerificationsApi->DocumentDownload", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => verificationsApi.DocumentDownload("trial", "test-transaction-guid", null));
      Assert.Equal("Missing required parameter 'fieldName' when calling VerificationsApi->DocumentDownload", e3.Message);
    }

    [Fact]
    public async Task DocumentDownloadAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.DocumentDownloadAsync(null, "test-transaction-guid", "DocumentFrontImage"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->DocumentDownload", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.DocumentDownloadAsync("trial", null, "DocumentFrontImage"));
      Assert.Equal("Missing required parameter 'transactionRecordId' when calling VerificationsApi->DocumentDownload", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.DocumentDownloadAsync("trial", "test-transaction-guid", null));
      Assert.Equal("Missing required parameter 'fieldName' when calling VerificationsApi->DocumentDownload", e3.Message);
    }

    /* Test GetTransactionRecord */
    [Fact]
    public async Task GetTransactionRecordTest()
    {
      TransactionRecordResult expected = new TransactionRecordResult(
          inputFields: new List<DataField>{
                    new DataField(fieldName: "test-fieldName", value: "test-value")
          },
          uploadedDt: DateTime.Parse("2020-09-15T00:00:00+00:00"),
          record: new Trulioo.SDK.Model.Record(
              datasourceResults: new List<DatasourceResult>{
                        new DatasourceResult(datasourceFields: new List<DatasourceField>{
                            new DatasourceField(fieldName: "test-firstGivenName", status: "test-status")
                        })
              },
              recordStatus: "test-recordStatus",
              transactionRecordID: "test-transactionRecordID"
          ),
          errors: new List<ServiceError>()
      );

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transactionrecord/test-transaction-guid")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
              Response.Create()
                  .WithStatusCode(200)
                  .WithHeader("Content-Type", "application/json")
                  .WithBody(JsonConvert.SerializeObject(expected))
          );

      try
      {
        TransactionRecordResult result = verificationsApi.GetTransactionRecord("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        TransactionRecordResult result = await verificationsApi.GetTransactionRecordAsync("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetTransactionRecordUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transactionrecord/test-transaction-guid")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecord("trial", "test-transaction-guid"));
    }

    [Fact]
    public void GetTransactionRecordNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecord(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionRecord", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecord("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling VerificationsApi->GetTransactionRecord", e2.Message);
    }

    [Fact]
    public async Task GetTransactionRecordAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordAsync(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionRecord", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordAsync("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling VerificationsApi->GetTransactionRecord", e2.Message);
    }

    /* Test GetTransactionRecordAddress */
    [Fact]
    public async Task GetTransactionRecordAddressTest()
    {
      TransactionRecordResult expected = new TransactionRecordResult(
          inputFields: new List<DataField>{
                    new DataField(fieldName: "test-fieldName", value: "test-value")
          },
          uploadedDt: DateTime.Parse("2020-09-15T00:00:00+00:00"),
          record: new Trulioo.SDK.Model.Record(
              datasourceResults: new List<DatasourceResult>{
                        new DatasourceResult(datasourceFields: new List<DatasourceField>{
                            new DatasourceField(fieldName: "test-firstGivenName", status: "test-status")
                        })
              },
              recordStatus: "test-recordStatus",
              transactionRecordID: "test-transactionRecordID"
          ),
          errors: new List<ServiceError>()
      );

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
              Response.Create()
                  .WithStatusCode(200)
                  .WithHeader("Content-Type", "application/json")
                  .WithBody(JsonConvert.SerializeObject(expected))
          );

      try
      {
        TransactionRecordResult result = verificationsApi.GetTransactionRecordAddress("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        TransactionRecordResult result = await verificationsApi.GetTransactionRecordAddressAsync("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetTransactionRecordAddressUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordAddress("trial", "test-transaction-guid"));
    }

    [Fact]
    public void GetTransactionRecordAddressNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordAddress(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionRecordAddress", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordAddress("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling VerificationsApi->GetTransactionRecordAddress", e2.Message);
    }

    [Fact]
    public async Task GetTransactionRecordAddressAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordAddressAsync(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionRecordAddress", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordAddressAsync("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling VerificationsApi->GetTransactionRecordAddress", e2.Message);
    }

    /* Test GetTransactionRecordDocument */
    [Fact]
    public async Task GetTransactionRecordDocumentTest()
    {
      string expected = "base64";

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
              Response.Create()
                  .WithStatusCode(200)
                  .WithHeader("Content-Type", "application/json")
                  .WithBody(JsonConvert.SerializeObject(expected))
          );

      try
      {
        string result = verificationsApi.GetTransactionRecordDocument("trial", "test-transaction-guid", "DocumentFrontImage");
        Assert.Equal(result, "\"" + expected + "\"");
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        string result = await verificationsApi.GetTransactionRecordDocumentAsync("trial", "test-transaction-guid", "DocumentFrontImage");
        Assert.Equal(result, "\"" + expected + "\"");
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetTransactionRecordDocumentUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordDocument("trial", "test-transaction-guid", "DocumentFrontImage"));
    }

    [Fact]
    public void GetTransactionRecordDocumentNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordDocument(null, "test-transaction-guid", "DocumentFrontImage"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionRecordDocument", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordDocument("trial", null, "DocumentFrontImage"));
      Assert.Equal("Missing required parameter 'transactionRecordID' when calling VerificationsApi->GetTransactionRecordDocument", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordDocument("trial", "test-transaction-guid", null));
      Assert.Equal("Missing required parameter 'documentField' when calling VerificationsApi->GetTransactionRecordDocument", e3.Message);
    }

    [Fact]
    public async Task GetTransactionRecordDocumentAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordDocumentAsync(null, "test-transaction-guid", "DocumentFrontImage"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionRecordDocument", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordDocumentAsync("trial", null, "DocumentFrontImage"));
      Assert.Equal("Missing required parameter 'transactionRecordID' when calling VerificationsApi->GetTransactionRecordDocument", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordDocumentAsync("trial", "test-transaction-guid", null));
      Assert.Equal("Missing required parameter 'documentField' when calling VerificationsApi->GetTransactionRecordDocument", e3.Message);
    }

    /* Test GetTransactionRecordVerbose */
    [Fact]
    public async Task GetTransactionRecordVerboseTest()
    {
      TransactionRecordResult expected = new TransactionRecordResult(
          inputFields: new List<DataField>{
                    new DataField(fieldName: "test-fieldName", value: "test-value")
          },
          uploadedDt: DateTime.Parse("2020-09-15T00:00:00+00:00"),
          record: new Trulioo.SDK.Model.Record(
              datasourceResults: new List<DatasourceResult>{
                        new DatasourceResult(datasourceFields: new List<DatasourceField>{
                            new DatasourceField(fieldName: "test-firstGivenName", status: "test-status")
                        })
              },
              recordStatus: "test-recordStatus",
              transactionRecordID: "test-transactionRecordID"
          ),
          errors: new List<ServiceError>()
      );

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transactionrecord/test-transaction-guid/verbose")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
              Response.Create()
                  .WithStatusCode(200)
                  .WithHeader("Content-Type", "application/json")
                  .WithBody(JsonConvert.SerializeObject(expected))
          );

      try
      {
        TransactionRecordResult result = verificationsApi.GetTransactionRecordVerbose("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        TransactionRecordResult result = await verificationsApi.GetTransactionRecordVerboseAsync("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetTransactionRecordVerboseUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transactionrecord/test-transaction-guid/verbose")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordVerbose("trial", "test-transaction-guid"));
    }

    [Fact]
    public void GetTransactionRecordVerboseNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordVerbose(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionRecordVerbose", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionRecordVerbose("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling VerificationsApi->GetTransactionRecordVerbose", e2.Message);
    }

    [Fact]
    public async Task GetTransactionRecordVerboseAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordVerboseAsync(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionRecordVerbose", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionRecordVerboseAsync("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling VerificationsApi->GetTransactionRecordVerbose", e2.Message);
    }

    /* Test GetTransactionStatus */
    [Fact]
    public async Task GetTransactionStatusTest()
    {
      TransactionStatus expected = new TransactionStatus(
          transactionId: "test-transaction-guid",
          transactionRecordId: "test-transaction-record-guid",
          status: "test-status",
          uploadedDt: DateTime.Parse("2020-09-15T00:00:00+00:00"),
          isTimedOut: false
      );

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transaction/test-transaction-guid/status")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
              Response.Create()
                  .WithStatusCode(200)
                  .WithHeader("Content-Type", "application/json")
                  .WithBody(JsonConvert.SerializeObject(expected))
          );

      try
      {
        TransactionStatus result = verificationsApi.GetTransactionStatus("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        TransactionStatus result = await verificationsApi.GetTransactionStatusAsync("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetTransactionStatusUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/transaction/test-transaction-guid/status")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => verificationsApi.GetTransactionStatus("trial", "test-transaction-guid"));
    }

    [Fact]
    public void GetTransactionStatusNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionStatus(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionStatus", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => verificationsApi.GetTransactionStatus("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling VerificationsApi->GetTransactionStatus", e2.Message);
    }

    [Fact]
    public async Task GetTransactionStatusAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionStatusAsync(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->GetTransactionStatus", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.GetTransactionStatusAsync("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling VerificationsApi->GetTransactionStatus", e2.Message);
    }

    /* Test Verify */
    [Fact]
    public async Task VerifyTest()
    {
      VerifyResult expected = new VerifyResult(
          transactionID: "test-transaction-guid",
          uploadedDt: DateTime.Parse("2020-09-15T00:00:00+00:00"),
          record: new Trulioo.SDK.Model.Record(
              datasourceResults: new List<DatasourceResult>{
                        new DatasourceResult(datasourceFields: new List<DatasourceField>{
                            new DatasourceField(fieldName: "test-firstGivenName", status: "test-status")
                        })
              },
              recordStatus: "test-recordStatus",
              transactionRecordID: "test-transactionRecordID"
          ),
          customerReferenceID: "test-customerReferenceID",
          errors: new List<ServiceError>()
      );

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/verify")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingPost()
          )
          .RespondWith(
              Response.Create()
                  .WithStatusCode(200)
                  .WithHeader("Content-Type", "application/json")
                  .WithBody(JsonConvert.SerializeObject(expected))
          );

      try
      {
        VerifyResult result = verificationsApi.Verify("trial", new VerifyRequest(countryCode: "US", dataFields: new DataFields()));
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        VerifyResult result = await verificationsApi.VerifyAsync("trial", new VerifyRequest(countryCode: "US", dataFields: new DataFields()));
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void VerifyUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/verifications/v1/verify")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingPost()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => verificationsApi.Verify("trial", new VerifyRequest(countryCode: "US", dataFields: new DataFields())));
    }

    [Fact]
    public void VerifyNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => verificationsApi.Verify(null, new VerifyRequest(countryCode: "US", dataFields: new DataFields())));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->Verify", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => verificationsApi.Verify("trial", null));
      Assert.Equal("Missing required parameter 'verifyRequest' when calling VerificationsApi->Verify", e2.Message);
    }

    [Fact]
    public async Task VerifyAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.VerifyAsync(null, new VerifyRequest(countryCode: "US", dataFields: new DataFields())));
      Assert.Equal("Missing required parameter 'mode' when calling VerificationsApi->Verify", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => verificationsApi.VerifyAsync("trial", null));
      Assert.Equal("Missing required parameter 'verifyRequest' when calling VerificationsApi->Verify", e2.Message);
    }
  }
}