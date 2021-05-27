using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class NormalizedDatasourceFieldTests
  {
    private NormalizedDatasourceField normalizedDatasourceField;

    public NormalizedDatasourceFieldTests()
    {
      normalizedDatasourceField = new NormalizedDatasourceField();
    }

    [Fact]
    public void FieldNameTest()
    {
      string fieldName = "test-fieldName";
      normalizedDatasourceField.FieldName = fieldName;

      Assert.Equal(fieldName, normalizedDatasourceField.FieldName);
      Assert.Equal(fieldName, (new NormalizedDatasourceField(fieldName: fieldName)).FieldName);
    }

    [Fact]
    public void TypeTest()
    {
      string type = "test-type";
      normalizedDatasourceField.Type = type;

      Assert.Equal(type, normalizedDatasourceField.Type);
      Assert.Equal(type, (new NormalizedDatasourceField(type: type)).Type);
    }

    [Fact]
    public void EqualsTest()
    {
      string fieldName = "test-fieldName";
      NormalizedDatasourceField fieldName1 = new NormalizedDatasourceField(fieldName: fieldName);

      Assert.Equal(fieldName1, fieldName1);
      Assert.Equal(fieldName1, new NormalizedDatasourceField(fieldName: fieldName));
      Assert.NotEqual(fieldName1, new NormalizedDatasourceField(fieldName: fieldName + "1"));
      Assert.False(fieldName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string fieldName = "test-fieldName";
      NormalizedDatasourceField normalizedDatasourceField = new NormalizedDatasourceField(fieldName: fieldName);
      object obj = new NormalizedDatasourceField(fieldName: fieldName);

      Assert.True(normalizedDatasourceField.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      NormalizedDatasourceField normalizedDatasourceField1 = new NormalizedDatasourceField();
      normalizedDatasourceField1.FieldName = "test-fieldName";
      normalizedDatasourceField1.Type = "test-type";

      NormalizedDatasourceField normalizedDatasourceField2 = new NormalizedDatasourceField();
      normalizedDatasourceField2.FieldName = "test-fieldName";
      normalizedDatasourceField2.Type = "test-type";

      Assert.Equal(normalizedDatasourceField1.GetHashCode(), normalizedDatasourceField2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string fieldName = "test-fieldName";

      Assert.Equal(new NormalizedDatasourceField(fieldName: fieldName).ToString(), new NormalizedDatasourceField(fieldName: fieldName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string fieldName = "test-fieldName";

      Assert.Equal(new NormalizedDatasourceField(fieldName: fieldName).ToJson(), new NormalizedDatasourceField(fieldName: fieldName).ToJson());
    }
  }
}