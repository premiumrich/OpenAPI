using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class TestEntityDataFieldsTests
  {
    private TestEntityDataFields testEntityDataFields;

    public TestEntityDataFieldsTests()
    {
      testEntityDataFields = new TestEntityDataFields();
    }

    [Fact]
    public void LocationTest()
    {
      Location location = new Location(city: "test-city");
      testEntityDataFields.Location = location;

      Assert.Equal(location, testEntityDataFields.Location);
      Assert.Equal(location, (new TestEntityDataFields(location: location)).Location);
    }

    [Fact]
    public void TestEntityNameTest()
    {
      string testEntityName = "test-testEntityName";
      testEntityDataFields.TestEntityName = testEntityName;

      Assert.Equal(testEntityName, testEntityDataFields.TestEntityName);
      Assert.Equal(testEntityName, (new TestEntityDataFields(testEntityName: testEntityName)).TestEntityName);
    }

    [Fact]
    public void PersonInfoTest()
    {
      PersonInfo personInfo = new PersonInfo(firstGivenName: "test-firstGivenName");
      testEntityDataFields.PersonInfo = personInfo;

      Assert.Equal(personInfo, testEntityDataFields.PersonInfo);
      Assert.Equal(personInfo, (new TestEntityDataFields(personInfo: personInfo)).PersonInfo);
    }

    [Fact]
    public void CommunicationTest()
    {
      Communication communication = new Communication(emailAddress: "test-emailAddress");
      testEntityDataFields.Communication = communication;

      Assert.Equal(communication, testEntityDataFields.Communication);
      Assert.Equal(communication, (new TestEntityDataFields(communication: communication)).Communication);
    }

    [Fact]
    public void DriverLicenceTest()
    {
      DriverLicence driverLicence = new DriverLicence(number: "test-number");
      testEntityDataFields.DriverLicence = driverLicence;

      Assert.Equal(driverLicence, testEntityDataFields.DriverLicence);
      Assert.Equal(driverLicence, (new TestEntityDataFields(driverLicence: driverLicence)).DriverLicence);
    }

    [Fact]
    public void NationalIdsTest()
    {
      List<NationalId> nationalIds = new List<NationalId> { new NationalId(number: "test-number") };
      testEntityDataFields.NationalIds = nationalIds;

      Assert.Equal(nationalIds, testEntityDataFields.NationalIds);
      Assert.Equal(nationalIds, (new TestEntityDataFields(nationalIds: nationalIds)).NationalIds);
    }

    [Fact]
    public void PassportTest()
    {
      Passport passport = new Passport(mrz1: "test-mrz1");
      testEntityDataFields.Passport = passport;

      Assert.Equal(passport, testEntityDataFields.Passport);
      Assert.Equal(passport, (new TestEntityDataFields(passport: passport)).Passport);
    }

    [Fact]
    public void DocumentTest()
    {
      Document document = new Document(documentType: "test-documentType");
      testEntityDataFields.Document = document;

      Assert.Equal(document, testEntityDataFields.Document);
      Assert.Equal(document, (new TestEntityDataFields(document: document)).Document);
    }

    [Fact]
    public void BusinessTest()
    {
      Business business = new Business(businessName: "test-businessName");
      testEntityDataFields.Business = business;

      Assert.Equal(business, testEntityDataFields.Business);
      Assert.Equal(business, (new TestEntityDataFields(business: business)).Business);
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
      testEntityDataFields.CountrySpecific = countrySpecific;

      Assert.Equal(countrySpecific, testEntityDataFields.CountrySpecific);
      Assert.Equal(countrySpecific, (new TestEntityDataFields(countrySpecific: countrySpecific)).CountrySpecific);
    }

    [Fact]
    public void EqualsTest()
    {
      Location location = new Location(city: "test-city");
      TestEntityDataFields location1 = new TestEntityDataFields(location: location);

      Assert.Equal(location1, location1);
      Assert.Equal(location1, new TestEntityDataFields(location: location));
      Assert.NotEqual(location1, new TestEntityDataFields(location: new Location(city: "test-city1")));
      Assert.False(location1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      Location location = new Location(city: "test-city");
      TestEntityDataFields testEntityDataFields = new TestEntityDataFields(location: location);
      object obj = new TestEntityDataFields(location: location);

      Assert.True(testEntityDataFields.Equals(obj));
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

      TestEntityDataFields testEntityDataFields1 = new TestEntityDataFields();
      testEntityDataFields1.TestEntityName = "test-testEntityName";
      testEntityDataFields1.PersonInfo = new PersonInfo(firstGivenName: "test-firstGivenName");
      testEntityDataFields1.Location = new Location(city: "test-city");
      testEntityDataFields1.Communication = new Communication(emailAddress: "test-emailAddress");
      testEntityDataFields1.DriverLicence = new DriverLicence(number: "test-number");
      testEntityDataFields1.NationalIds = nationalIds;
      testEntityDataFields1.Passport = new Passport(mrz1: "test-mrz1");
      testEntityDataFields1.Document = new Document(documentType: "test-documentType");
      testEntityDataFields1.Business = new Business(businessName: "test-businessName");
      testEntityDataFields1.CountrySpecific = countrySpecific;

      TestEntityDataFields testEntityDataFields2 = new TestEntityDataFields();
      testEntityDataFields2.TestEntityName = "test-testEntityName";
      testEntityDataFields2.PersonInfo = new PersonInfo(firstGivenName: "test-firstGivenName");
      testEntityDataFields2.Location = new Location(city: "test-city");
      testEntityDataFields2.Communication = new Communication(emailAddress: "test-emailAddress");
      testEntityDataFields2.DriverLicence = new DriverLicence(number: "test-number");
      testEntityDataFields2.NationalIds = nationalIds;
      testEntityDataFields2.Passport = new Passport(mrz1: "test-mrz1");
      testEntityDataFields2.Document = new Document(documentType: "test-documentType");
      testEntityDataFields2.Business = new Business(businessName: "test-businessName");
      testEntityDataFields2.CountrySpecific = countrySpecific;

      Assert.Equal(testEntityDataFields1.GetHashCode(), testEntityDataFields2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      Location location = new Location(city: "test-city");

      Assert.Equal(new TestEntityDataFields(location: location).ToString(), new TestEntityDataFields(location: location).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      Location location = new Location(city: "test-city");

      Assert.Equal(new TestEntityDataFields(location: location).ToJson(), new TestEntityDataFields(location: location).ToJson());
    }
  }
}