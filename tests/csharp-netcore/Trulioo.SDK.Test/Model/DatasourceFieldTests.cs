using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class DatasourceFieldTests
  {
    private DatasourceField datasourceField;

    public DatasourceFieldTests()
    {
      datasourceField = new DatasourceField();
    }

    [Fact]
    public void FieldNameTest()
    {
      string fieldName = "test-fieldName";
      datasourceField.FieldName = fieldName;

      Assert.Equal(fieldName, datasourceField.FieldName);
      Assert.Equal(fieldName, (new DatasourceField(fieldName: fieldName)).FieldName);
    }

    [Fact]
    public void StatusTest()
    {
      string status = "test-status";
      datasourceField.Status = status;

      Assert.Equal(status, datasourceField.Status);
      Assert.Equal(status, (new DatasourceField(status: status)).Status);
    }

    [Fact]
    public void FieldGroupTest()
    {
      string fieldGroup = "test-fieldGroup";
      datasourceField.FieldGroup = fieldGroup;

      Assert.Equal(fieldGroup, datasourceField.FieldGroup);
      Assert.Equal(fieldGroup, (new DatasourceField(fieldGroup: fieldGroup)).FieldGroup);
    }

    [Fact]
    public void MatchPrecisionTest()
    {
      string matchPrecision = "test-matchPrecision";
      datasourceField.MatchPrecision = matchPrecision;

      Assert.Equal(matchPrecision, datasourceField.MatchPrecision);
      Assert.Equal(matchPrecision, (new DatasourceField(matchPrecision: matchPrecision)).MatchPrecision);
    }

    [Fact]
    public void EqualsTest()
    {
      string fieldName = "test-fieldName";
      DatasourceField fieldName1 = new DatasourceField(fieldName: fieldName);

      Assert.Equal(fieldName1, fieldName1);
      Assert.Equal(fieldName1, new DatasourceField(fieldName: fieldName));
      Assert.NotEqual(fieldName1, new DatasourceField(fieldName: fieldName + "1"));
      Assert.False(fieldName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string fieldName = "test-fieldName";
      DatasourceField datasourceField = new DatasourceField(fieldName: fieldName);
      object obj = new DatasourceField(fieldName: fieldName);

      Assert.True(datasourceField.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      DatasourceField datasourceField1 = new DatasourceField();
      datasourceField1.FieldName = "test-fieldName";
      datasourceField1.Status = "test-status";
      datasourceField1.FieldGroup = "test-fieldGroup";
      datasourceField1.MatchPrecision = "test-matchPrecision";

      DatasourceField datasourceField2 = new DatasourceField();
      datasourceField2.FieldName = "test-fieldName";
      datasourceField2.Status = "test-status";
      datasourceField2.FieldGroup = "test-fieldGroup";
      datasourceField2.MatchPrecision = "test-matchPrecision";

      Assert.Equal(datasourceField1.GetHashCode(), datasourceField2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string fieldName = "test-fieldName";

      Assert.Equal(new DatasourceField(fieldName: fieldName).ToString(), new DatasourceField(fieldName: fieldName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string fieldName = "test-fieldName";

      Assert.Equal(new DatasourceField(fieldName: fieldName).ToJson(), new DatasourceField(fieldName: fieldName).ToJson());
    }
  }
}