using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class VerifyRequestTests
  {
    private VerifyRequest verifyRequest;

    public VerifyRequestTests()
    {
      verifyRequest = new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")));
    }

    [Fact]
    public void AcceptTruliooTermsAndConditionsTest()
    {
      bool acceptTruliooTermsAndConditions = true;
      verifyRequest.AcceptTruliooTermsAndConditions = acceptTruliooTermsAndConditions;

      Assert.Equal(acceptTruliooTermsAndConditions, verifyRequest.AcceptTruliooTermsAndConditions);
      Assert.Equal(acceptTruliooTermsAndConditions, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions)).AcceptTruliooTermsAndConditions);
    }

    [Fact]
    public void DemoTest()
    {
      bool demo = false;
      verifyRequest.Demo = demo;

      Assert.Equal(demo, verifyRequest.Demo);
      Assert.Equal(demo, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), demo: demo)).Demo);
    }

    [Fact]
    public void CallBackUrlTest()
    {
      string callBackUrl = "test-callBackUrl";
      verifyRequest.CallBackUrl = callBackUrl;

      Assert.Equal(callBackUrl, verifyRequest.CallBackUrl);
      Assert.Equal(callBackUrl, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), callBackUrl: callBackUrl)).CallBackUrl);
    }

    [Fact]
    public void TimeoutTest()
    {
      int timeout = 3000;
      verifyRequest.Timeout = timeout;

      Assert.Equal(timeout, verifyRequest.Timeout);
      Assert.Equal(timeout, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), timeout: timeout)).Timeout);
    }

    [Fact]
    public void CleansedAddressTest()
    {
      bool cleansedAddress = false;
      verifyRequest.CleansedAddress = cleansedAddress;

      Assert.Equal(cleansedAddress, verifyRequest.CleansedAddress);
      Assert.Equal(cleansedAddress, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), cleansedAddress: cleansedAddress)).CleansedAddress);
    }

    [Fact]
    public void ConfigurationNameTest()
    {
      string configurationName = "test-configurationName";
      verifyRequest.ConfigurationName = configurationName;

      Assert.Equal(configurationName, verifyRequest.ConfigurationName);
      Assert.Equal(configurationName, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), configurationName: configurationName)).ConfigurationName);
    }

    [Fact]
    public void ConsentForDataSourcesTest()
    {
      List<string> consentForDataSources = new List<string> { "test-consentForDataSources" };
      verifyRequest.ConsentForDataSources = consentForDataSources;

      Assert.Equal(consentForDataSources, verifyRequest.ConsentForDataSources);
      Assert.Equal(consentForDataSources, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), consentForDataSources: consentForDataSources)).ConsentForDataSources);
    }

    [Fact]
    public void CountryCodeTest()
    {
      string countryCode = "test-countryCode";
      verifyRequest.CountryCode = countryCode;

      Assert.Equal(countryCode, verifyRequest.CountryCode);
      Assert.Equal(countryCode, (new VerifyRequest(countryCode: countryCode, dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")))).CountryCode);
    }

    [Fact]
    public void CustomerReferenceIDTest()
    {
      string customerReferenceID = "test-customerReferenceID";
      verifyRequest.CustomerReferenceID = customerReferenceID;

      Assert.Equal(customerReferenceID, verifyRequest.CustomerReferenceID);
      Assert.Equal(customerReferenceID, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), customerReferenceID: customerReferenceID)).CustomerReferenceID);
    }

    [Fact]
    public void DataFieldsTest()
    {
      DataFields dataFields = new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName"));
      verifyRequest.DataFields = dataFields;

      Assert.Equal(dataFields, verifyRequest.DataFields);
      Assert.Equal(dataFields, (new VerifyRequest(countryCode: "test-countryCode", dataFields: dataFields)).DataFields);
    }

    [Fact]
    public void VerboseModeTest()
    {
      bool verboseMode = true;
      verifyRequest.VerboseMode = verboseMode;

      Assert.Equal(verboseMode, verifyRequest.VerboseMode);
      Assert.Equal(verboseMode, (new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), verboseMode: verboseMode)).VerboseMode);
    }

    [Fact]
    public void EqualsTest()
    {
      bool acceptTruliooTermsAndConditions = true;
      VerifyRequest acceptTruliooTermsAndConditions1 = new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions);

      Assert.Equal(acceptTruliooTermsAndConditions1, acceptTruliooTermsAndConditions1);
      Assert.Equal(acceptTruliooTermsAndConditions1, new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions));
      Assert.NotEqual(acceptTruliooTermsAndConditions1, new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: !acceptTruliooTermsAndConditions));
      Assert.False(acceptTruliooTermsAndConditions1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      bool acceptTruliooTermsAndConditions = true;
      VerifyRequest verifyRequest = new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions);
      object obj = new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions);

      Assert.True(verifyRequest.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<string> consentForDataSources = new List<string>();

      VerifyRequest verifyRequest1 = new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")));
      verifyRequest1.AcceptTruliooTermsAndConditions = true;
      verifyRequest1.Demo = true;
      verifyRequest1.CallBackUrl = "test-callBackUrl";
      verifyRequest1.Timeout = 1000;
      verifyRequest1.CleansedAddress =true;
      verifyRequest1.ConfigurationName = "test-configurationName";
      verifyRequest1.CustomerReferenceID = "test-customerReferenceID";
      verifyRequest1.VerboseMode = true;
      verifyRequest1.ConsentForDataSources = consentForDataSources;

      VerifyRequest verifyRequest2 = new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")));
      verifyRequest2.AcceptTruliooTermsAndConditions = true;
      verifyRequest2.Demo = true;
      verifyRequest2.CallBackUrl = "test-callBackUrl";
      verifyRequest2.Timeout = 1000;
      verifyRequest2.CleansedAddress = true;
      verifyRequest2.ConfigurationName = "test-configurationName";
      verifyRequest2.CustomerReferenceID = "test-customerReferenceID";
      verifyRequest2.VerboseMode = true;
      verifyRequest2.ConsentForDataSources = consentForDataSources;

      Assert.Equal(verifyRequest1.GetHashCode(), verifyRequest2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      bool acceptTruliooTermsAndConditions = true;

      Assert.Equal(new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions).ToString(), new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      bool acceptTruliooTermsAndConditions = true;

      Assert.Equal(new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions).ToJson(), new VerifyRequest(countryCode: "test-countryCode", dataFields: new DataFields(personInfo: new PersonInfo(firstGivenName: "test-firstGivenName")), acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions).ToJson());
    }
  }
}