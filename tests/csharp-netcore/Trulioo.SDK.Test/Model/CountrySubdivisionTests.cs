using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class CountrySubdivisionTests
  {
    private CountrySubdivision countrySubdivision;

    public CountrySubdivisionTests()
    {
      countrySubdivision = new CountrySubdivision();
    }

    [Fact]
    public void NameTest()
    {
      string name = "test-name";
      countrySubdivision.Name = name;

      Assert.Equal(name, countrySubdivision.Name);
      Assert.Equal(name, (new CountrySubdivision(name: name)).Name);
    }

    [Fact]
    public void CodeTest()
    {
      string code = "test-code";
      countrySubdivision.Code = code;

      Assert.Equal(code, countrySubdivision.Code);
      Assert.Equal(code, (new CountrySubdivision(code: code)).Code);
    }

    [Fact]
    public void ParentCodeTest()
    {
      string parentCode = "test-parentCode";
      countrySubdivision.ParentCode = parentCode;

      Assert.Equal(parentCode, countrySubdivision.ParentCode);
      Assert.Equal(parentCode, (new CountrySubdivision(parentCode: parentCode)).ParentCode);
    }

    [Fact]
    public void EqualsTest()
    {
      string name = "test-name";
      CountrySubdivision name1 = new CountrySubdivision(name: name);

      Assert.Equal(name1, name1);
      Assert.Equal(name1, new CountrySubdivision(name: name));
      Assert.NotEqual(name1, new CountrySubdivision(name: name + "1"));
      Assert.False(name1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string name = "test-name";
      CountrySubdivision countrySubdivision = new CountrySubdivision(name: name);
      object obj = new CountrySubdivision(name: name);

      Assert.True(countrySubdivision.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      CountrySubdivision countrySubdivision1 = new CountrySubdivision();
      countrySubdivision1.Name = "test-name";
      countrySubdivision1.Code = "test-code";
      countrySubdivision1.ParentCode = "test-parentCode";

      CountrySubdivision countrySubdivision2 = new CountrySubdivision();
      countrySubdivision2.Name = "test-name";
      countrySubdivision2.Code = "test-code";
      countrySubdivision2.ParentCode = "test-parentCode";

      Assert.Equal(countrySubdivision1.GetHashCode(), countrySubdivision2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string name = "test-name";

      Assert.Equal(new CountrySubdivision(name: name).ToString(), new CountrySubdivision(name: name).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string name = "test-name";

      Assert.Equal(new CountrySubdivision(name: name).ToJson(), new CountrySubdivision(name: name).ToJson());
    }
  }
}