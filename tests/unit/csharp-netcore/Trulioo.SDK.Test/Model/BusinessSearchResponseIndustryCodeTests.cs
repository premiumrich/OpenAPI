using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessSearchResponseIndustryCodeTests
  {
    private BusinessSearchResponseIndustryCode businessSearchResponseIndustryCode;

    public BusinessSearchResponseIndustryCodeTests()
    {
      businessSearchResponseIndustryCode = new BusinessSearchResponseIndustryCode();
    }

    [Fact]
    public void CodeTest()
    {
      string code = "test-code";
      businessSearchResponseIndustryCode.Code = code;

      Assert.Equal(code, businessSearchResponseIndustryCode.Code);
      Assert.Equal(code, (new BusinessSearchResponseIndustryCode(code: code)).Code);
    }

    [Fact]
    public void DescriptionTest()
    {
      string description = "test-description";
      businessSearchResponseIndustryCode.Description = description;

      Assert.Equal(description, businessSearchResponseIndustryCode.Description);
      Assert.Equal(description, (new BusinessSearchResponseIndustryCode(description: description)).Description);
    }

    [Fact]
    public void EqualsTest()
    {
      string code = "test-code";
      BusinessSearchResponseIndustryCode code1 = new BusinessSearchResponseIndustryCode(code: code);

      Assert.Equal(code1, code1);
      Assert.Equal(code1, new BusinessSearchResponseIndustryCode(code: code));
      Assert.NotEqual(code1, new BusinessSearchResponseIndustryCode(code: code + "1"));
      Assert.False(code1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string code = "test-code";
      BusinessSearchResponseIndustryCode businessSearchResponseIndustryCode = new BusinessSearchResponseIndustryCode(code: code);
      object obj = new BusinessSearchResponseIndustryCode(code: code);

      Assert.True(businessSearchResponseIndustryCode.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      BusinessSearchResponseIndustryCode businessSearchResponseIndustryCode1 = new BusinessSearchResponseIndustryCode();
      businessSearchResponseIndustryCode1.Code = "test-code";
      businessSearchResponseIndustryCode1.Description = "test-description";

      BusinessSearchResponseIndustryCode businessSearchResponseIndustryCode2 = new BusinessSearchResponseIndustryCode();
      businessSearchResponseIndustryCode2.Code = "test-code";
      businessSearchResponseIndustryCode2.Description = "test-description";

      Assert.Equal(businessSearchResponseIndustryCode1.GetHashCode(), businessSearchResponseIndustryCode2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string code = "test-code";

      Assert.Equal(new BusinessSearchResponseIndustryCode(code: code).ToString(), new BusinessSearchResponseIndustryCode(code: code).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string code = "test-code";

      Assert.Equal(new BusinessSearchResponseIndustryCode(code: code).ToJson(), new BusinessSearchResponseIndustryCode(code: code).ToJson());
    }
  }
}