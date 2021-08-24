using System;
using Xunit;
using Trulioo.SDK.Model;


namespace Trulioo.SDK.Test
{
  public class DriverLicenceTests
  {
    private DriverLicence driverLicence;

    public DriverLicenceTests()
    {
      driverLicence = new DriverLicence();
    }

    [Fact]
    public void NumberTest()
    {
      string number = "test-number";
      driverLicence.Number = number;

      Assert.Equal(number, driverLicence.Number);
      Assert.Equal(number, (new DriverLicence(number: number)).Number);
    }

    [Fact]
    public void StateTest()
    {
      string state = "test-state";
      driverLicence.State = state;

      Assert.Equal(state, driverLicence.State);
      Assert.Equal(state, (new DriverLicence(state: state)).State);
    }

    [Fact]
    public void DayOfExpiryTest()
    {
      int dayOfExpiry = 15;
      driverLicence.DayOfExpiry = dayOfExpiry;

      Assert.Equal(dayOfExpiry, driverLicence.DayOfExpiry);
      Assert.Equal(dayOfExpiry, (new DriverLicence(dayOfExpiry: dayOfExpiry)).DayOfExpiry);
    }

    [Fact]
    public void MonthOfExpiryTest()
    {
      int monthOfExpiry = 3;
      driverLicence.MonthOfExpiry = monthOfExpiry;

      Assert.Equal(monthOfExpiry, driverLicence.MonthOfExpiry);
      Assert.Equal(monthOfExpiry, (new DriverLicence(monthOfExpiry: monthOfExpiry)).MonthOfExpiry);
    }

    [Fact]
    public void YearOfExpiryTest()
    {
      int yearOfExpiry = 2025;
      driverLicence.YearOfExpiry = yearOfExpiry;

      Assert.Equal(yearOfExpiry, driverLicence.YearOfExpiry);
      Assert.Equal(yearOfExpiry, (new DriverLicence(yearOfExpiry: yearOfExpiry)).YearOfExpiry);
    }

    [Fact]
    public void EqualsTest()
    {
      string number = "test-number";
      DriverLicence number1 = new DriverLicence(number: number);

      Assert.Equal(number1, number1);
      Assert.Equal(number1, new DriverLicence(number: number));
      Assert.NotEqual(number1, new DriverLicence(number: number + "1"));
      Assert.False(number1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string number = "test-number";
      DriverLicence driverLicence = new DriverLicence(number: number);
      object obj = new DriverLicence(number: number);

      Assert.True(driverLicence.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      DriverLicence driverLicence1 = new DriverLicence();
      driverLicence1.Number = "test-number";
      driverLicence1.State = "test-state";
      driverLicence1.DayOfExpiry = 15;
      driverLicence1.MonthOfExpiry = 3;
      driverLicence1.YearOfExpiry = 2025;

      DriverLicence driverLicence2 = new DriverLicence();
      driverLicence2.Number = "test-number";
      driverLicence2.State = "test-state";
      driverLicence2.DayOfExpiry = 15;
      driverLicence2.MonthOfExpiry = 3;
      driverLicence2.YearOfExpiry = 2025;
      Assert.Equal(driverLicence1.GetHashCode(), driverLicence2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string number = "test-number";

      Assert.Equal(new DriverLicence(number: number).ToString(), new DriverLicence(number: number).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string number = "test-number";

      Assert.Equal(new DriverLicence(number: number).ToJson(), new DriverLicence(number: number).ToJson());
    }
  }
}