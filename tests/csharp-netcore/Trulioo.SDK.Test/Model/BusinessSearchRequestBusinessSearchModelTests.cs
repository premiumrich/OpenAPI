using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessSearchRequestBusinessSearchModelTests
  {
    private BusinessSearchRequestBusinessSearchModel businessSearchRequestBusinessSearchModel;

    public BusinessSearchRequestBusinessSearchModelTests()
    {
      businessSearchRequestBusinessSearchModel = new BusinessSearchRequestBusinessSearchModel();
    }

    [Fact]
    public void BusinessNameTest()
    {
      string businessName = "test-businessName";
      businessSearchRequestBusinessSearchModel.BusinessName = businessName;

      Assert.Equal(businessName, businessSearchRequestBusinessSearchModel.BusinessName);
      Assert.Equal(businessName, (new BusinessSearchRequestBusinessSearchModel(businessName: businessName)).BusinessName);
    }

    [Fact]
    public void WebsiteTest()
    {
      string website = "test-website";
      businessSearchRequestBusinessSearchModel.Website = website;

      Assert.Equal(website, businessSearchRequestBusinessSearchModel.Website);
      Assert.Equal(website, (new BusinessSearchRequestBusinessSearchModel(website: website)).Website);
    }

    [Fact]
    public void JurisdictionOfIncorporationTest()
    {
      string jurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      businessSearchRequestBusinessSearchModel.JurisdictionOfIncorporation = jurisdictionOfIncorporation;

      Assert.Equal(jurisdictionOfIncorporation, businessSearchRequestBusinessSearchModel.JurisdictionOfIncorporation);
      Assert.Equal(jurisdictionOfIncorporation, (new BusinessSearchRequestBusinessSearchModel(jurisdictionOfIncorporation: jurisdictionOfIncorporation)).JurisdictionOfIncorporation);
    }

    [Fact]
    public void DUNSNumberTest()
    {
      string dUNSNumber = "test-dUNSNumber";
      businessSearchRequestBusinessSearchModel.DUNSNumber = dUNSNumber;

      Assert.Equal(dUNSNumber, businessSearchRequestBusinessSearchModel.DUNSNumber);
      Assert.Equal(dUNSNumber, (new BusinessSearchRequestBusinessSearchModel(dUNSNumber: dUNSNumber)).DUNSNumber);
    }

    [Fact]
    public void LocationTest()
    {
      Location location = new Location(city: "test-city");
      businessSearchRequestBusinessSearchModel.Location = location;

      Assert.Equal(location, businessSearchRequestBusinessSearchModel.Location);
      Assert.Equal(location, (new BusinessSearchRequestBusinessSearchModel(location: location)).Location);
    }

    [Fact]
    public void EqualsTest()
    {
      string businessName = "test-businessName";
      BusinessSearchRequestBusinessSearchModel businessName1 = new BusinessSearchRequestBusinessSearchModel(businessName: businessName);

      Assert.Equal(businessName1, businessName1);
      Assert.Equal(businessName1, new BusinessSearchRequestBusinessSearchModel(businessName: businessName));
      Assert.NotEqual(businessName1, new BusinessSearchRequestBusinessSearchModel(businessName: businessName + "1"));
      Assert.False(businessName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string businessName = "test-businessName";
      BusinessSearchRequestBusinessSearchModel businessSearchRequestBusinessSearchModel = new BusinessSearchRequestBusinessSearchModel(businessName: businessName);
      object obj = new BusinessSearchRequestBusinessSearchModel(businessName: businessName);

      Assert.True(businessSearchRequestBusinessSearchModel.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      BusinessSearchRequestBusinessSearchModel businessSearchRequestBusinessSearchModel1 = new BusinessSearchRequestBusinessSearchModel();
      businessSearchRequestBusinessSearchModel1.BusinessName = "test-businessName";
      businessSearchRequestBusinessSearchModel1.Website = "test-website";
      businessSearchRequestBusinessSearchModel1.JurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      businessSearchRequestBusinessSearchModel1.DUNSNumber = "test-dUNSNumber";
      businessSearchRequestBusinessSearchModel1.Location = new Location(city: "test-city");

      BusinessSearchRequestBusinessSearchModel businessSearchRequestBusinessSearchModel2 = new BusinessSearchRequestBusinessSearchModel();
      businessSearchRequestBusinessSearchModel2.BusinessName = "test-businessName";
      businessSearchRequestBusinessSearchModel2.Website = "test-website";
      businessSearchRequestBusinessSearchModel2.JurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      businessSearchRequestBusinessSearchModel2.DUNSNumber = "test-dUNSNumber";
      businessSearchRequestBusinessSearchModel2.Location = new Location(city: "test-city");
      Assert.Equal(businessSearchRequestBusinessSearchModel1.GetHashCode(), businessSearchRequestBusinessSearchModel2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string businessName = "test-businessName";

      Assert.Equal(new BusinessSearchRequestBusinessSearchModel(businessName: businessName).ToString(), new BusinessSearchRequestBusinessSearchModel(businessName: businessName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string businessName = "test-businessName";

      Assert.Equal(new BusinessSearchRequestBusinessSearchModel(businessName: businessName).ToJson(), new BusinessSearchRequestBusinessSearchModel(businessName: businessName).ToJson());
    }
  }
}