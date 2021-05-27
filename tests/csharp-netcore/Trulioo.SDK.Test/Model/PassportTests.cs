using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class PassportTests
  {
    private Passport passport;

    public PassportTests()
    {
      passport = new Passport();
    }

    [Fact]
    public void Mrz1Test()
    {
      string mrz1 = "test-mrz1";
      passport.Mrz1 = mrz1;

      Assert.Equal(mrz1, passport.Mrz1);
      Assert.Equal(mrz1, (new Passport(mrz1: mrz1)).Mrz1);
    }

    [Fact]
    public void Mrz2Test()
    {
      string mrz2 = "test-mrz2";
      passport.Mrz2 = mrz2;

      Assert.Equal(mrz2, passport.Mrz2);
      Assert.Equal(mrz2, (new Passport(mrz2: mrz2)).Mrz2);
    }

    [Fact]
    public void NumberTest()
    {
      string number = "test-number";
      passport.Number = number;

      Assert.Equal(number, passport.Number);
      Assert.Equal(number, (new Passport(number: number)).Number);
    }

    [Fact]
    public void DayOfExpiryTest()
    {
      int dayOfExpiry = 10;
      passport.DayOfExpiry = dayOfExpiry;

      Assert.Equal(dayOfExpiry, passport.DayOfExpiry);
      Assert.Equal(dayOfExpiry, (new Passport(dayOfExpiry: dayOfExpiry)).DayOfExpiry);
    }

    [Fact]
    public void MonthOfExpiryTest()
    {
      int monthOfExpiry = 9;
      passport.MonthOfExpiry = monthOfExpiry;

      Assert.Equal(monthOfExpiry, passport.MonthOfExpiry);
      Assert.Equal(monthOfExpiry, (new Passport(monthOfExpiry: monthOfExpiry)).MonthOfExpiry);
    }

    [Fact]
    public void YearOfExpiryTest()
    {
      int yearOfExpiry = 2025;
      passport.YearOfExpiry = yearOfExpiry;

      Assert.Equal(yearOfExpiry, passport.YearOfExpiry);
      Assert.Equal(yearOfExpiry, (new Passport(yearOfExpiry: yearOfExpiry)).YearOfExpiry);
    }

    [Fact]
    public void EqualsTest()
    {
      string mrz1 = "test-mrz1";
      Passport mrz11 = new Passport(mrz1: mrz1);

      Assert.Equal(mrz11, mrz11);
      Assert.Equal(mrz11, new Passport(mrz1: mrz1));
      Assert.NotEqual(mrz11, new Passport(mrz1: mrz1 + "1"));
      Assert.False(mrz11.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string mrz1 = "test-mrz1";
      Passport passport = new Passport(mrz1: mrz1);
      object obj = new Passport(mrz1: mrz1);

      Assert.True(passport.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      Passport passport1 = new Passport();
      passport1.Mrz1 = "test-mrz1";
      passport1.Mrz2 = "test-mrz2";
      passport1.Number = "test-number";
      passport1.DayOfExpiry = 15;
      passport1.MonthOfExpiry = 3;
      passport1.YearOfExpiry = 2000;

      Passport passport2 = new Passport();
      passport2.Mrz1 = "test-mrz1";
      passport2.Mrz2 = "test-mrz2";
      passport2.Number = "test-number";
      passport2.DayOfExpiry = 15;
      passport2.MonthOfExpiry = 3;
      passport2.YearOfExpiry = 2000;

      Assert.Equal(passport1.GetHashCode(), passport2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string mrz1 = "test-mrz1";

      Assert.Equal(new Passport(mrz1: mrz1).ToString(), new Passport(mrz1: mrz1).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string mrz1 = "test-mrz1";

      Assert.Equal(new Passport(mrz1: mrz1).ToJson(), new Passport(mrz1: mrz1).ToJson());
    }
  }
}