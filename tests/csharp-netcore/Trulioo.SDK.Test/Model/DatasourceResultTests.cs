using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class DatasourceResultTests
  {
    private DatasourceResult datasourceResult;

    public DatasourceResultTests()
    {
      datasourceResult = new DatasourceResult();
    }

    [Fact]
    public void DatasourceStatusTest()
    {
      string datasourceStatus = "test-datasourceStatus";
      datasourceResult.DatasourceStatus = datasourceStatus;

      Assert.Equal(datasourceStatus, datasourceResult.DatasourceStatus);
      Assert.Equal(datasourceStatus, (new DatasourceResult(datasourceStatus: datasourceStatus)).DatasourceStatus);
    }

    [Fact]
    public void DatasourceNameTest()
    {
      string datasourceName = "test-datasourceName";
      datasourceResult.DatasourceName = datasourceName;

      Assert.Equal(datasourceName, datasourceResult.DatasourceName);
      Assert.Equal(datasourceName, (new DatasourceResult(datasourceName: datasourceName)).DatasourceName);
    }

    [Fact]
    public void DatasourceFieldsTest()
    {
      List<DatasourceField> datasourceFields = new List<DatasourceField> { new DatasourceField(fieldName: "test-fieldName") };
      datasourceResult.DatasourceFields = datasourceFields;

      Assert.Equal(datasourceFields, datasourceResult.DatasourceFields);
      Assert.Equal(datasourceFields, (new DatasourceResult(datasourceFields: datasourceFields)).DatasourceFields);
    }

    [Fact]
    public void AppendedFieldsTest()
    {
      List<AppendedField> appendedFields = new List<AppendedField> { new AppendedField(fieldName: "test-fieldName") };
      datasourceResult.AppendedFields = appendedFields;

      Assert.Equal(appendedFields, datasourceResult.AppendedFields);
      Assert.Equal(appendedFields, (new DatasourceResult(appendedFields: appendedFields)).AppendedFields);
    }

    [Fact]
    public void ErrorsTest()
    {
      List<ServiceError> errors = new List<ServiceError> { new ServiceError(message: "test-message") };
      datasourceResult.Errors = errors;

      Assert.Equal(errors, datasourceResult.Errors);
      Assert.Equal(errors, (new DatasourceResult(errors: errors)).Errors);
    }

    [Fact]
    public void FieldGroupsTest()
    {
      List<string> fieldGroups = new List<string> { "test-fieldGroups" };
      datasourceResult.FieldGroups = fieldGroups;

      Assert.Equal(fieldGroups, datasourceResult.FieldGroups);
      Assert.Equal(fieldGroups, (new DatasourceResult(fieldGroups: fieldGroups)).FieldGroups);
    }

    [Fact]
    public void EqualsTest()
    {
      string datasourceStatus = "test-datasourceStatus";
      DatasourceResult datasourceStatus1 = new DatasourceResult(datasourceStatus: datasourceStatus);

      Assert.Equal(datasourceStatus1, datasourceStatus1);
      Assert.Equal(datasourceStatus1, new DatasourceResult(datasourceStatus: datasourceStatus));
      Assert.NotEqual(datasourceStatus1, new DatasourceResult(datasourceStatus: datasourceStatus + "1"));
      Assert.False(datasourceStatus1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string datasourceStatus = "test-datasourceStatus";
      DatasourceResult datasourceResult = new DatasourceResult(datasourceStatus: datasourceStatus);
      object obj = new DatasourceResult(datasourceStatus: datasourceStatus);

      Assert.True(datasourceResult.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<DatasourceField> datasourceFields = new List<DatasourceField> { new DatasourceField(fieldName: "test-fieldName") };
      List<AppendedField> appendedFields = new List<AppendedField> { new AppendedField(fieldName: "test-fieldName") };
      List<ServiceError> errors = new List<ServiceError> { new ServiceError(message: "test-message") };
      List<string> fieldGroups = new List<string> { "test-fieldGroups" };

      DatasourceResult datasourceResult1 = new DatasourceResult();
      datasourceResult1.DatasourceStatus = "test-datasourceStatus";
      datasourceResult1.DatasourceName = "test-datasourceName";
      datasourceResult1.DatasourceFields = datasourceFields;
      datasourceResult1.AppendedFields = appendedFields;
      datasourceResult1.Errors = errors;
      datasourceResult1.FieldGroups = fieldGroups;

      DatasourceResult datasourceResult2 = new DatasourceResult();
      datasourceResult2.DatasourceStatus = "test-datasourceStatus";
      datasourceResult2.DatasourceName = "test-datasourceName";
      datasourceResult2.DatasourceFields = datasourceFields;
      datasourceResult2.AppendedFields = appendedFields;
      datasourceResult2.Errors = errors;
      datasourceResult2.FieldGroups = fieldGroups;

      Assert.Equal(datasourceResult1.GetHashCode(), datasourceResult2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string datasourceStatus = "test-datasourceStatus";

      Assert.Equal(new DatasourceResult(datasourceStatus: datasourceStatus).ToString(), new DatasourceResult(datasourceStatus: datasourceStatus).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string datasourceStatus = "test-datasourceStatus";

      Assert.Equal(new DatasourceResult(datasourceStatus: datasourceStatus).ToJson(), new DatasourceResult(datasourceStatus: datasourceStatus).ToJson());
    }
  }
}