using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class TransactionRecordResultAllOfTests
  {
    private TransactionRecordResultAllOf transactionRecordResultAllOf;

    public TransactionRecordResultAllOfTests()
    {
      transactionRecordResultAllOf = new TransactionRecordResultAllOf();
    }

    [Fact]
    public void InputFieldsTest()
    {
      List<DataField> inputFields = new List<DataField> { new DataField(fieldName: "test-fieldName") };
      transactionRecordResultAllOf.InputFields = inputFields;

      Assert.Equal(inputFields, transactionRecordResultAllOf.InputFields);
      Assert.Equal(inputFields, (new TransactionRecordResultAllOf(inputFields: inputFields)).InputFields);
    }

    [Fact]
    public void EqualsTest()
    {
      List<DataField> inputFields = new List<DataField> { new DataField(fieldName: "test-fieldName") };
      TransactionRecordResultAllOf inputFields1 = new TransactionRecordResultAllOf(inputFields: inputFields);

      Assert.Equal(inputFields1, inputFields1);
      Assert.Equal(inputFields1, new TransactionRecordResultAllOf(inputFields: inputFields));
      Assert.NotEqual(inputFields1, new TransactionRecordResultAllOf(inputFields: new List<DataField> { new DataField(fieldName: "test-fieldName1") }));
      Assert.False(inputFields1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      List<DataField> inputFields = new List<DataField> { new DataField(fieldName: "test-fieldName") };
      TransactionRecordResultAllOf transactionRecordResultAllOf = new TransactionRecordResultAllOf(inputFields: inputFields);
      object obj = new TransactionRecordResultAllOf(inputFields: inputFields);

      Assert.True(transactionRecordResultAllOf.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<DataField> inputFields = new List<DataField>();

      TransactionRecordResultAllOf transactionRecordResultAllOf1 = new TransactionRecordResultAllOf();
      transactionRecordResultAllOf1.InputFields = inputFields;

      TransactionRecordResultAllOf transactionRecordResultAllOf2 = new TransactionRecordResultAllOf();
      transactionRecordResultAllOf2.InputFields = inputFields;

      Assert.Equal(transactionRecordResultAllOf1.GetHashCode(), transactionRecordResultAllOf2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      List<DataField> inputFields = new List<DataField> { new DataField(fieldName: "test-fieldName") };

      Assert.Equal(new TransactionRecordResultAllOf(inputFields: inputFields).ToString(), new TransactionRecordResultAllOf(inputFields: inputFields).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      List<DataField> inputFields = new List<DataField> { new DataField(fieldName: "test-fieldName") };

      Assert.Equal(new TransactionRecordResultAllOf(inputFields: inputFields).ToJson(), new TransactionRecordResultAllOf(inputFields: inputFields).ToJson());
    }
  }
}