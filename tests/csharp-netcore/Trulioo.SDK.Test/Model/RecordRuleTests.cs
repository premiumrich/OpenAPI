using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class RecordRuleTests
  {
    private RecordRule recordRule;

    public RecordRuleTests()
    {
      recordRule = new RecordRule();
    }

    [Fact]
    public void RuleNameTest()
    {
      string ruleName = "test-ruleName";
      recordRule.RuleName = ruleName;

      Assert.Equal(ruleName, recordRule.RuleName);
      Assert.Equal(ruleName, (new RecordRule(ruleName: ruleName)).RuleName);
    }

    [Fact]
    public void NoteTest()
    {
      string note = "test-note";
      recordRule.Note = note;

      Assert.Equal(note, recordRule.Note);
      Assert.Equal(note, (new RecordRule(note: note)).Note);
    }

    [Fact]
    public void EqualsTest()
    {
      string ruleName = "test-ruleName";
      RecordRule ruleName1 = new RecordRule(ruleName: ruleName);

      Assert.Equal(ruleName1, ruleName1);
      Assert.Equal(ruleName1, new RecordRule(ruleName: ruleName));
      Assert.NotEqual(ruleName1, new RecordRule(ruleName: ruleName + "1"));
      Assert.False(ruleName1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string ruleName = "test-ruleName";
      RecordRule recordRule = new RecordRule(ruleName: ruleName);
      object obj = new RecordRule(ruleName: ruleName);

      Assert.True(recordRule.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      RecordRule recordRule1 = new RecordRule();
      recordRule1.RuleName = "test-ruleName";
      recordRule1.Note = "test-note";

      RecordRule recordRule2 = new RecordRule();
      recordRule2.RuleName = "test-ruleName";
      recordRule2.Note = "test-note";

      Assert.Equal(recordRule1.GetHashCode(), recordRule2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string ruleName = "test-ruleName";

      Assert.Equal(new RecordRule(ruleName: ruleName).ToString(), new RecordRule(ruleName: ruleName).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string ruleName = "test-ruleName";

      Assert.Equal(new RecordRule(ruleName: ruleName).ToJson(), new RecordRule(ruleName: ruleName).ToJson());
    }
  }
}