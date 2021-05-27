using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessRegistrationNumberTests
  {
    private BusinessRegistrationNumber businessRegistrationNumber;

    public BusinessRegistrationNumberTests()
    {
      businessRegistrationNumber = new BusinessRegistrationNumber();
    }

    [Fact]
    public void NameTest()
    {
      string name = "test-name";
      businessRegistrationNumber.Name = name;

      Assert.Equal(name, businessRegistrationNumber.Name);
      Assert.Equal(name, (new BusinessRegistrationNumber(name: name)).Name);
    }

    [Fact]
    public void DescriptionTest()
    {
      string description = "test-description";
      businessRegistrationNumber.Description = description;

      Assert.Equal(description, businessRegistrationNumber.Description);
      Assert.Equal(description, (new BusinessRegistrationNumber(description: description)).Description);
    }

    [Fact]
    public void CountryTest()
    {
      string country = "test-country";
      businessRegistrationNumber.Country = country;

      Assert.Equal(country, businessRegistrationNumber.Country);
      Assert.Equal(country, (new BusinessRegistrationNumber(country: country)).Country);
    }

    [Fact]
    public void JurisdictionTest()
    {
      string jurisdiction = "test-jurisdiction";
      businessRegistrationNumber.Jurisdiction = jurisdiction;

      Assert.Equal(jurisdiction, businessRegistrationNumber.Jurisdiction);
      Assert.Equal(jurisdiction, (new BusinessRegistrationNumber(jurisdiction: jurisdiction)).Jurisdiction);
    }

    [Fact]
    public void SupportedTest()
    {
      bool supported = true;
      businessRegistrationNumber.Supported = supported;

      Assert.Equal(supported, businessRegistrationNumber.Supported);
      Assert.Equal(supported, (new BusinessRegistrationNumber(supported: supported)).Supported);
    }

    [Fact]
    public void TypeTest()
    {
      string type = "test-type";
      businessRegistrationNumber.Type = type;

      Assert.Equal(type, businessRegistrationNumber.Type);
      Assert.Equal(type, (new BusinessRegistrationNumber(type: type)).Type);
    }

    [Fact]
    public void MasksTest()
    {
      List<BusinessRegistrationNumberMask> masks = new List<BusinessRegistrationNumberMask> { new BusinessRegistrationNumberMask(mask: "test-mask") };
      businessRegistrationNumber.Masks = masks;

      Assert.Equal(masks, businessRegistrationNumber.Masks);
      Assert.Equal(masks, (new BusinessRegistrationNumber(masks: masks)).Masks);
    }

    [Fact]
    public void EqualsTest()
    {
      string name = "test-name";
      BusinessRegistrationNumber name1 = new BusinessRegistrationNumber(name: name);

      Assert.Equal(name1, name1);
      Assert.Equal(name1, new BusinessRegistrationNumber(name: name));
      Assert.False(name1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string name = "test-name";
      BusinessRegistrationNumber businessRegistrationNumber = new BusinessRegistrationNumber(name: name);
      object obj = new BusinessRegistrationNumber(name: name);

      Assert.True(businessRegistrationNumber.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<BusinessRegistrationNumberMask> masks = new List<BusinessRegistrationNumberMask> { new BusinessRegistrationNumberMask(mask: "test-mask") };

      BusinessRegistrationNumber businessRegistrationNumber1 = new BusinessRegistrationNumber();
      businessRegistrationNumber1.Name = "test-name";
      businessRegistrationNumber1.Description = "test-description";
      businessRegistrationNumber1.Country = "test-country";
      businessRegistrationNumber1.Jurisdiction = "test-jurisdiction";
      businessRegistrationNumber1.Supported = true;
      businessRegistrationNumber1.Type = "test-type";
      businessRegistrationNumber1.Masks = masks;

      BusinessRegistrationNumber businessRegistrationNumber2 = new BusinessRegistrationNumber();
      businessRegistrationNumber2.Name = "test-name";
      businessRegistrationNumber2.Description = "test-description";
      businessRegistrationNumber2.Country = "test-country";
      businessRegistrationNumber2.Jurisdiction = "test-jurisdiction";
      businessRegistrationNumber2.Supported = true;
      businessRegistrationNumber2.Type = "test-type";
      businessRegistrationNumber2.Masks = masks;

      Assert.Equal(businessRegistrationNumber1.GetHashCode(), businessRegistrationNumber2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string name = "test-name";

      Assert.Equal(new BusinessRegistrationNumber(name: name).ToString(), new BusinessRegistrationNumber(name: name).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string name = "test-name";

      Assert.Equal(new BusinessRegistrationNumber(name: name).ToJson(), new BusinessRegistrationNumber(name: name).ToJson());
    }
  }
}