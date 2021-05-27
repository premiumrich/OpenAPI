using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessRegistrationNumberMaskTests
  {
    private BusinessRegistrationNumberMask businessRegistrationNumberMask;

    public BusinessRegistrationNumberMaskTests()
    {
      businessRegistrationNumberMask = new BusinessRegistrationNumberMask();
    }

    [Fact]
    public void MaskTest()
    {
      string mask = "mask-value";
      businessRegistrationNumberMask.Mask = mask;

      Assert.Equal(mask, businessRegistrationNumberMask.Mask);
      Assert.Equal(mask, (new BusinessRegistrationNumberMask(mask: mask)).Mask);
    }

    [Fact]
    public void IgnoreWhitespaceTest()
    {
      bool ignoreWhitespace = true;
      businessRegistrationNumberMask.IgnoreWhitespace = ignoreWhitespace;

      Assert.Equal(ignoreWhitespace, businessRegistrationNumberMask.IgnoreWhitespace);
      Assert.Equal(ignoreWhitespace, (new BusinessRegistrationNumberMask(ignoreWhitespace: ignoreWhitespace)).IgnoreWhitespace);
    }

    [Fact]
    public void IgnoreSpecialCharacterTest()
    {
      bool ignoreSpecialCharacter = true;
      businessRegistrationNumberMask.IgnoreSpecialCharacter = ignoreSpecialCharacter;

      Assert.Equal(ignoreSpecialCharacter, businessRegistrationNumberMask.IgnoreSpecialCharacter);
      Assert.Equal(ignoreSpecialCharacter, (new BusinessRegistrationNumberMask(ignoreSpecialCharacter: ignoreSpecialCharacter)).IgnoreSpecialCharacter);
    }

    [Fact]
    public void EqualsTest()
    {
      string mask = "mask-value";
      BusinessRegistrationNumberMask mask1 = new BusinessRegistrationNumberMask(mask: mask);

      Assert.Equal(mask1, mask1);
      Assert.Equal(mask1, new BusinessRegistrationNumberMask(mask: mask));
      Assert.False(mask1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string mask = "test-mask";
      BusinessRegistrationNumberMask businessRegistrationNumberMask = new BusinessRegistrationNumberMask(mask: mask);
      object obj = new BusinessRegistrationNumberMask(mask: mask);

      Assert.True(businessRegistrationNumberMask.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      BusinessRegistrationNumberMask businessRegistrationNumberMask1 = new BusinessRegistrationNumberMask();
      businessRegistrationNumberMask1.Mask = "test-mask";
      businessRegistrationNumberMask1.IgnoreWhitespace = true;
      businessRegistrationNumberMask1.IgnoreSpecialCharacter = true;

      BusinessRegistrationNumberMask businessRegistrationNumberMask2 = new BusinessRegistrationNumberMask();
      businessRegistrationNumberMask2.Mask = "test-mask";
      businessRegistrationNumberMask2.IgnoreWhitespace = true;
      businessRegistrationNumberMask2.IgnoreSpecialCharacter = true;

      Assert.Equal(businessRegistrationNumberMask1.GetHashCode(), businessRegistrationNumberMask2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string mask = "test-mask";

      Assert.Equal(new BusinessRegistrationNumberMask(mask: mask).ToString(), new BusinessRegistrationNumberMask(mask: mask).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string mask = "test-mask";

      Assert.Equal(new BusinessRegistrationNumberMask(mask: mask).ToJson(), new BusinessRegistrationNumberMask(mask: mask).ToJson());
    }
  }
}