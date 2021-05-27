using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessSearchRequestTests
  {
    private BusinessSearchRequest businessSearchRequest;

    public BusinessSearchRequestTests()
    {
      businessSearchRequest = new BusinessSearchRequest(countryCode: "test-countryCode");
    }

    [Fact]
    public void AcceptTruliooTermsAndConditionsTest()
    {
      bool acceptTruliooTermsAndConditions = true;
      businessSearchRequest.AcceptTruliooTermsAndConditions = acceptTruliooTermsAndConditions;

      Assert.Equal(acceptTruliooTermsAndConditions, businessSearchRequest.AcceptTruliooTermsAndConditions);
      Assert.Equal(acceptTruliooTermsAndConditions, (new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions)).AcceptTruliooTermsAndConditions);
    }

    [Fact]
    public void CallBackUrlTest()
    {
      string callBackUrl = "test-callBackUrl";
      businessSearchRequest.CallBackUrl = callBackUrl;

      Assert.Equal(callBackUrl, businessSearchRequest.CallBackUrl);
      Assert.Equal(callBackUrl, (new BusinessSearchRequest(countryCode: "test-countryCode", callBackUrl: callBackUrl)).CallBackUrl);
    }

    [Fact]
    public void TimeoutTest()
    {
      int timeout = 1000;
      businessSearchRequest.Timeout = timeout;

      Assert.Equal(timeout, businessSearchRequest.Timeout);
      Assert.Equal(timeout, (new BusinessSearchRequest(countryCode: "test-countryCode", timeout: timeout)).Timeout);
    }

    [Fact]
    public void ConsentForDataSourcesTest()
    {
      List<string> consentForDataSources = new List<string> { "value 1", "value 2" };
      businessSearchRequest.ConsentForDataSources = consentForDataSources;

      Assert.Equal(consentForDataSources, businessSearchRequest.ConsentForDataSources);
      Assert.Equal(consentForDataSources, (new BusinessSearchRequest(countryCode: "test-countryCode", consentForDataSources: consentForDataSources)).ConsentForDataSources);
    }

    [Fact]
    public void BusinessTest()
    {
      BusinessSearchRequestBusinessSearchModel business = new BusinessSearchRequestBusinessSearchModel();
      businessSearchRequest.Business = business;

      Assert.Equal(business, businessSearchRequest.Business);
      Assert.Equal(business, (new BusinessSearchRequest(countryCode: "test-countryCode", business: business)).Business);
    }

    [Fact]
    public void CountryCodeTest()
    {
      string countryCode = "test-countryCode";
      businessSearchRequest.CountryCode = countryCode;

      Assert.Equal(countryCode, businessSearchRequest.CountryCode);
      Assert.Equal(countryCode, (new BusinessSearchRequest(countryCode: countryCode)).CountryCode);
    }

    [Fact]
    public void EqualsTest()
    {
      bool acceptTruliooTermsAndConditions = true;
      BusinessSearchRequest acceptTruliooTermsAndConditions1 = new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions);

      Assert.Equal(acceptTruliooTermsAndConditions1, acceptTruliooTermsAndConditions1);
      Assert.Equal(acceptTruliooTermsAndConditions1, new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions));
      Assert.NotEqual(acceptTruliooTermsAndConditions1, new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: false));
      Assert.False(acceptTruliooTermsAndConditions1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      bool acceptTruliooTermsAndConditions = true;
      BusinessSearchRequest businessSearchRequest = new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions);
      object obj = new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions);

      Assert.True(businessSearchRequest.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<string> consentForDataSources = new List<string> { "value 1", "value 2" };
      BusinessSearchRequest businessSearchRequest1 = new BusinessSearchRequest(countryCode: "test-countryCode");
      businessSearchRequest1.AcceptTruliooTermsAndConditions = true;
      businessSearchRequest1.CallBackUrl = "test-callBackUrl";
      businessSearchRequest1.Timeout = 1000;
      businessSearchRequest1.ConsentForDataSources = consentForDataSources;
      businessSearchRequest1.Business = new BusinessSearchRequestBusinessSearchModel();

      BusinessSearchRequest businessSearchRequest2 = new BusinessSearchRequest(countryCode: "test-countryCode");
      businessSearchRequest2.AcceptTruliooTermsAndConditions = true;
      businessSearchRequest2.CallBackUrl = "test-callBackUrl";
      businessSearchRequest2.Timeout = 1000;
      businessSearchRequest2.ConsentForDataSources = consentForDataSources;
      businessSearchRequest2.Business = new BusinessSearchRequestBusinessSearchModel();

      Assert.Equal(businessSearchRequest1.GetHashCode(), businessSearchRequest2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      bool acceptTruliooTermsAndConditions = true;

      Assert.Equal(new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions).ToString(), new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      bool acceptTruliooTermsAndConditions = true;

      Assert.Equal(new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions).ToJson(), new BusinessSearchRequest(countryCode: "test-countryCode", acceptTruliooTermsAndConditions: acceptTruliooTermsAndConditions).ToJson());
    }
  }
}