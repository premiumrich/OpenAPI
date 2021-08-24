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
  public class ConfigurationApiTests : IDisposable
  {
    private ConfigurationApi configurationApi;
    private WireMockServer mockServer;
    private const string TEST_API_KEY = "test-api-key";

    public ConfigurationApiTests()
    {
      int port = PortUtils.FindFreeTcpPort();
      Configuration config = new Configuration();
      config.BasePath = "http://localhost:" + port;
      config.ApiKey.Add("x-trulioo-api-key", TEST_API_KEY);
      configurationApi = new ConfigurationApi(config);

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
    public void ConfigurationApiTest()
    {
      configurationApi = new ConfigurationApi();
      Assert.Equal("https://gateway.trulioo.com", configurationApi.GetBasePath());
    }

    [Fact]
    public void ConfigurationApiBasePathTest()
    {
      string basePath = "http://abc.io";
      configurationApi = new ConfigurationApi(basePath);
      Assert.Equal(basePath, configurationApi.GetBasePath());
    }

    [Fact]
    public void ConfigurationApiConfigurationTest()
    {
      Configuration config = new Configuration();
      config.BasePath = "http://abc.io";
      configurationApi = new ConfigurationApi(config);
      Assert.Equal(config.BasePath, configurationApi.GetBasePath());
    }

    [Fact]
    public void ConfigurationApiApiAllParamsTest()
    {
      Configuration config = new Configuration();
      ApiClient client = new ApiClient();
      ApiClient asyncClient = new ApiClient();
      configurationApi = new ConfigurationApi(client, asyncClient, config);
      Assert.Equal(config, configurationApi.Configuration);
      Assert.Equal(client, configurationApi.Client);
      Assert.Equal(asyncClient, configurationApi.AsynchronousClient);
    }

    [Fact]
    public void ConfigurationApiNullParamsTest()
    {
      ArgumentNullException e0 = Assert.Throws<ArgumentNullException>(() => new ConfigurationApi((Configuration) null));
      Assert.Equal("Value cannot be null. (Parameter 'configuration')", e0.Message);

      ArgumentNullException e1 = Assert.Throws<ArgumentNullException>(() => new ConfigurationApi((ApiClient) null, new ApiClient(), new Configuration()));
      Assert.Equal("Value cannot be null. (Parameter 'client')", e1.Message);

      ArgumentNullException e2 = Assert.Throws<ArgumentNullException>(() => new ConfigurationApi(new ApiClient(), (ApiClient) null, new Configuration()));
      Assert.Equal("Value cannot be null. (Parameter 'asyncClient')", e2.Message);

      ArgumentNullException e3 = Assert.Throws<ArgumentNullException>(() => new ConfigurationApi(new ApiClient(), new ApiClient(), (Configuration) null));
      Assert.Equal("Value cannot be null. (Parameter 'configuration')", e3.Message);
    }

    /* Test GetBusinessRegistrationNumbers */
    [Fact]
    public async Task GetBusinessRegistrationNumbersTest()
    {
      List<BusinessRegistrationNumber> expected = new List<BusinessRegistrationNumber> { new BusinessRegistrationNumber(name: "test-name") };

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/businessregistrationnumbers/US/CA")
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
        List<BusinessRegistrationNumber> result = configurationApi.GetBusinessRegistrationNumbers("trial", "US", "CA");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        List<BusinessRegistrationNumber> result = await configurationApi.GetBusinessRegistrationNumbersAsync("trial", "US", "CA");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetBusinessRegistrationNumbersUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/businessregistrationnumbers/US/CA")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetBusinessRegistrationNumbers("trial", "US", "CA"));
    }

    [Fact]
    public void GetBusinessRegistrationNumbersNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetBusinessRegistrationNumbers(null, "US", "CA"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetBusinessRegistrationNumbers", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetBusinessRegistrationNumbers("trial", null, "CA"));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetBusinessRegistrationNumbers", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => configurationApi.GetBusinessRegistrationNumbers("trial", "US", null));
      Assert.Equal("Missing required parameter 'jurisdictionCode' when calling ConfigurationApi->GetBusinessRegistrationNumbers", e3.Message);
    }

    [Fact]
    public async Task GetBusinessRegistrationNumbersAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetBusinessRegistrationNumbersAsync(null, "US", "CA"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetBusinessRegistrationNumbers", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetBusinessRegistrationNumbersAsync("trial", null, "CA"));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetBusinessRegistrationNumbers", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetBusinessRegistrationNumbersAsync("trial", "US", null));
      Assert.Equal("Missing required parameter 'jurisdictionCode' when calling ConfigurationApi->GetBusinessRegistrationNumbers", e3.Message);
    }

    /* Test GetConsents */
    [Fact]
    public async Task GetConsentsTest()
    {
      List<string> expected = new List<string> { "test-consent1", "test-consent2" };

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/consents/Identity Verification/US")
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
        List<string> result = configurationApi.GetConsents("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException e)
      {
        Console.WriteLine(e);
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        List<string> result = await configurationApi.GetConsentsAsync("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetConsentsUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/consents/Identity Verification/US")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetConsents("trial", "Identity Verification", "US"));
    }

    [Fact]
    public void GetConsentsNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetConsents(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetConsents", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetConsents("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetConsents", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => configurationApi.GetConsents("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetConsents", e3.Message);
    }

    [Fact]
    public async Task GetConsentsAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetConsentsAsync(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetConsents", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetConsentsAsync("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetConsents", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetConsentsAsync("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetConsents", e3.Message);
    }

    /* Test GetCountryCodes */
    [Fact]
    public async Task GetCountryCodesTest()
    {
      List<string> expected = new List<string> { "test-countryCode1", "test-countryCode2" };

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/countrycodes/Identity Verification")
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
        List<string> result = configurationApi.GetCountryCodes("trial", "Identity Verification");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        List<string> result = await configurationApi.GetCountryCodesAsync("trial", "Identity Verification");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetCountryCodesUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/countrycodes/Identity Verification")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetCountryCodes("trial", "Identity Verification"));
    }

    [Fact]
    public void GetCountryCodesNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetCountryCodes(null, "Identity Verification"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetCountryCodes", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetCountryCodes("trial", null));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetCountryCodes", e2.Message);
    }

    [Fact]
    public async Task GetCountryCodesAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetCountryCodesAsync(null, "Identity Verification"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetCountryCodes", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetCountryCodesAsync("trial", null));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetCountryCodes", e2.Message);
    }

    /* Test GetCountrySubdivisions */
    [Fact]
    public async Task GetCountrySubdivisionsTest()
    {
      List<CountrySubdivision> expected = new List<CountrySubdivision> { new CountrySubdivision(name: "California", code: "US-CA", parentCode: "US") };

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/countrysubdivisions/US")
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
        List<CountrySubdivision> result = configurationApi.GetCountrySubdivisions("trial", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        List<CountrySubdivision> result = await configurationApi.GetCountrySubdivisionsAsync("trial", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetCountrySubdivisionsUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/countrysubdivisions/US")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetCountrySubdivisions("trial", "US"));
    }

    [Fact]
    public void GetCountrySubdivisionsNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetCountrySubdivisions(null, "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetCountrySubdivisions", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetCountrySubdivisions("trial", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetCountrySubdivisions", e2.Message);
    }

    [Fact]
    public async Task GetCountrySubdivisionsAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetCountrySubdivisionsAsync(null, "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetCountrySubdivisions", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetCountrySubdivisionsAsync("trial", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetCountrySubdivisions", e2.Message);
    }

    /* Test GetDatasources */
    [Fact]
    public async Task GetDatasourcesTest()
    {
      List<NormalizedDatasourceGroupCountry> expected = new List<NormalizedDatasourceGroupCountry> { new NormalizedDatasourceGroupCountry(name: "test-name", description: "test-description", coverage: "25%") };

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/datasources/Identity Verification/US")
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
        List<NormalizedDatasourceGroupCountry> result = configurationApi.GetDatasources("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        List<NormalizedDatasourceGroupCountry> result = await configurationApi.GetDatasourcesAsync("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetDatasourcesUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/datasources/Identity Verification/US")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetDatasources("trial", "Identity Verification", "US"));
    }

    [Fact]
    public void GetDatasourcesNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetDatasources(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetDatasources", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetDatasources("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetDatasources", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => configurationApi.GetDatasources("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetDatasources", e3.Message);
    }

    [Fact]
    public async Task GetDatasourcesAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetDatasourcesAsync(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetDatasources", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetDatasourcesAsync("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetDatasources", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetDatasourcesAsync("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetDatasources", e3.Message);
    }

    /* Test GetDetailedConsents */
    [Fact]
    public async Task GetDetailedConsentsTest()
    {
      List<Consent> expected = new List<Consent> { new Consent(name: "test-name", text: "test-text") };

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/detailedConsents/Identity Verification/US")
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
        List<Consent> result = configurationApi.GetDetailedConsents("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        List<Consent> result = await configurationApi.GetDetailedConsentsAsync("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetDetailedConsentsUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/detailedConsents/Identity Verification/US")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetDetailedConsents("trial", "Identity Verification", "US"));
    }

    [Fact]
    public void GetDetailedConsentsNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetDetailedConsents(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetDetailedConsents", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetDetailedConsents("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetDetailedConsents", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => configurationApi.GetDetailedConsents("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetDetailedConsents", e3.Message);
    }

    [Fact]
    public async Task GetDetailedConsentsAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetDetailedConsentsAsync(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetDetailedConsents", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetDetailedConsentsAsync("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetDetailedConsents", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetDetailedConsentsAsync("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetDetailedConsents", e3.Message);
    }

    /* Test GetDocumentTypes */
    [Fact]
    public async Task GetDocumentTypesTest()
    {
      Dictionary<string, List<string>> expected = new Dictionary<string, List<string>>{
                {"test-key", new List<string>{"test-list-value"}}
            };

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/documentTypes/US")
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
        Dictionary<string, List<string>> result = configurationApi.GetDocumentTypes("trial", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        Dictionary<string, List<string>> result = await configurationApi.GetDocumentTypesAsync("trial", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetDocumentTypesUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/documentTypes/US")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetDocumentTypes("trial", "US"));
    }

    [Fact]
    public void GetDocumentTypesNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetDocumentTypes(null, "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetDocumentTypes", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetDocumentTypes("trial", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetDocumentTypes", e2.Message);
    }

    [Fact]
    public async Task GetDocumentTypesAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetDocumentTypesAsync(null, "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetDocumentTypes", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetDocumentTypesAsync("trial", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetDocumentTypes", e2.Message);
    }

    /* Test GetFields */
    [Fact]
    public async Task GetFieldsTest()
    {
      JObject expected = new JObject();
      expected.Add("title", "test-title");
      expected.Add("type", "object");
      JObject expectedProperties = new JObject();
      expectedProperties.Add("PersonInfo", new JObject());
      expected.Add("properties", expectedProperties);

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/fields/Identity Verification/US")
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
        Object result = configurationApi.GetFields("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        Object result = await configurationApi.GetFieldsAsync("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetFieldsUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/fields/Identity Verification/US")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetFields("trial", "Identity Verification", "US"));
    }

    [Fact]
    public void GetFieldsNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetFields(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetFields", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetFields("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetFields", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => configurationApi.GetFields("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetFields", e3.Message);
    }

    [Fact]
    public async Task GetFieldsAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetFieldsAsync(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetFields", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetFieldsAsync("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetFields", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetFieldsAsync("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetFields", e3.Message);
    }

    /* Test GetRecommendedFields */
    [Fact]
    public async Task GetRecommendedFieldsTest()
    {
      JObject expected = new JObject();
      expected.Add("title", "test-title");
      expected.Add("type", "object");
      JObject expectedProperties = new JObject();
      expectedProperties.Add("PersonInfo", new JObject());
      expected.Add("properties", expectedProperties);

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/recommendedfields/Identity Verification/US")
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
        Object result = configurationApi.GetRecommendedFields("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        Object result = await configurationApi.GetRecommendedFieldsAsync("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetRecommendedFieldsUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/recommendedfields/Identity Verification/US")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetRecommendedFields("trial", "Identity Verification", "US"));
    }

    [Fact]
    public void GetRecommendedFieldsNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetRecommendedFields(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetRecommendedFields", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetRecommendedFields("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetRecommendedFields", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => configurationApi.GetRecommendedFields("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetRecommendedFields", e3.Message);
    }

    [Fact]
    public async Task GetRecommendedFieldsAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetRecommendedFieldsAsync(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetRecommendedFields", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetRecommendedFieldsAsync("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetRecommendedFields", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetRecommendedFieldsAsync("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetRecommendedFields", e3.Message);
    }

    /* Test GetTestEntities */
    [Fact]
    public async Task GetTestEntitiesTest()
    {
      List<TestEntityDataFields> expected = new List<TestEntityDataFields>{
                new TestEntityDataFields(
                    personInfo: new PersonInfo(
                        firstGivenName: "test-firstGivenName"
                    ),
                    location: new Location(
                        buildingNumber: "test-buildingNumber"
                    ),
                    communication: new Communication(
                        mobileNumber: "test-mobileNumber"
                    )
                )
            };

      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/testentities/Identity Verification/US")
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
        List<TestEntityDataFields> result = configurationApi.GetTestEntities("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }

      try
      {
        List<TestEntityDataFields> result = await configurationApi.GetTestEntitiesAsync("trial", "Identity Verification", "US");
        Assert.Equal(result, expected);
      }
      catch (ApiException)
      {
        Assert.True(false, "Unexpected ApiException");
      }
    }

    [Fact]
    public void GetTestEntitiesUnauthorizedTest()
    {
      mockServer
          .Given(
              Request.Create()
                  .WithPath("/trial/configuration/v1/testentities/Identity Verification/US")
                  .WithHeader("x-trulioo-api-key", TEST_API_KEY)
                  .UsingGet()
          )
          .RespondWith(
            Response.Create()
              .WithStatusCode(401)
          );

      Assert.Throws<ApiException>(() => configurationApi.GetTestEntities("trial", "Identity Verification", "US"));
    }

    [Fact]
    public void GetTestEntitiesNullParamsTest()
    {
      ApiException e1 = Assert.Throws<ApiException>(() => configurationApi.GetTestEntities(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetTestEntities", e1.Message);

      ApiException e2 = Assert.Throws<ApiException>(() => configurationApi.GetTestEntities("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetTestEntities", e2.Message);

      ApiException e3 = Assert.Throws<ApiException>(() => configurationApi.GetTestEntities("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetTestEntities", e3.Message);
    }

    [Fact]
    public async Task GetTestEntitiesAsyncNullParamsTest()
    {
      ApiException e1 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetTestEntitiesAsync(null, "Identity Verification", "US"));
      Assert.Equal("Missing required parameter 'mode' when calling ConfigurationApi->GetTestEntities", e1.Message);

      ApiException e2 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetTestEntitiesAsync("trial", null, "US"));
      Assert.Equal("Missing required parameter 'configurationName' when calling ConfigurationApi->GetTestEntities", e2.Message);

      ApiException e3 = await Assert.ThrowsAsync<ApiException>(() => configurationApi.GetTestEntitiesAsync("trial", "Identity Verification", null));
      Assert.Equal("Missing required parameter 'countryCode' when calling ConfigurationApi->GetTestEntities", e3.Message);
    }
  }
}