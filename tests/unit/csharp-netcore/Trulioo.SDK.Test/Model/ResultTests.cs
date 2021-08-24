using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class ResultTests
  {
    private Result result;

    public ResultTests()
    {
      result = new Result();
    }

    [Fact]
    public void IndexTest()
    {
      string index = "test-index";
      result.Index = index;

      Assert.Equal(index, result.Index);
      Assert.Equal(index, (new Result(index: index)).Index);
    }

    [Fact]
    public void BusinessNameTest()
    {
      string businessName = "test-businessName";
      result.BusinessName = businessName;

      Assert.Equal(businessName, result.BusinessName);
      Assert.Equal(businessName, (new Result(businessName: businessName)).BusinessName);
    }

    [Fact]
    public void MatchingScoreTest()
    {
      string matchingScore = "test-matchingScore";
      result.MatchingScore = matchingScore;

      Assert.Equal(matchingScore, result.MatchingScore);
      Assert.Equal(matchingScore, (new Result(matchingScore: matchingScore)).MatchingScore);
    }

    [Fact]
    public void BusinessRegistrationNumberTest()
    {
      string businessRegistrationNumber = "test-businessRegistrationNumber";
      result.BusinessRegistrationNumber = businessRegistrationNumber;

      Assert.Equal(businessRegistrationNumber, result.BusinessRegistrationNumber);
      Assert.Equal(businessRegistrationNumber, (new Result(businessRegistrationNumber: businessRegistrationNumber)).BusinessRegistrationNumber);
    }

    [Fact]
    public void DUNSNumberTest()
    {
      string dUNSNumber = "test-dUNSNumber";
      result.DUNSNumber = dUNSNumber;

      Assert.Equal(dUNSNumber, result.DUNSNumber);
      Assert.Equal(dUNSNumber, (new Result(dUNSNumber: dUNSNumber)).DUNSNumber);
    }

    [Fact]
    public void BusinessTaxIDNumberTest()
    {
      string businessTaxIDNumber = "test-businessTaxIDNumber";
      result.BusinessTaxIDNumber = businessTaxIDNumber;

      Assert.Equal(businessTaxIDNumber, result.BusinessTaxIDNumber);
      Assert.Equal(businessTaxIDNumber, (new Result(businessTaxIDNumber: businessTaxIDNumber)).BusinessTaxIDNumber);
    }

    [Fact]
    public void BusinessLicenseNumberTest()
    {
      string businessLicenseNumber = "test-businessLicenseNumber";
      result.BusinessLicenseNumber = businessLicenseNumber;

      Assert.Equal(businessLicenseNumber, result.BusinessLicenseNumber);
      Assert.Equal(businessLicenseNumber, (new Result(businessLicenseNumber: businessLicenseNumber)).BusinessLicenseNumber);
    }

    [Fact]
    public void JurisdictionOfIncorporationTest()
    {
      string jurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      result.JurisdictionOfIncorporation = jurisdictionOfIncorporation;

      Assert.Equal(jurisdictionOfIncorporation, result.JurisdictionOfIncorporation);
      Assert.Equal(jurisdictionOfIncorporation, (new Result(jurisdictionOfIncorporation: jurisdictionOfIncorporation)).JurisdictionOfIncorporation);
    }

    [Fact]
    public void FullAddressTest()
    {
      string fullAddress = "test-fullAddress";
      result.FullAddress = fullAddress;

      Assert.Equal(fullAddress, result.FullAddress);
      Assert.Equal(fullAddress, (new Result(fullAddress: fullAddress)).FullAddress);
    }

    [Fact]
    public void BusinessStatusTest()
    {
      string businessStatus = "test-businessStatus";
      result.BusinessStatus = businessStatus;

      Assert.Equal(businessStatus, result.BusinessStatus);
      Assert.Equal(businessStatus, (new Result(businessStatus: businessStatus)).BusinessStatus);
    }

    [Fact]
    public void TradeStyleNameTest()
    {
      string tradeStyleName = "test-tradeStyleName";
      result.TradeStyleName = tradeStyleName;

      Assert.Equal(tradeStyleName, result.TradeStyleName);
      Assert.Equal(tradeStyleName, (new Result(tradeStyleName: tradeStyleName)).TradeStyleName);
    }

    [Fact]
    public void BusinessTypeTest()
    {
      string businessType = "test-businessType";
      result.BusinessType = businessType;

      Assert.Equal(businessType, result.BusinessType);
      Assert.Equal(businessType, (new Result(businessType: businessType)).BusinessType);
    }

    [Fact]
    public void AddressTest()
    {
      Address address = new Address(buildingNumber: "test-buildingNumber");
      result.Address = address;

      Assert.Equal(address, result.Address);
      Assert.Equal(address, (new Result(address: address)).Address);
    }

    [Fact]
    public void OtherBusinessNamesTest()
    {
      List<string> otherBusinessNames = new List<string> { "test-otherBusinessName" };
      result.OtherBusinessNames = otherBusinessNames;

      Assert.Equal(otherBusinessNames, result.OtherBusinessNames);
      Assert.Equal(otherBusinessNames, (new Result(otherBusinessNames: otherBusinessNames)).OtherBusinessNames);
    }

    [Fact]
    public void WebsiteTest()
    {
      string website = "test-website";
      result.Website = website;

      Assert.Equal(website, result.Website);
      Assert.Equal(website, (new Result(website: website)).Website);
    }

    [Fact]
    public void TelephoneTest()
    {
      string telephone = "test-telephone";
      result.Telephone = telephone;

      Assert.Equal(telephone, result.Telephone);
      Assert.Equal(telephone, (new Result(telephone: telephone)).Telephone);
    }

    [Fact]
    public void TaxIDNumberTest()
    {
      string taxIDNumber = "test-taxIDNumber";
      result.TaxIDNumber = taxIDNumber;

      Assert.Equal(taxIDNumber, result.TaxIDNumber);
      Assert.Equal(taxIDNumber, (new Result(taxIDNumber: taxIDNumber)).TaxIDNumber);
    }

    [Fact]
    public void TaxIDNumbersTest()
    {
      List<string> taxIDNumbers = new List<string> { "test-taxIDNumbers" };
      result.TaxIDNumbers = taxIDNumbers;

      Assert.Equal(taxIDNumbers, result.TaxIDNumbers);
      Assert.Equal(taxIDNumbers, (new Result(taxIDNumbers: taxIDNumbers)).TaxIDNumbers);
    }

    [Fact]
    public void EmailAddressTest()
    {
      string emailAddress = "test-emailAddress";
      result.EmailAddress = emailAddress;

      Assert.Equal(emailAddress, result.EmailAddress);
      Assert.Equal(emailAddress, (new Result(emailAddress: emailAddress)).EmailAddress);
    }

    [Fact]
    public void WebDomainTest()
    {
      string webDomain = "test-webDomain";
      result.WebDomain = webDomain;

      Assert.Equal(webDomain, result.WebDomain);
      Assert.Equal(webDomain, (new Result(webDomain: webDomain)).WebDomain);
    }

    [Fact]
    public void WebDomainsTest()
    {
      List<string> webDomains = new List<string> { "test-webDomain" };
      result.WebDomains = webDomains;

      Assert.Equal(webDomains, result.WebDomains);
      Assert.Equal(webDomains, (new Result(webDomains: webDomains)).WebDomains);
    }

    [Fact]
    public void NAICSTest()
    {
      List<BusinessSearchResponseIndustryCode> nAICS = new List<BusinessSearchResponseIndustryCode> { new BusinessSearchResponseIndustryCode(code: "test-code") };
      result.NAICS = nAICS;

      Assert.Equal(nAICS, result.NAICS);
      Assert.Equal(nAICS, (new Result(nAICS: nAICS)).NAICS);
    }

    [Fact]
    public void SICTest()
    {
      List<BusinessSearchResponseIndustryCode> sIC = new List<BusinessSearchResponseIndustryCode> { new BusinessSearchResponseIndustryCode(code: "test-code") };
      result.SIC = sIC;

      Assert.Equal(sIC, result.SIC);
      Assert.Equal(sIC, (new Result(sIC: sIC)).SIC);
    }

    [Fact]
    public void EqualsTest()
    {
      string index = "test-index";
      Result index1 = new Result(index: index);

      Assert.Equal(index1, index1);
      Assert.Equal(index1, new Result(index: index));
      Assert.NotEqual(index1, new Result(index: index + "1"));
      Assert.False(index1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string index = "test-index";
      Result result = new Result(index: index);
      object obj = new Result(index: index);

      Assert.True(result.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<string> otherBusinessNames = new List<string>();
      List<string> taxIDNumbers = new List<string>();
      List<string> webDomains = new List<string>();
      List<BusinessSearchResponseIndustryCode> nAICS = new List<BusinessSearchResponseIndustryCode>();
      List<BusinessSearchResponseIndustryCode> sIC = new List<BusinessSearchResponseIndustryCode> { new BusinessSearchResponseIndustryCode(code: "test-code") };

      Result result1 = new Result();
      result1.Index = "test-index";
      result1.BusinessName = "test-businessName";
      result1.MatchingScore = "test-matchingScore";
      result1.BusinessRegistrationNumber = "test-businessRegistrationNumber";
      result1.DUNSNumber = "test-dUNSNumber";
      result1.BusinessTaxIDNumber = "test-businessTaxIDNumber";
      result1.BusinessLicenseNumber = "test-businessLicenseNumber";
      result1.JurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      result1.FullAddress = "test-fullAddress";
      result1.BusinessStatus = "test-businessStatus";
      result1.TradeStyleName = "test-tradeStyleName";
      result1.BusinessType = "test-businessType";
      result1.Website = "test-website";
      result1.Telephone = "test-telephone";
      result1.TaxIDNumber = "test-taxIDNumber";
      result1.EmailAddress = "test-emailAddress";
      result1.WebDomain = "test-webDomain";
      result1.Address = new Address(buildingNumber: "test-buildingNumber");
      result1.OtherBusinessNames = otherBusinessNames;
      result1.TaxIDNumbers = taxIDNumbers;
      result1.WebDomains = webDomains;
      result1.NAICS = nAICS;
      result1.SIC = sIC;

      Result result2 = new Result();
      result2.Index = "test-index";
      result2.BusinessName = "test-businessName";
      result2.MatchingScore = "test-matchingScore";
      result2.BusinessRegistrationNumber = "test-businessRegistrationNumber";
      result2.DUNSNumber = "test-dUNSNumber";
      result2.BusinessTaxIDNumber = "test-businessTaxIDNumber";
      result2.BusinessLicenseNumber = "test-businessLicenseNumber";
      result2.JurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      result2.FullAddress = "test-fullAddress";
      result2.BusinessStatus = "test-businessStatus";
      result2.TradeStyleName = "test-tradeStyleName";
      result2.BusinessType = "test-businessType";
      result2.Website = "test-website";
      result2.Telephone = "test-telephone";
      result2.TaxIDNumber = "test-taxIDNumber";
      result2.EmailAddress = "test-emailAddress";
      result2.WebDomain = "test-webDomain";
      result2.Address = new Address(buildingNumber: "test-buildingNumber");
      result2.OtherBusinessNames = otherBusinessNames;
      result2.TaxIDNumbers = taxIDNumbers;
      result2.WebDomains = webDomains;
      result2.NAICS = nAICS;
      result2.SIC = sIC;

      Assert.Equal(result1.GetHashCode(), result2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string index = "test-index";

      Assert.Equal(new Result(index: index).ToString(), new Result(index: index).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string index = "test-index";

      Assert.Equal(new Result(index: index).ToJson(), new Result(index: index).ToJson());
    }
  }
}