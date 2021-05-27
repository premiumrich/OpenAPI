using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class ConsentTests
  {
    private Consent consent;

    public ConsentTests()
    {
      consent = new Consent();
    }

    [Fact]
    public void NameTest()
    {
      string name = "test-name";
      consent.Name = name;

      Assert.Equal(name, consent.Name);
      Assert.Equal(name, (new Consent(name: name)).Name);
    }

    [Fact]
    public void TextTest()
    {
      string text = "test-text";
      consent.Text = text;

      Assert.Equal(text, consent.Text);
      Assert.Equal(text, (new Consent(text: text)).Text);
    }

    [Fact]
    public void UrlTest()
    {
      string url = "test-url";
      consent.Url = url;

      Assert.Equal(url, consent.Url);
      Assert.Equal(url, (new Consent(url: url)).Url);
    }

    [Fact]
    public void EqualsTest()
    {
      string name = "test-name";
      Consent name1 = new Consent(name: name);

      Assert.Equal(name1, name1);
      Assert.Equal(name1, new Consent(name: name));
      Assert.NotEqual(name1, new Consent(name: name + "1"));
      Assert.False(name1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string name = "test-name";
      Consent consent = new Consent(name: name);
      object obj = new Consent(name: name);

      Assert.True(consent.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      Consent consent1 = new Consent();
      consent1.Name = "test-name";
      consent1.Text = "test-text";
      consent1.Url = "test-url";

      Consent consent2 = new Consent();
      consent2.Name = "test-name";
      consent2.Text = "test-text";
      consent2.Url = "test-url";

      Assert.Equal(consent1.GetHashCode(), consent2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string name = "test-name";

      Assert.Equal(new Consent(name: name).ToString(), new Consent(name: name).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string name = "test-name";

      Assert.Equal(new Consent(name: name).ToJson(), new Consent(name: name).ToJson());
    }
  }
}