using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trulioo.SDK.Api;
using Trulioo.SDK.Client;
using Trulioo.SDK.Model;

namespace Trulioo.SampleApp.Controllers
{
  public class ApiController : Controller
  {
    private Configuration config;
    private const string Mode = "trial";
    private const string ConfigurationName = "Identity Verification";
    public ApiController(IConfiguration iConfig)
    {
      string apiKey = iConfig.GetValue<string>("XTruliooApiKey");
      config = new Configuration();
      config.ApiKey.Add("x-trulioo-api-key", apiKey);
    }

    [Route("test-authentication")]
    public IActionResult TestAuthentication()
    {
      try
      {
        string result = new ConnectionApi(config).TestAuthentication(Mode);
        return new OkObjectResult(result);
      }
      catch (ApiException e)
      {
        return StatusCode(e.ErrorCode, new Trulioo.SampleApp.Models.ObjectResult(
          errorCode: e.ErrorCode,
          message: e.Message,
          headers: e.Headers,
          operation: "ConnectionApi#TestAuthentication"
        ));
      }
    }

    [Route("get-countries")]
    public IActionResult GetCountries()
    {
      try
      {
        List<string> result = new ConfigurationApi(config).GetCountryCodes(Mode, ConfigurationName);
        return new OkObjectResult(JsonConvert.SerializeObject(result));
      }
      catch (ApiException e)
      {
        return StatusCode(e.ErrorCode, new Trulioo.SampleApp.Models.ObjectResult(
          errorCode: e.ErrorCode,
          message: e.Message,
          headers: e.Headers,
          operation: "ConfigurationApi#GetCountryCodes"
        ));
      }
    }

    [HttpPost]
    [Route("get-test-entities")]
    public IActionResult GetTestEntities([FromBody]string body)
    {
      try
      {
        JObject obj = JObject.Parse(body);
        List<TestEntityDataFields> result = new ConfigurationApi(config).GetTestEntities(Mode, ConfigurationName, obj["countryCode"].ToString());
        return new OkObjectResult(JsonConvert.SerializeObject(result));
      }
      catch (ApiException e)
      {
        return StatusCode(e.ErrorCode, new Trulioo.SampleApp.Models.ObjectResult(
          errorCode: e.ErrorCode,
          message: e.Message,
          headers: e.Headers,
          operation: "ConfigurationApi#GetTestEntities"
        ));
      }
    }

    [HttpPost]
    [Route("get-consents")]
    public IActionResult GetConsents([FromBody]string body)
    {
      try
      {
        JObject obj = JObject.Parse(body);
        List<string> result = new ConfigurationApi(config).GetConsents(Mode, ConfigurationName, obj["countryCode"].ToString());
        return new OkObjectResult(JsonConvert.SerializeObject(result));
      }
      catch (ApiException e)
      {
        return StatusCode(e.ErrorCode, new Trulioo.SampleApp.Models.ObjectResult(
          errorCode: e.ErrorCode,
          message: e.Message,
          headers: e.Headers,
          operation: "ConfigurationApi#GetConsents"
        ));
      }
    }

    [HttpPost]
    [Route("verify")]
    public IActionResult Verify([FromBody]string body)
    {
      JObject obj = JObject.Parse(body);
      PersonInfo personInfo = new PersonInfo();
      personInfo.FirstGivenName = obj["firstGivenName"].ToString();
      personInfo.MiddleName = obj["middleName"].ToString();
      personInfo.FirstSurName = obj["firstSurName"].ToString();
      personInfo.YearOfBirth = (int)obj["yearOfBirth"];
      personInfo.MonthOfBirth = (int)obj["monthOfBirth"];
      personInfo.DayOfBirth = (int)obj["dayOfBirth"];

      Location location = new Location();
      location.BuildingNumber = obj["buildingNumber"].ToString();
      location.StreetName = obj["streetName"].ToString();
      location.StreetType = obj["streetType"].ToString();
      location.PostalCode = obj["postalCode"].ToString();

      Communication communication = new Communication();
      communication.Telephone = obj["telephone"].ToString();
      communication.EmailAddress = obj["emailAddress"].ToString();

      Passport passport = new Passport();
      passport.Number = obj["passportNumber"].ToString();

      DataFields dataFields = new DataFields();
      dataFields.PersonInfo = personInfo;
      dataFields.Location = location;
      dataFields.Communication = communication;
      dataFields.Passport = passport;

      VerifyRequest verifyRequest = new VerifyRequest(countryCode: "AU", dataFields: dataFields);
      verifyRequest.AcceptTruliooTermsAndConditions = true;
      verifyRequest.CleansedAddress = false;
      verifyRequest.ConfigurationName = ConfigurationName;

      try
      {
        VerifyResult result = new VerificationsApi(config).Verify(Mode, verifyRequest);
        return new OkObjectResult(JsonConvert.SerializeObject(result));
      }
      catch (ApiException e)
      {
        return StatusCode(e.ErrorCode, new Trulioo.SampleApp.Models.ObjectResult(
          errorCode: e.ErrorCode,
          message: e.Message,
          headers: e.Headers,
          operation: "VerificationsApi#Verify"
        ));
      }
    }

  }
}