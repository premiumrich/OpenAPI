using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class AppendedFieldTests
  {
    private AppendedField appendedField;

    public AppendedFieldTests()
    {
      appendedField = new AppendedField();
    }

    [Fact]
    public void FieldNameTest()
    {
      string fieldName = "field";
      appendedField.FieldName = fieldName;

      Assert.Equal(fieldName, appendedField.FieldName);
      Assert.Equal(fieldName, (new AppendedField(fieldName: fieldName)).FieldName);
    }

    [Fact]
    public void DataTest()
    {
      Object data = new Object();
      appendedField.Data = data;

      Assert.Equal(data, appendedField.Data);
      Assert.Equal(data, (new AppendedField(data: data)).Data);
    }

    [Fact]
    public void EqualsTest()
    {
      string fieldName = "field";
      AppendedField fieldName1 = new AppendedField(fieldName: fieldName);

      Assert.Equal(fieldName1, fieldName1);
      Assert.Equal(fieldName1, new AppendedField(fieldName: fieldName));
      Assert.NotEqual(fieldName1, new AppendedField(fieldName: fieldName + "1"));
      Assert.False(fieldName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string fieldName = "test-fieldName";
      AppendedField appendedField = new AppendedField(fieldName: fieldName);
      object obj = new AppendedField(fieldName: fieldName);

      Assert.True(appendedField.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      AppendedField appendedField1 = new AppendedField();
      appendedField1.FieldName = "test-fieldName";
      appendedField1.Data = new { testKey = "testValue"};

      AppendedField appendedField2 = new AppendedField();
      appendedField2.FieldName = "test-fieldName";
      appendedField2.Data = new { testKey = "testValue"};

      Assert.Equal(appendedField1.GetHashCode(), appendedField2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string fieldName = "test-fieldName";

      Assert.Equal(new AppendedField(fieldName: fieldName).ToString(), new AppendedField(fieldName: fieldName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string fieldName = "test-fieldName";
      Assert.Equal(new AppendedField(fieldName: fieldName).ToJson(), new AppendedField(fieldName: fieldName).ToJson());
    }
  }
}