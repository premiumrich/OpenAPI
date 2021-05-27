using System;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Trulioo.SDK.Model;


namespace Trulioo.SDK.Test
{
  public class AddressTests
  {
    private Address address;

    public AddressTests()
    {
      address = new Address();
    }

    [Fact]
    public void UnitNumberTest()
    {
      string unitNumber = "test-unitNumber";
      address.UnitNumber = unitNumber;

      Assert.Equal(unitNumber, address.UnitNumber);
      Assert.Equal(unitNumber, (new Address(unitNumber: unitNumber)).UnitNumber);
    }

    [Fact]
    public void BuildingNumberTest()
    {
      string buildingNumber = "test-buildingNumber";
      address.BuildingNumber = buildingNumber;

      Assert.Equal(buildingNumber, address.BuildingNumber);
      Assert.Equal(buildingNumber, (new Address(buildingNumber: buildingNumber)).BuildingNumber);
    }

    [Fact]
    public void BuildingNameTest()
    {
      string buildingName = "test-buildingName";
      address.BuildingName = buildingName;

      Assert.Equal(buildingName, address.BuildingName);
      Assert.Equal(buildingName, (new Address(buildingName: buildingName)).BuildingName);
    }

    [Fact]
    public void StreetNameTest()
    {
      string streetName = "test-streetName";
      address.StreetName = streetName;

      Assert.Equal(streetName, address.StreetName);
      Assert.Equal(streetName, (new Address(streetName: streetName)).StreetName);
    }

    [Fact]
    public void StreetTypeTest()
    {
      string streetType = "test-streetType";
      address.StreetType = streetType;

      Assert.Equal(streetType, address.StreetType);
      Assert.Equal(streetType, (new Address(streetType: streetType)).StreetType);
    }

    [Fact]
    public void CityTest()
    {
      string city = "test-city";
      address.City = city;

      Assert.Equal(city, address.City);
      Assert.Equal(city, (new Address(city: city)).City);
    }

    [Fact]
    public void SuburbTest()
    {
      string suburb = "test-suburb";
      address.Suburb = suburb;

      Assert.Equal(suburb, address.Suburb);
      Assert.Equal(suburb, (new Address(suburb: suburb)).Suburb);
    }

    [Fact]
    public void StateProvinceCodeTest()
    {
      string stateProvinceCode = "test-stateProvinceCode";
      address.StateProvinceCode = stateProvinceCode;

      Assert.Equal(stateProvinceCode, address.StateProvinceCode);
      Assert.Equal(stateProvinceCode, (new Address(stateProvinceCode: stateProvinceCode)).StateProvinceCode);
    }

    [Fact]
    public void PostalCodeTest()
    {
      string postalCode = "test-postalCode";
      address.PostalCode = postalCode;

      Assert.Equal(postalCode, address.PostalCode);
      Assert.Equal(postalCode, (new Address(postalCode: postalCode)).PostalCode);
    }

    [Fact]
    public void Address1Test()
    {
      string address1 = "test-address1";
      address.Address1 = address1;

      Assert.Equal(address1, address.Address1);
      Assert.Equal(address1, (new Address(address1: address1)).Address1);
    }

    [Fact]
    public void AddressTypeTest()
    {
      string addressType = "test-addressType";
      address.AddressType = addressType;

      Assert.Equal(addressType, address.AddressType);
      Assert.Equal(addressType, (new Address(addressType: addressType)).AddressType);
    }

    [Fact]
    public void StateProvinceTest()
    {
      string stateProvince = "test-stateProvince";
      address.StateProvince = stateProvince;

      Assert.Equal(stateProvince, address.StateProvince);
      Assert.Equal(stateProvince, (new Address(stateProvince: stateProvince)).StateProvince);
    }

    [Fact]
    public void CountryTest()
    {
      string country = "test-country";
      address.Country = country;

      Assert.Equal(country, address.Country);
      Assert.Equal(country, (new Address(country: country)).Country);
    }

    [Fact]
    public void CountryCodeTest()
    {
      string countryCode = "test-countryCode";
      address.CountryCode = countryCode;

      Assert.Equal(countryCode, address.CountryCode);
      Assert.Equal(countryCode, (new Address(countryCode: countryCode)).CountryCode);
    }

    [Fact]
    public void EqualsTest()
    {
      string unitNumber = "test-unitNumber";
      Address unitNumber1 = new Address(unitNumber: unitNumber);

      Assert.Equal(unitNumber1, unitNumber1);
      Assert.Equal(unitNumber1, new Address(unitNumber: unitNumber));
      Assert.NotEqual(unitNumber1, new Address(unitNumber: unitNumber + "1"));
      Assert.False(unitNumber1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string unitNumber = "test-unitNumber";
      Address address = new Address(unitNumber: unitNumber);
      object obj = new Address(unitNumber: unitNumber);

      Assert.True(address.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      Address address1 = new Address();
      address1.UnitNumber = "test-unitNumber";
      address1.BuildingNumber = "test-buildingNumber";
      address1.BuildingName = "test-buildingName";
      address1.StreetName = "test-streetName";
      address1.StreetType = "test-streetType";
      address1.City = "test-city";
      address1.Suburb = "test-suburb";
      address1.StateProvinceCode = "test-stateProvinceCode";
      address1.PostalCode = "test-postalCode";
      address1.Address1 = "test-address1";
      address1.AddressType = "test-addressType";
      address1.StateProvince = "test-stateProvince";
      address1.Country = "test-country";
      address1.CountryCode = "test-countryCode";

      Address address2 = new Address();
      address2.UnitNumber = "test-unitNumber";
      address2.BuildingNumber = "test-buildingNumber";
      address2.BuildingName = "test-buildingName";
      address2.StreetName = "test-streetName";
      address2.StreetType = "test-streetType";
      address2.City = "test-city";
      address2.Suburb = "test-suburb";
      address2.StateProvinceCode = "test-stateProvinceCode";
      address2.PostalCode = "test-postalCode";
      address2.Address1 = "test-address1";
      address2.AddressType = "test-addressType";
      address2.StateProvince = "test-stateProvince";
      address2.Country = "test-country";
      address2.CountryCode = "test-countryCode";

      Assert.Equal(address1.GetHashCode(), address2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string unitNumber = "test-unitNumber";

      Assert.Equal(new Address(unitNumber: unitNumber).ToString(), new Address(unitNumber: unitNumber).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string unitNumber = "test-unitNumber";

      Assert.Equal(new Address(unitNumber: unitNumber).ToJson(), new Address(unitNumber: unitNumber).ToJson());
    }
  }
}