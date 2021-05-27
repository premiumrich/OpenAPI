using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class PersonInfoTests
  {
    private PersonInfo personInfo;

    public PersonInfoTests()
    {
      personInfo = new PersonInfo();
    }

    [Fact]
    public void FirstGivenNameTest()
    {
      string firstGivenName = "test-firstGivenName";
      personInfo.FirstGivenName = firstGivenName;

      Assert.Equal(firstGivenName, personInfo.FirstGivenName);
      Assert.Equal(firstGivenName, (new PersonInfo(firstGivenName: firstGivenName)).FirstGivenName);
    }

    [Fact]
    public void MiddleNameTest()
    {
      string middleName = "test-middleName";
      personInfo.MiddleName = middleName;

      Assert.Equal(middleName, personInfo.MiddleName);
      Assert.Equal(middleName, (new PersonInfo(middleName: middleName)).MiddleName);
    }

    [Fact]
    public void FirstSurNameTest()
    {
      string firstSurName = "test-firstSurName";
      personInfo.FirstSurName = firstSurName;

      Assert.Equal(firstSurName, personInfo.FirstSurName);
      Assert.Equal(firstSurName, (new PersonInfo(firstSurName: firstSurName)).FirstSurName);
    }

    [Fact]
    public void SecondSurnameTest()
    {
      string secondSurname = "test-secondSurname";
      personInfo.SecondSurname = secondSurname;

      Assert.Equal(secondSurname, personInfo.SecondSurname);
      Assert.Equal(secondSurname, (new PersonInfo(secondSurname: secondSurname)).SecondSurname);
    }

    [Fact]
    public void ISOLatin1NameTest()
    {
      string iSOLatin1Name = "test-iSOLatin1Name";
      personInfo.ISOLatin1Name = iSOLatin1Name;

      Assert.Equal(iSOLatin1Name, personInfo.ISOLatin1Name);
      Assert.Equal(iSOLatin1Name, (new PersonInfo(iSOLatin1Name: iSOLatin1Name)).ISOLatin1Name);
    }

    [Fact]
    public void DayOfBirthTest()
    {
      int dayOfBirth = 12;
      personInfo.DayOfBirth = dayOfBirth;

      Assert.Equal(dayOfBirth, personInfo.DayOfBirth);
      Assert.Equal(dayOfBirth, (new PersonInfo(dayOfBirth: dayOfBirth)).DayOfBirth);
    }

    [Fact]
    public void MonthOfBirthTest()
    {
      int monthOfBirth = 3;
      personInfo.MonthOfBirth = monthOfBirth;

      Assert.Equal(monthOfBirth, personInfo.MonthOfBirth);
      Assert.Equal(monthOfBirth, (new PersonInfo(monthOfBirth: monthOfBirth)).MonthOfBirth);
    }

    [Fact]
    public void YearOfBirthTest()
    {
      int yearOfBirth = 1990;
      personInfo.YearOfBirth = yearOfBirth;

      Assert.Equal(yearOfBirth, personInfo.YearOfBirth);
      Assert.Equal(yearOfBirth, (new PersonInfo(yearOfBirth: yearOfBirth)).YearOfBirth);
    }

    [Fact]
    public void MinimumAgeTest()
    {
      int minimumAge = 18;
      personInfo.MinimumAge = minimumAge;

      Assert.Equal(minimumAge, personInfo.MinimumAge);
      Assert.Equal(minimumAge, (new PersonInfo(minimumAge: minimumAge)).MinimumAge);
    }

    [Fact]
    public void GenderTest()
    {
      string gender = "test-gender";
      personInfo.Gender = gender;

      Assert.Equal(gender, personInfo.Gender);
      Assert.Equal(gender, (new PersonInfo(gender: gender)).Gender);
    }

    [Fact]
    public void AdditionalFieldsTest()
    {
      PersonInfoAdditionalFields additionalFields = new PersonInfoAdditionalFields(fullName: "test-fullName");
      personInfo.AdditionalFields = additionalFields;

      Assert.Equal(additionalFields, personInfo.AdditionalFields);
      Assert.Equal(additionalFields, (new PersonInfo(additionalFields: additionalFields)).AdditionalFields);
    }

    [Fact]
    public void EqualsTest()
    {
      string firstGivenName = "test-firstGivenName";
      PersonInfo firstGivenName1 = new PersonInfo(firstGivenName: firstGivenName);

      Assert.Equal(firstGivenName1, firstGivenName1);
      Assert.Equal(firstGivenName1, new PersonInfo(firstGivenName: firstGivenName));
      Assert.NotEqual(firstGivenName1, new PersonInfo(firstGivenName: firstGivenName + "1"));
      Assert.False(firstGivenName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string firstGivenName = "test-firstGivenName";
      PersonInfo personInfo = new PersonInfo(firstGivenName: firstGivenName);
      object obj = new PersonInfo(firstGivenName: firstGivenName);

      Assert.True(personInfo.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      PersonInfo personInfo1 = new PersonInfo();
      personInfo1.FirstGivenName = "test-firstGivenName";
      personInfo1.MiddleName = "test-middleName";
      personInfo1.FirstSurName = "test-firstSurName";
      personInfo1.SecondSurname = "test-secondSurname";
      personInfo1.ISOLatin1Name = "test-iSOLatin1Name";
      personInfo1.DayOfBirth = 15;
      personInfo1.MonthOfBirth = 3;
      personInfo1.YearOfBirth = 1994;
      personInfo1.MinimumAge = 18;
      personInfo1.Gender = "test-gender";
      personInfo1.AdditionalFields = new PersonInfoAdditionalFields(fullName: "test-fullName");

      PersonInfo personInfo2 = new PersonInfo();
      personInfo2.FirstGivenName = "test-firstGivenName";
      personInfo2.MiddleName = "test-middleName";
      personInfo2.FirstSurName = "test-firstSurName";
      personInfo2.SecondSurname = "test-secondSurname";
      personInfo2.ISOLatin1Name = "test-iSOLatin1Name";
      personInfo2.DayOfBirth = 15;
      personInfo2.MonthOfBirth = 3;
      personInfo2.YearOfBirth = 1994;
      personInfo2.MinimumAge = 18;
      personInfo2.Gender = "test-gender";
      personInfo2.AdditionalFields = new PersonInfoAdditionalFields(fullName: "test-fullName");

      Assert.Equal(personInfo1.GetHashCode(), personInfo2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string firstGivenName = "test-firstGivenName";

      Assert.Equal(new PersonInfo(firstGivenName: firstGivenName).ToString(), new PersonInfo(firstGivenName: firstGivenName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string firstGivenName = "test-firstGivenName";

      Assert.Equal(new PersonInfo(firstGivenName: firstGivenName).ToJson(), new PersonInfo(firstGivenName: firstGivenName).ToJson());
    }
  }
}