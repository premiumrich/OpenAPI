using Newtonsoft.Json;
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
  public class BusinessApiTests : IDisposable
  {
    private BusinessApi businessApi;
    private WireMockServer mockServer;
    private const string TEST_API_KEY = "test-api-key";

    public BusinessApiTests()
    {
      int port = PortUtils.FindFreeTcpPort();
      Configuration config = new Configuration();
      config.BasePath = "http://localhost:" + port;
      config.ApiKey.Add("x-trulioo-api-key", TEST_API_KEY);
      businessApi = new BusinessApi(config);

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
    public void BusinessApiTest()
    {
      businessApi = new BusinessApi();
      Assert.Equal("https://gateway.trulioo.com", businessApi.GetBasePath());
    }

    [Fact]
    public void BusinessApiBasePathTest()
    {
      string basePath = "http://abc.io";
      businessApi = new BusinessApi(basePath);
      Assert.Equal(basePath, businessApi.GetBasePath());
    }

    [Fact]
    public void BusinessApiConfigurationTest()
    {
      Configuration config = new Configuration();
      config.BasePath = "http://abc.io";
      businessApi = new BusinessApi(config);
      Assert.Equal(config.BasePath, businessApi.GetBasePath());
    }

    [Fact]
    public void BusinessApiApiAllParamsTest()
    {
      Configuration config = new Configuration();
      ApiClient client = new ApiClient();
      ApiClient asyncClient = new ApiClient();
      businessApi = new BusinessApi(client, asyncClient, config);
      Assert.Equal(config, businessApi.Configuration);
      Assert.Equal(client, businessApi.Client);
      Assert.Equal(asyncClient, businessApi.AsynchronousClient);
    }

    [Fact]
    public void BusinessApiNullParamsTest()
    {
      ArgumentNullException e0 = Assert.Throws<ArgumentNullException>(() => new BusinessApi((Configuration) null));
      Assert.Equal("Value cannot be null. (Parameter 'configuration')", e0.Message);

      ArgumentNullException e1 = Assert.Throws<ArgumentNullException>(() => new BusinessApi((ApiClient) null, new ApiClient(), new Configuration()));
      Assert.Equal("Value cannot be null. (Parameter 'client')", e1.Message);

      ArgumentNullException e2 = Assert.Throws<ArgumentNullException>(() => new BusinessApi(new ApiClient(), (ApiClient) null, new Configuration()));
      Assert.Equal("Value cannot be null. (Parameter 'asyncClient')", e2.Message);

      ArgumentNullException e3 = Assert.Throws<ArgumentNullException>(() => new BusinessApi(new ApiClient(), new ApiClient(), (Configuration) null));
      Assert.Equal("Value cannot be null. (Parameter 'configuration')", e3.Message);
    }

    [Fact]
    public async Task GetBusinessSearchResultTest()
    {
      BusinessSearchResponse expected = new BusinessSearchResponse(transactionID: "test-transactionID");
      mockServer
        .Given(
          Request.Create()
          .WithPath("/trial/business/v1/search/transactionrecord/test-transaction-guid")
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
        BusinessSearchResponse result = businessApi.GetBusinessSearchResult("trial", "test-transaction-guid");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpced ApiException");
      }

      try
      {
        BusinessSearchResponse result = await businessApi.GetBusinessSearchResultAsync("trial", "test-transaction-guid");
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpced ApiException");
      }
    }

    [Fact]
    public void GetBusinessSearchResultUnauthorizedTest()
    {
      mockServer
          .Given(
            Request.Create()
            .WithPath("/trial/business/v1/search/transactionrecord/test-transaction-guid")
            .WithHeader("x-trulioo-api-key", TEST_API_KEY)
            .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => businessApi.GetBusinessSearchResult("trial", "test-transaction-guid"));
    }

    [Fact]
    public void GetBusinessSearchResultNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => businessApi.GetBusinessSearchResult(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling BusinessApi->GetBusinessSearchResult", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => businessApi.GetBusinessSearchResult("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling BusinessApi->GetBusinessSearchResult", e2.Message);
    }

    [Fact]
    public async Task GetBusinessSearchResultAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => businessApi.GetBusinessSearchResultAsync(null, "test-transaction-guid"));
      Assert.Equal("Missing required parameter 'mode' when calling BusinessApi->GetBusinessSearchResult", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => businessApi.GetBusinessSearchResultAsync("trial", null));
      Assert.Equal("Missing required parameter 'id' when calling BusinessApi->GetBusinessSearchResult", e2.Message);
    }

    [Fact]
    public async Task SearchTest()
    {
      BusinessSearchResponse expected = new BusinessSearchResponse(
          transactionID: "test-transaction-guid",
          uploadedDt: DateTime.Parse("2020-09-15T00:00:00+00:00"),
          productName: "test-product-name",
          record: new BusinessRecord(
              datasourceResults: new List<BusinessResult>(),
              recordStatus: "test-recordStatus",
              transactionRecordID: "test-transactionRecordID",
              errors: new List<ServiceError>()
          ),
          countryCode: "test-countryCode"
      );

      mockServer
          .Given(
            Request.Create()
            .WithPath("/trial/business/v1/search")
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
        BusinessSearchResponse result = businessApi.Search("trial", new BusinessSearchRequest(countryCode: "test-countryCode"));
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        BusinessSearchResponse result = await businessApi.SearchAsync("trial", new BusinessSearchRequest(countryCode: "test-countryCode"));
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void SearchUnauthorizedTest()
    {
      mockServer
          .Given(
            Request.Create()
            .WithPath("/trial/business/v1/search")
            .WithHeader("x-trulioo-api-key", TEST_API_KEY)
            .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => businessApi.Search("trial", new BusinessSearchRequest(countryCode: "test-countryCode")));
    }

    [Fact]
    public void SearchNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => businessApi.Search(null, new BusinessSearchRequest(countryCode: "test-countryCode")));
      Assert.Equal("Missing required parameter 'mode' when calling BusinessApi->Search", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => businessApi.Search("trial", null));
      Assert.Equal("Missing required parameter 'businessSearchRequest' when calling BusinessApi->Search", e2.Message);
    }

    [Fact]
    public async Task SearchAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => businessApi.SearchAsync(null, new BusinessSearchRequest(countryCode: "test-countryCode")));
      Assert.Equal("Missing required parameter 'mode' when calling BusinessApi->Search", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => businessApi.SearchAsync("trial", null));
      Assert.Equal("Missing required parameter 'businessSearchRequest' when calling BusinessApi->Search", e2.Message);
    }
  }
}