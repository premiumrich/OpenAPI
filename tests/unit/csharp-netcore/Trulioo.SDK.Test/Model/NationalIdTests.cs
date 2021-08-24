using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class NationalIdTests
  {
    private NationalId nationalId;

    public NationalIdTests()
    {
      nationalId = new NationalId();
    }

    [Fact]
    public void NumberTest()
    {
      string number = "test-number";
      nationalId.Number = number;

      Assert.Equal(number, nationalId.Number);
      Assert.Equal(number, (new NationalId(number: number)).Number);
    }

    [Fact]
    public void TypeTest()
    {
      string type = "test-type";
      nationalId.Type = type;

      Assert.Equal(type, nationalId.Type);
      Assert.Equal(type, (new NationalId(type: type)).Type);
    }

    [Fact]
    public void DistrictOfIssueTest()
    {
      string districtOfIssue = "test-districtOfIssue";
      nationalId.DistrictOfIssue = districtOfIssue;

      Assert.Equal(districtOfIssue, nationalId.DistrictOfIssue);
      Assert.Equal(districtOfIssue, (new NationalId(districtOfIssue: districtOfIssue)).DistrictOfIssue);
    }

    [Fact]
    public void CityOfIssueTest()
    {
      string cityOfIssue = "test-cityOfIssue";
      nationalId.CityOfIssue = cityOfIssue;

      Assert.Equal(cityOfIssue, nationalId.CityOfIssue);
      Assert.Equal(cityOfIssue, (new NationalId(cityOfIssue: cityOfIssue)).CityOfIssue);
    }

    [Fact]
    public void ProvinceOfIssueTest()
    {
      string provinceOfIssue = "test-provinceOfIssue";
      nationalId.ProvinceOfIssue = provinceOfIssue;

      Assert.Equal(provinceOfIssue, nationalId.ProvinceOfIssue);
      Assert.Equal(provinceOfIssue, (new NationalId(provinceOfIssue: provinceOfIssue)).ProvinceOfIssue);
    }

    [Fact]
    public void CountyOfIssueTest()
    {
      string countyOfIssue = "test-countyOfIssue";
      nationalId.CountyOfIssue = countyOfIssue;

      Assert.Equal(countyOfIssue, nationalId.CountyOfIssue);
      Assert.Equal(countyOfIssue, (new NationalId(countyOfIssue: countyOfIssue)).CountyOfIssue);
    }

    [Fact]
    public void EqualsTest()
    {
      string number = "test-number";
      NationalId number1 = new NationalId(number: number);

      Assert.Equal(number1, number1);
      Assert.Equal(number1, new NationalId(number: number));
      Assert.NotEqual(number1, new NationalId(number: number + "1"));
      Assert.False(number1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string number = "test-number";
      NationalId nationalId = new NationalId(number: number);
      object obj = new NationalId(number: number);

      Assert.True(nationalId.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      NationalId nationalId1 = new NationalId();
      nationalId1.Number = "test-number";
      nationalId1.Type = "test-type";
      nationalId1.DistrictOfIssue = "test-districtOfIssue";
      nationalId1.CityOfIssue = "test-cityOfIssue";
      nationalId1.ProvinceOfIssue = "test-provinceOfIssue";
      nationalId1.CountyOfIssue = "test-countyOfIssue";

      NationalId nationalId2 = new NationalId();
      nationalId2.Number = "test-number";
      nationalId2.Type = "test-type";
      nationalId2.DistrictOfIssue = "test-districtOfIssue";
      nationalId2.CityOfIssue = "test-cityOfIssue";
      nationalId2.ProvinceOfIssue = "test-provinceOfIssue";
      nationalId2.CountyOfIssue = "test-countyOfIssue";

      Assert.Equal(nationalId1.GetHashCode(), nationalId2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string number = "test-number";

      Assert.Equal(new NationalId(number: number).ToString(), new NationalId(number: number).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string number = "test-number";

      Assert.Equal(new NationalId(number: number).ToJson(), new NationalId(number: number).ToJson());
    }
  }
}