using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class LocationAdditionalFieldsTests
  {
    private LocationAdditionalFields locationAdditionalFields;

    public LocationAdditionalFieldsTests()
    {
      locationAdditionalFields = new LocationAdditionalFields();
    }

    [Fact]
    public void Address1Test()
    {
      string address1 = "test-address1";
      locationAdditionalFields.Address1 = address1;

      Assert.Equal(address1, locationAdditionalFields.Address1);
      Assert.Equal(address1, (new LocationAdditionalFields(address1: address1)).Address1);
    }

    [Fact]
    public void EqualsTest()
    {
      string address1 = "test-address1";
      LocationAdditionalFields address11 = new LocationAdditionalFields(address1: address1);

      Assert.Equal(address11, address11);
      Assert.Equal(address11, new LocationAdditionalFields(address1: address1));
      Assert.NotEqual(address11, new LocationAdditionalFields(address1: address1 + "1"));
      Assert.False(address11.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string address1 = "test-address1";
      LocationAdditionalFields locationAdditionalFields = new LocationAdditionalFields(address1: address1);
      object obj = new LocationAdditionalFields(address1: address1);

      Assert.True(locationAdditionalFields.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      LocationAdditionalFields locationAdditionalFields1 = new LocationAdditionalFields();
      locationAdditionalFields1.Address1 = "test-address1";

      LocationAdditionalFields locationAdditionalFields2 = new LocationAdditionalFields();
      locationAdditionalFields2.Address1 = "test-address1";

      Assert.Equal(locationAdditionalFields1.GetHashCode(), locationAdditionalFields2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string address1 = "test-address1";

      Assert.Equal(new LocationAdditionalFields(address1: address1).ToString(), new LocationAdditionalFields(address1: address1).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string address1 = "test-address1";

      Assert.Equal(new LocationAdditionalFields(address1: address1).ToJson(), new LocationAdditionalFields(address1: address1).ToJson());
    }
  }
}