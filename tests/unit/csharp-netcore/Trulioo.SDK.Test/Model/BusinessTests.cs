using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessTests
  {
    private Business business;

    public BusinessTests()
    {
      business = new Business();
    }

    [Fact]
    public void BusinessNameTest()
    {
      string businessName = "test-businessName";
      business.BusinessName = businessName;

      Assert.Equal(businessName, business.BusinessName);
      Assert.Equal(businessName, (new Business(businessName: businessName)).BusinessName);
    }

    [Fact]
    public void BusinessRegistrationNumberTest()
    {
      string businessRegistrationNumber = "test-businessRegistrationNumber";
      business.BusinessRegistrationNumber = businessRegistrationNumber;

      Assert.Equal(businessRegistrationNumber, business.BusinessRegistrationNumber);
      Assert.Equal(businessRegistrationNumber, (new Business(businessRegistrationNumber: businessRegistrationNumber)).BusinessRegistrationNumber);
    }

    [Fact]
    public void DayOfIncorporationTest()
    {
      int dayOfIncorporation = 15;
      business.DayOfIncorporation = dayOfIncorporation;

      Assert.Equal(dayOfIncorporation, business.DayOfIncorporation);
      Assert.Equal(dayOfIncorporation, (new Business(dayOfIncorporation: dayOfIncorporation)).DayOfIncorporation);
    }

    [Fact]
    public void MonthOfIncorporationTest()
    {
      int monthOfIncorporation = 5;
      business.MonthOfIncorporation = monthOfIncorporation;

      Assert.Equal(monthOfIncorporation, business.MonthOfIncorporation);
      Assert.Equal(monthOfIncorporation, (new Business(monthOfIncorporation: monthOfIncorporation)).MonthOfIncorporation);
    }

    [Fact]
    public void YearOfIncorporationTest()
    {
      int yearOfIncorporation = 2000;
      business.YearOfIncorporation = yearOfIncorporation;

      Assert.Equal(yearOfIncorporation, business.YearOfIncorporation);
      Assert.Equal(yearOfIncorporation, (new Business(yearOfIncorporation: yearOfIncorporation)).YearOfIncorporation);
    }

    [Fact]
    public void JurisdictionOfIncorporationTest()
    {
      string jurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      business.JurisdictionOfIncorporation = jurisdictionOfIncorporation;

      Assert.Equal(jurisdictionOfIncorporation, business.JurisdictionOfIncorporation);
      Assert.Equal(jurisdictionOfIncorporation, (new Business(jurisdictionOfIncorporation: jurisdictionOfIncorporation)).JurisdictionOfIncorporation);
    }

    [Fact]
    public void ShareholderListDocumentTest()
    {
      bool shareholderListDocument = true;
      business.ShareholderListDocument = shareholderListDocument;

      Assert.Equal(shareholderListDocument, business.ShareholderListDocument);
      Assert.Equal(shareholderListDocument, (new Business(shareholderListDocument: shareholderListDocument)).ShareholderListDocument);
    }

    [Fact]
    public void FinancialInformationDocumentTest()
    {
      bool financialInformationDocument = false;
      business.FinancialInformationDocument = financialInformationDocument;

      Assert.Equal(financialInformationDocument, business.FinancialInformationDocument);
      Assert.Equal(financialInformationDocument, (new Business(financialInformationDocument: financialInformationDocument)).FinancialInformationDocument);
    }

    [Fact]
    public void DunsNumberTest()
    {
      string dunsNumber = "test-dunsNumber";
      business.DunsNumber = dunsNumber;

      Assert.Equal(dunsNumber, business.DunsNumber);
      Assert.Equal(dunsNumber, (new Business(dunsNumber: dunsNumber)).DunsNumber);
    }

    [Fact]
    public void EntitiesTest()
    {
      bool entities = true;
      business.Entities = entities;

      Assert.Equal(entities, business.Entities);
      Assert.Equal(entities, (new Business(entities: entities)).Entities);
    }

    [Fact]
    public void EqualsTest()
    {
      string businessName = "test-businessName";
      Business businessName1 = new Business(businessName: businessName);

      Assert.Equal(businessName1, businessName1);
      Assert.Equal(businessName1, new Business(businessName: businessName));
      Assert.NotEqual(businessName1, new Business(businessName: businessName + "1"));
      Assert.False(businessName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string businessName = "test-businessName";
      Business business = new Business(businessName: businessName);
      object obj = new Business(businessName: businessName);

      Assert.True(business.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      Business business1 = new Business();
      business1.BusinessName = "test-businessName";
      business1.BusinessRegistrationNumber = "test-businessRegistrationNumber";
      business1.DayOfIncorporation = 15;
      business1.MonthOfIncorporation = 5;
      business1.YearOfIncorporation = 2000;
      business1.JurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      business1.ShareholderListDocument = true;
      business1.FinancialInformationDocument = true;
      business1.DunsNumber = "test-dunsNumber";
      business1.Entities = true;

      Business business2 = new Business();
      business2.BusinessName = "test-businessName";
      business2.BusinessRegistrationNumber = "test-businessRegistrationNumber";
      business2.DayOfIncorporation = 15;
      business2.MonthOfIncorporation = 5;
      business2.YearOfIncorporation = 2000;
      business2.JurisdictionOfIncorporation = "test-jurisdictionOfIncorporation";
      business2.ShareholderListDocument = true;
      business2.FinancialInformationDocument = true;
      business2.DunsNumber = "test-dunsNumber";
      business2.Entities =  true;

      Assert.Equal(business1.GetHashCode(), business2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string businessName = "test-businessName";

      Assert.Equal(new Business(businessName: businessName).ToString(), new Business(businessName: businessName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string businessName = "test-businessName";

      Assert.Equal(new Business(businessName: businessName).ToJson(), new Business(businessName: businessName).ToJson());
    }
  }
}