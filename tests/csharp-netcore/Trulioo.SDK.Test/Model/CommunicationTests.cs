using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class CommunicationTests
  {
    private Communication communication;

    public CommunicationTests()
    {
      communication = new Communication();
    }

    [Fact]
    public void MobileNumberTest()
    {
      string mobileNumber = "test-mobileNumber";
      communication.MobileNumber = mobileNumber;

      Assert.Equal(mobileNumber, communication.MobileNumber);
      Assert.Equal(mobileNumber, (new Communication(mobileNumber: mobileNumber)).MobileNumber);
    }

    [Fact]
    public void TelephoneTest()
    {
      string telephone = "test-telephone";
      communication.Telephone = telephone;

      Assert.Equal(telephone, communication.Telephone);
      Assert.Equal(telephone, (new Communication(telephone: telephone)).Telephone);
    }

    [Fact]
    public void Telephone2Test()
    {
      string telephone2 = "test-telephone2";
      communication.Telephone2 = telephone2;

      Assert.Equal(telephone2, communication.Telephone2);
      Assert.Equal(telephone2, (new Communication(telephone2: telephone2)).Telephone2);
    }

    [Fact]
    public void EmailAddressTest()
    {
      string emailAddress = "test-emailAddress";
      communication.EmailAddress = emailAddress;

      Assert.Equal(emailAddress, communication.EmailAddress);
      Assert.Equal(emailAddress, (new Communication(emailAddress: emailAddress)).EmailAddress);
    }

    [Fact]
    public void EqualsTest()
    {
      string mobileNumber = "test-mobileNumber";
      Communication mobileNumber1 = new Communication(mobileNumber: mobileNumber);

      Assert.Equal(mobileNumber1, mobileNumber1);
      Assert.Equal(mobileNumber1, new Communication(mobileNumber: mobileNumber));
      Assert.NotEqual(mobileNumber1, new Communication(mobileNumber: mobileNumber + "1"));
      Assert.False(mobileNumber1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string mobileNumber = "test-mobileNumber";
      Communication communication = new Communication(mobileNumber: mobileNumber);
      object obj = new Communication(mobileNumber: mobileNumber);

      Assert.True(communication.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      Communication communication1 = new Communication();
      communication1.MobileNumber = "test-mobileNumber";
      communication1.Telephone = "test-telephone";
      communication1.Telephone2 = "test-telephone2";
      communication1.EmailAddress = "test-emailAddress";

      Communication communication2 = new Communication();
      communication2.MobileNumber = "test-mobileNumber";
      communication2.Telephone = "test-telephone";
      communication2.Telephone2 = "test-telephone2";
      communication2.EmailAddress = "test-emailAddress";

      Assert.Equal(communication1.GetHashCode(), communication2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string mobileNumber = "test-mobileNumber";

      Assert.Equal(new Communication(mobileNumber: mobileNumber).ToString(), new Communication(mobileNumber: mobileNumber).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string mobileNumber = "test-mobileNumber";

      Assert.Equal(new Communication(mobileNumber: mobileNumber).ToJson(), new Communication(mobileNumber: mobileNumber).ToJson());
    }
  }
}