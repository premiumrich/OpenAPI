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
  public class ConnectionApiTests : IDisposable
  {
    private ConnectionApi connectionApi;
    private WireMockServer mockServer;
    private const string TEST_API_KEY = "test-api-key";

    public ConnectionApiTests()
    {
      int port = PortUtils.FindFreeTcpPort();
      Configuration config = new Configuration();
      config.BasePath = "http://localhost:" + port;
      config.ApiKey.Add("x-trulioo-api-key", TEST_API_KEY);
      connectionApi = new ConnectionApi(config);

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
    public void ConnectionApiTest()
    {
      connectionApi = new ConnectionApi();
      Assert.Equal("https://gateway.trulioo.com", connectionApi.GetBasePath());
    }

    [Fact]
    public void ConnectionApiBasePathTest()
    {
      string basePath = "http://abc.io";
      connectionApi = new ConnectionApi(basePath);
      Assert.Equal(basePath, connectionApi.GetBasePath());
    }

    [Fact]
    public void ConnectionApiConfigurationTest()
    {
      Configuration config = new Configuration();
      config.BasePath = "http://abc.io";
      connectionApi = new ConnectionApi(config);
      Assert.Equal(config.BasePath, connectionApi.GetBasePath());
    }

    [Fact]
    public void ConnectionApiApiAllParamsTest()
    {
      Configuration config = new Configuration();
      ApiClient client = new ApiClient();
      ApiClient asyncClient = new ApiClient();
      connectionApi = new ConnectionApi(client, asyncClient, config);
      Assert.Equal(config, connectionApi.Configuration);
      Assert.Equal(client, connectionApi.Client);
      Assert.Equal(asyncClient, connectionApi.AsynchronousClient);
    }

    [Fact]
    public void ConnectionApiNullParamsTest()
    {
      ArgumentNullException e0 = Assert.Throws<ArgumentNullException>(() => new ConnectionApi((Configuration) null));
      Assert.Equal("Value cannot be null. (Parameter 'configuration')", e0.Message);

      ArgumentNullException e1 = Assert.Throws<ArgumentNullException>(() => new ConnectionApi((ApiClient) null, new ApiClient(), new Configuration()));
      Assert.Equal("Value cannot be null. (Parameter 'client')", e1.Message);

      ArgumentNullException e2 = Assert.Throws<ArgumentNullException>(() => new ConnectionApi(new ApiClient(), (ApiClient) null, new Configuration()));
      Assert.Equal("Value cannot be null. (Parameter 'asyncClient')", e2.Message);

      ArgumentNullException e3 = Assert.Throws<ArgumentNullException>(() => new ConnectionApi(new ApiClient(), new ApiClient(), (Configuration) null));
      Assert.Equal("Value cannot be null. (Parameter 'configuration')", e3.Message);
    }

    /* Test ConnectionAsyncCallbackUrl */
    [Fact]
    public async Task ConnectionAsyncCallbackUrlTest()
    {
      JObject expected = new JObject();

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/connection/v1/async-callback")
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
        Object result = connectionApi.ConnectionAsyncCallbackUrl("trial", new TransactionStatus());
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        Object result = await connectionApi.ConnectionAsyncCallbackUrlAsync("trial", new TransactionStatus());
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void ConnectionAsyncCallbackUrlUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/connection/v1/async-callback")
                  .UsingPost()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => connectionApi.ConnectionAsyncCallbackUrl("trial", new TransactionStatus()));
    }

    [Fact]
    public void ConnectionAsyncCallbackUrlNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => connectionApi.ConnectionAsyncCallbackUrl(null, new TransactionStatus()));
      Assert.Equal("Missing required parameter 'mode' when calling ConnectionApi->ConnectionAsyncCallbackUrl", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => connectionApi.ConnectionAsyncCallbackUrl("trial", null));
      Assert.Equal("Missing required parameter 'transactionStatus' when calling ConnectionApi->ConnectionAsyncCallbackUrl", e2.Message);
    }

    [Fact]
    public async Task ConnectionAsyncCallbackUrlAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => connectionApi.ConnectionAsyncCallbackUrlAsync(null, new TransactionStatus()));
      Assert.Equal("Missing required parameter 'mode' when calling ConnectionApi->ConnectionAsyncCallbackUrl", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => connectionApi.ConnectionAsyncCallbackUrlAsync("trial", null));
      Assert.Equal("Missing required parameter 'transactionStatus' when calling ConnectionApi->ConnectionAsyncCallbackUrl", e2.Message);
    }

    /* Test SayHello */
    [Fact]
    public async Task SayHelloTest()
    {
      string expected = "Hello Trulioo User";

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/connection/v1/sayhello/Trulioo User")
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
        string result = connectionApi.SayHello("trial", "Trulioo User");
        Assert.Equal(result, "\"" + expected + "\"");
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        string result = await connectionApi.SayHelloAsync("trial", "Trulioo User");
        Assert.Equal(result, "\"" + expected + "\"");
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void SayHelloUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/connection/v1/sayhello/Trulioo User")
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => connectionApi.SayHello("trial", "Trulioo User"));
    }

    [Fact]
    public void SayHelloNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => connectionApi.SayHello(null, "Trulioo User"));
      Assert.Equal("Missing required parameter 'mode' when calling ConnectionApi->SayHello", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => connectionApi.SayHello("trial", null));
      Assert.Equal("Missing required parameter 'name' when calling ConnectionApi->SayHello", e2.Message);
    }

    [Fact]
    public async Task SayHelloAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => connectionApi.SayHelloAsync(null, "Trulioo User"));
      Assert.Equal("Missing required parameter 'mode' when calling ConnectionApi->SayHello", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => connectionApi.SayHelloAsync("trial", null));
      Assert.Equal("Missing required parameter 'name' when calling ConnectionApi->SayHello", e2.Message);
    }

    /* Test TestAuthentication */
    [Fact]
    public async Task TestAuthenticationTest()
    {
      string expected = "Hello Trulioo User";

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/connection/v1/testauthentication")
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
        string result = connectionApi.TestAuthentication("trial");
        Assert.Equal(result, "\"" + expected + "\"");
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        string result = await connectionApi.TestAuthenticationAsync("trial");
        Assert.Equal(result, "\"" + expected + "\"");
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void TestAuthenticationUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/connection/v1/testauthentication")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => connectionApi.TestAuthentication("trial"));
    }

    [Fact]
    public void TestAuthenticationNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => connectionApi.TestAuthentication(null));
      Assert.Equal("Missing required parameter 'mode' when calling ConnectionApi->TestAuthentication", e1.Message);
    }

    [Fact]
    public async Task TestAuthenticationAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => connectionApi.TestAuthenticationAsync(null));
      Assert.Equal("Missing required parameter 'mode' when calling ConnectionApi->TestAuthentication", e1.Message);
    }
  }
}