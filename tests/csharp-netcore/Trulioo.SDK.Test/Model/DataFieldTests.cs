using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class DataFieldTests
  {
    private DataField dataField;

    public DataFieldTests()
    {
      dataField = new DataField();
    }

    [Fact]
    public void FieldNameTest()
    {
      string fieldName = "test-fieldName";
      dataField.FieldName = fieldName;

      Assert.Equal(fieldName, dataField.FieldName);
      Assert.Equal(fieldName, (new DataField(fieldName: fieldName)).FieldName);
    }

    [Fact]
    public void ValueTest()
    {
      string value = "test-value";
      dataField.Value = value;

      Assert.Equal(value, dataField.Value);
      Assert.Equal(value, (new DataField(value: value)).Value);
    }

    [Fact]
    public void FieldGroupTest()
    {
      string fieldGroup = "test-fieldGroup";
      dataField.FieldGroup = fieldGroup;

      Assert.Equal(fieldGroup, dataField.FieldGroup);
      Assert.Equal(fieldGroup, (new DataField(fieldGroup: fieldGroup)).FieldGroup);
    }

    [Fact]
    public void EqualsTest()
    {
      string fieldName = "test-fieldName";
      DataField fieldName1 = new DataField(fieldName: fieldName);

      Assert.Equal(fieldName1, fieldName1);
      Assert.Equal(fieldName1, new DataField(fieldName: fieldName));
      Assert.NotEqual(fieldName1, new DataField(fieldName: fieldName + "1"));
      Assert.False(fieldName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string fieldName = "test-fieldName";
      DataField dataField = new DataField(fieldName: fieldName);
      object obj = new DataField(fieldName: fieldName);

      Assert.True(dataField.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      DataField dataField1 = new DataField();
      dataField1.FieldName = "test-fieldName";
      dataField1.Value = "test-value";
      dataField1.FieldGroup = "test-fieldGroup";

      DataField dataField2 = new DataField();
      dataField2.FieldName = "test-fieldName";
      dataField2.Value = "test-value";
      dataField2.FieldGroup = "test-fieldGroup";

      Assert.Equal(dataField1.GetHashCode(), dataField2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string fieldName = "test-fieldName";

      Assert.Equal(new DataField(fieldName: fieldName).ToString(), new DataField(fieldName: fieldName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string fieldName = "test-fieldName";

      Assert.Equal(new DataField(fieldName: fieldName).ToJson(), new DataField(fieldName: fieldName).ToJson());
    }
  }
}