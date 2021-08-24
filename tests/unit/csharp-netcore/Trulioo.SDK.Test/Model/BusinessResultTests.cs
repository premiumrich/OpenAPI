using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessResultTests
  {
    private BusinessResult businessResult;

    public BusinessResultTests()
    {
      businessResult = new BusinessResult();
    }

    [Fact]
    public void ResultsTest()
    {
      List<Result> results = new List<Result> { new Result(businessName: "test-businessName") };
      businessResult.Results = results;

      Assert.Equal(results, businessResult.Results);
      Assert.Equal(results, (new BusinessResult(results: results)).Results);
    }

    [Fact]
    public void DatasourceNameTest()
    {
      string datasourceName = "test-datasourceName";
      businessResult.DatasourceName = datasourceName;

      Assert.Equal(datasourceName, businessResult.DatasourceName);
      Assert.Equal(datasourceName, (new BusinessResult(datasourceName: datasourceName)).DatasourceName);
    }

    [Fact]
    public void ErrorsTest()
    {
      Assert.Null(businessResult.Errors);
    }

    [Fact]
    public void EqualsTest()
    {
      string datasourceName = "test-datasourceName";
      BusinessResult results1 = new BusinessResult(datasourceName: datasourceName);

      Assert.Equal(results1, results1);
      Assert.Equal(results1, new BusinessResult(datasourceName: datasourceName));
      Assert.NotEqual(results1, new BusinessResult(datasourceName: datasourceName + "1"));
      Assert.False(results1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string datasourceName = "test-datasourceName";
      BusinessResult businessResult = new BusinessResult(datasourceName: datasourceName);
      object obj = new BusinessResult(datasourceName: datasourceName);

      Assert.True(businessResult.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      BusinessResult businessResult1 = new BusinessResult();
      businessResult1.DatasourceName = "test-datasourceName";

      BusinessResult businessResult2 = new BusinessResult();
      businessResult2.DatasourceName = "test-datasourceName";

      Assert.Equal(businessResult1.GetHashCode(), businessResult2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string datasourceName = "test-datasourceName";

      Assert.Equal(new BusinessResult(datasourceName: datasourceName).ToString(), new BusinessResult(datasourceName: datasourceName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string datasourceName = "test-datasourceName";

      Assert.Equal(new BusinessResult(datasourceName: datasourceName).ToJson(), new BusinessResult(datasourceName: datasourceName).ToJson());
    }
  }
}