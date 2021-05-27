using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class LocationTests
  {
    private Location location;

    public LocationTests()
    {
      location = new Location();
    }

    [Fact]
    public void BuildingNumberTest()
    {
      string buildingNumber = "test-buildingNumber";
      location.BuildingNumber = buildingNumber;

      Assert.Equal(buildingNumber, location.BuildingNumber);
      Assert.Equal(buildingNumber, (new Location(buildingNumber: buildingNumber)).BuildingNumber);
    }

    [Fact]
    public void BuildingNameTest()
    {
      string buildingName = "test-buildingName";
      location.BuildingName = buildingName;

      Assert.Equal(buildingName, location.BuildingName);
      Assert.Equal(buildingName, (new Location(buildingName: buildingName)).BuildingName);
    }

    [Fact]
    public void UnitNumberTest()
    {
      string unitNumber = "test-unitNumber";
      location.UnitNumber = unitNumber;

      Assert.Equal(unitNumber, location.UnitNumber);
      Assert.Equal(unitNumber, (new Location(unitNumber: unitNumber)).UnitNumber);
    }

    [Fact]
    public void StreetNameTest()
    {
      string streetName = "test-streetName";
      location.StreetName = streetName;

      Assert.Equal(streetName, location.StreetName);
      Assert.Equal(streetName, (new Location(streetName: streetName)).StreetName);
    }

    [Fact]
    public void StreetTypeTest()
    {
      string streetType = "test-streetType";
      location.StreetType = streetType;

      Assert.Equal(streetType, location.StreetType);
      Assert.Equal(streetType, (new Location(streetType: streetType)).StreetType);
    }

    [Fact]
    public void CityTest()
    {
      string city = "test-city";
      location.City = city;

      Assert.Equal(city, location.City);
      Assert.Equal(city, (new Location(city: city)).City);
    }

    [Fact]
    public void SuburbTest()
    {
      string suburb = "test-suburb";
      location.Suburb = suburb;

      Assert.Equal(suburb, location.Suburb);
      Assert.Equal(suburb, (new Location(suburb: suburb)).Suburb);
    }

    [Fact]
    public void CountyTest()
    {
      string county = "test-county";
      location.County = county;

      Assert.Equal(county, location.County);
      Assert.Equal(county, (new Location(county: county)).County);
    }

    [Fact]
    public void StateProvinceCodeTest()
    {
      string stateProvinceCode = "test-stateProvinceCode";
      location.StateProvinceCode = stateProvinceCode;

      Assert.Equal(stateProvinceCode, location.StateProvinceCode);
      Assert.Equal(stateProvinceCode, (new Location(stateProvinceCode: stateProvinceCode)).StateProvinceCode);
    }

    [Fact]
    public void CountryTest()
    {
      string country = "test-country";
      location.Country = country;

      Assert.Equal(country, location.Country);
      Assert.Equal(country, (new Location(country: country)).Country);
    }

    [Fact]
    public void PostalCodeTest()
    {
      string postalCode = "test-postalCode";
      location.PostalCode = postalCode;

      Assert.Equal(postalCode, location.PostalCode);
      Assert.Equal(postalCode, (new Location(postalCode: postalCode)).PostalCode);
    }

    [Fact]
    public void POBoxTest()
    {
      string pOBox = "test-pOBox";
      location.POBox = pOBox;

      Assert.Equal(pOBox, location.POBox);
      Assert.Equal(pOBox, (new Location(pOBox: pOBox)).POBox);
    }

    [Fact]
    public void AdditionalFieldsTest()
    {
      LocationAdditionalFields additionalFields = new LocationAdditionalFields(address1: "test-address1");
      location.AdditionalFields = additionalFields;

      Assert.Equal(additionalFields, location.AdditionalFields);
      Assert.Equal(additionalFields, (new Location(additionalFields: additionalFields)).AdditionalFields);
    }

    [Fact]
    public void EqualsTest()
    {
      string buildingNumber = "test-buildingNumber";
      Location buildingNumber1 = new Location(buildingNumber: buildingNumber);

      Assert.Equal(buildingNumber1, buildingNumber1);
      Assert.Equal(buildingNumber1, new Location(buildingNumber: buildingNumber));
      Assert.NotEqual(buildingNumber1, new Location(buildingNumber: buildingNumber + "1"));
      Assert.False(buildingNumber1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string buildingNumber = "test-buildingNumber";
      Location location = new Location(buildingNumber: buildingNumber);
      object obj = new Location(buildingNumber: buildingNumber);

      Assert.True(location.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      Location location1 = new Location();
      location1.BuildingNumber = "test-buildingNumber";
      location1.BuildingName = "test-buildingName";
      location1.UnitNumber = "test-unitNumber";
      location1.StreetName = "test-streetName";
      location1.StreetType = "test-streetType";
      location1.City = "test-city";
      location1.Suburb = "test-suburb";
      location1.County = "test-county";
      location1.StateProvinceCode = "test-stateProvinceCode";
      location1.Country = "test-country";
      location1.PostalCode = "test-postalCode";
      location1.POBox = "test-pOBox";
      location1.AdditionalFields = new LocationAdditionalFields(address1: "test-address1");

      Location location2 = new Location();
      location2.BuildingNumber = "test-buildingNumber";
      location2.BuildingName = "test-buildingName";
      location2.UnitNumber = "test-unitNumber";
      location2.StreetName = "test-streetName";
      location2.StreetType = "test-streetType";
      location2.City = "test-city";
      location2.Suburb = "test-suburb";
      location2.County = "test-county";
      location2.StateProvinceCode = "test-stateProvinceCode";
      location2.Country = "test-country";
      location2.PostalCode = "test-postalCode";
      location2.POBox = "test-pOBox";
      location2.AdditionalFields = new LocationAdditionalFields(address1: "test-address1");

      Assert.Equal(location1.GetHashCode(), location2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string buildingNumber = "test-buildingNumber";

      Assert.Equal(new Location(buildingNumber: buildingNumber).ToString(), new Location(buildingNumber: buildingNumber).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string buildingNumber = "test-buildingNumber";

      Assert.Equal(new Location(buildingNumber: buildingNumber).ToJson(), new Location(buildingNumber: buildingNumber).ToJson());
    }
  }
}