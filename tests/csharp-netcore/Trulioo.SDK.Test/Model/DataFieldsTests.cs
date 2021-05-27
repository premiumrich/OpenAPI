using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class DataFieldsTests
  {
    private DataFields dataFields;

    public DataFieldsTests()
    {
      dataFields = new DataFields();
    }

    [Fact]
    public void PersonInfoTest()
    {
      PersonInfo personInfo = new PersonInfo(firstGivenName: "test-firstGivenName");
      dataFields.PersonInfo = personInfo;

      Assert.Equal(personInfo, dataFields.PersonInfo);
      Assert.Equal(personInfo, (new DataFields(personInfo: personInfo)).PersonInfo);
    }

    [Fact]
    public void LocationTest()
    {
      Location location = new Location(city: "test-city");
      dataFields.Location = location;

      Assert.Equal(location, dataFields.Location);
      Assert.Equal(location, (new DataFields(location: location)).Location);
    }

    [Fact]
    public void CommunicationTest()
    {
      Communication communication = new Communication(emailAddress: "test-emailAddress");
      dataFields.Communication = communication;

      Assert.Equal(communication, dataFields.Communication);
      Assert.Equal(communication, (new DataFields(communication: communication)).Communication);
    }

    [Fact]
    public void DriverLicenceTest()
    {
      DriverLicence driverLicence = new DriverLicence(number: "test-number");
      dataFields.DriverLicence = driverLicence;

      Assert.Equal(driverLicence, dataFields.DriverLicence);
      Assert.Equal(driverLicence, (new DataFields(driverLicence: driverLicence)).DriverLicence);
    }

    [Fact]
    public void NationalIdsTest()
    {
      List<NationalId> nationalIds = new List<NationalId> { new NationalId(number: "test-number") };
      dataFields.NationalIds = nationalIds;

      Assert.Equal(nationalIds, dataFields.NationalIds);
      Assert.Equal(nationalIds, (new DataFields(nationalIds: nationalIds)).NationalIds);
    }

    [Fact]
    public void PassportTest()
    {
      Passport passport = new Passport(mrz1: "test-mrz1");
      dataFields.Passport = passport;

      Assert.Equal(passport, dataFields.Passport);
      Assert.Equal(passport, (new DataFields(passport: passport)).Passport);
    }

    [Fact]
    public void DocumentTest()
    {
      Document document = new Document(documentType: "test-documentType");
      dataFields.Document = document;

      Assert.Equal(document, dataFields.Document);
      Assert.Equal(document, (new DataFields(document: document)).Document);
    }

    [Fact]
    public void BusinessTest()
    {
      Business business = new Business(businessName: "test-businessName");
      dataFields.Business = business;

      Assert.Equal(business, dataFields.Business);
      Assert.Equal(business, (new DataFields(business: business)).Business);
    }

    [Fact]
    public void CountrySpecificTest()
    {
      Dictionary<string, Dictionary<string, string>> countrySpecific = new Dictionary<string, Dictionary<string, string>>
                {
                    { "test-outerKey1", new Dictionary<string, string> { { "test-key1", "test-value1" }, { "test-key2", "test-value2" } } },
                    { "test-outerKey2", new Dictionary<string, string> { { "test-key1", "test-value1" }, { "test-key2", "test-value2" } } },
                    { "test-outerKey3", new Dictionary<string, string> { { "test-key1", "test-value1" }, { "test-key2", "test-value2" } } }
                };
      dataFields.CountrySpecific = countrySpecific;

      Assert.Equal(countrySpecific, dataFields.CountrySpecific);
      Assert.Equal(countrySpecific, (new DataFields(countrySpecific: countrySpecific)).CountrySpecific);
    }

    [Fact]
    public void EqualsTest()
    {
      PersonInfo personInfo = new PersonInfo(firstGivenName: "test-firstGivenName");
      DataFields personInfo1 = new DataFields(personInfo: personInfo);

      Assert.Equal(personInfo1, personInfo1);
      Assert.Equal(personInfo1, new DataFields(personInfo: personInfo));
      Assert.NotEqual(personInfo1, new DataFields(personInfo: new PersonInfo(firstSurName: "test-firstSurName")));
      Assert.False(personInfo1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      PersonInfo personInfo = new PersonInfo(firstGivenName: "test-firstGivenName");
      DataFields dataFields = new DataFields(personInfo: personInfo);
      object obj = new DataFields(personInfo: personInfo);

      Assert.True(dataFields.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<NationalId> nationalIds = new List<NationalId>();
      Dictionary<string, Dictionary<string, string>> countrySpecific = new Dictionary<string, Dictionary<string, string>>
                {
                    { "test-outerKey1", new Dictionary<string, string> { { "test-key1", "test-value1" }, { "test-key2", "test-value2" } } },
                    { "test-outerKey2", new Dictionary<string, string> { { "test-key1", "test-value1" }, { "test-key2", "test-value2" } } },
                    { "test-outerKey3", new Dictionary<string, string> { { "test-key1", "test-value1" }, { "test-key2", "test-value2" } } }
                };
      DataFields dataFields1 = new DataFields();
      dataFields1.PersonInfo = new PersonInfo(firstGivenName: "test-firstGivenName");
      dataFields1.Location = new Location(city: "test-city");
      dataFields1.Communication = new Communication(emailAddress: "test-emailAddress");
      dataFields1.DriverLicence = new DriverLicence(number: "test-number");
      dataFields1.NationalIds = nationalIds;
      dataFields1.Passport = new Passport(mrz1: "test-mrz1");
      dataFields1.Document = new Document(documentType: "test-documentType");
      dataFields1.Business = new Business(businessName: "test-businessName");
      dataFields1.CountrySpecific = countrySpecific;

      DataFields dataFields2 = new DataFields();
      dataFields2.PersonInfo = new PersonInfo(firstGivenName: "test-firstGivenName");
      dataFields2.Location = new Location(city: "test-city");
      dataFields2.Communication = new Communication(emailAddress: "test-emailAddress");
      dataFields2.DriverLicence = new DriverLicence(number: "test-number");
      dataFields2.NationalIds = nationalIds;
      dataFields2.Passport = new Passport(mrz1: "test-mrz1");
      dataFields2.Document = new Document(documentType: "test-documentType");
      dataFields2.Business = new Business(businessName: "test-businessName");
      dataFields2.CountrySpecific = countrySpecific;

      Assert.Equal(dataFields1.GetHashCode(), dataFields2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      PersonInfo personInfo = new PersonInfo(firstGivenName: "test-firstGivenName");

      Assert.Equal(new DataFields(personInfo: personInfo).ToString(), new DataFields(personInfo: personInfo).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      PersonInfo personInfo = new PersonInfo(firstGivenName: "test-firstGivenName");

      Assert.Equal(new DataFields(personInfo: personInfo).ToJson(), new DataFields(personInfo: personInfo).ToJson());
    }
  }
}