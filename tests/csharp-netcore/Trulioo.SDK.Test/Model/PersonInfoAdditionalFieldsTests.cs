using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class PersonInfoAdditionalFieldsTests
  {
    private PersonInfoAdditionalFields personInfoAdditionalFields;

    public PersonInfoAdditionalFieldsTests()
    {
      personInfoAdditionalFields = new PersonInfoAdditionalFields();
    }

    [Fact]
    public void FullNameTest()
    {
      string fullName = "test-fullName";
      personInfoAdditionalFields.FullName = fullName;

      Assert.Equal(fullName, personInfoAdditionalFields.FullName);
      Assert.Equal(fullName, (new PersonInfoAdditionalFields(fullName: fullName)).FullName);
    }

    [Fact]
    public void EqualsTest()
    {
      string fullName = "test-fullName";
      PersonInfoAdditionalFields fullName1 = new PersonInfoAdditionalFields(fullName: fullName);

      Assert.Equal(fullName1, fullName1);
      Assert.Equal(fullName1, new PersonInfoAdditionalFields(fullName: fullName));
      Assert.NotEqual(fullName1, new PersonInfoAdditionalFields(fullName: fullName + "1"));
      Assert.False(fullName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string fullName = "test-fullName";
      PersonInfoAdditionalFields personInfoAdditionalFields = new PersonInfoAdditionalFields(fullName: fullName);
      object obj = new PersonInfoAdditionalFields(fullName: fullName);

      Assert.True(personInfoAdditionalFields.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      PersonInfoAdditionalFields personInfoAdditionalFields1 = new PersonInfoAdditionalFields();
      personInfoAdditionalFields1.FullName = "test-fullName";

      PersonInfoAdditionalFields personInfoAdditionalFields2 = new PersonInfoAdditionalFields();
      personInfoAdditionalFields2.FullName = "test-fullName";

      Assert.Equal(personInfoAdditionalFields1.GetHashCode(), personInfoAdditionalFields2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string fullName = "test-fullName";

      Assert.Equal(new PersonInfoAdditionalFields(fullName: fullName).ToString(), new PersonInfoAdditionalFields(fullName: fullName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string fullName = "test-fullName";

      Assert.Equal(new PersonInfoAdditionalFields(fullName: fullName).ToJson(), new PersonInfoAdditionalFields(fullName: fullName).ToJson());
    }
  }
}