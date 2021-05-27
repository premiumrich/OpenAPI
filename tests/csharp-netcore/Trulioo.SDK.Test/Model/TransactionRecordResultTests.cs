using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class TransactionRecordResultTests
  {
    private TransactionRecordResult transactionRecordResult;

    public TransactionRecordResultTests()
    {
      transactionRecordResult = new TransactionRecordResult();
    }

    [Fact]
    public void TransactionIDTest()
    {
      string transactionID = "test-transactionID";
      transactionRecordResult.TransactionID = transactionID;

      Assert.Equal(transactionID, transactionRecordResult.TransactionID);
      Assert.Equal(transactionID, (new TransactionRecordResult(transactionID: transactionID)).TransactionID);
    }

    [Fact]
    public void UploadedDtTest()
    {
      DateTime uploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      transactionRecordResult.UploadedDt = uploadedDt;

      Assert.Equal(uploadedDt, transactionRecordResult.UploadedDt);
      Assert.Equal(uploadedDt, (new TransactionRecordResult(uploadedDt: uploadedDt)).UploadedDt);
    }

    [Fact]
    public void CountryCodeTest()
    {
      string countryCode = "test-countryCode";
      transactionRecordResult.CountryCode = countryCode;

      Assert.Equal(countryCode, transactionRecordResult.CountryCode);
      Assert.Equal(countryCode, (new TransactionRecordResult(countryCode: countryCode)).CountryCode);
    }

    [Fact]
    public void ProductNameTest()
    {
      string productName = "test-productName";
      transactionRecordResult.ProductName = productName;

      Assert.Equal(productName, transactionRecordResult.ProductName);
      Assert.Equal(productName, (new TransactionRecordResult(productName: productName)).ProductName);
    }

    [Fact]
    public void RecordTest()
    {
      Trulioo.SDK.Model.Record record = new Trulioo.SDK.Model.Record(recordStatus: "test-recordStatus");
      transactionRecordResult.Record = record;

      Assert.Equal(record, transactionRecordResult.Record);
      Assert.Equal(record, (new TransactionRecordResult(record: record)).Record);
    }

    [Fact]
    public void CustomerReferenceIDTest()
    {
      string customerReferenceID = "test-customerReferenceID";
      transactionRecordResult.CustomerReferenceID = customerReferenceID;

      Assert.Equal(customerReferenceID, transactionRecordResult.CustomerReferenceID);
      Assert.Equal(customerReferenceID, (new TransactionRecordResult(customerReferenceID: customerReferenceID)).CustomerReferenceID);
    }

    [Fact]
    public void ErrorsTest()
    {
      List<ServiceError> errors = new List<ServiceError> { new ServiceError(message: "test-message") };
      transactionRecordResult.Errors = errors;

      Assert.Equal(errors, transactionRecordResult.Errors);
      Assert.Equal(errors, (new TransactionRecordResult(errors: errors)).Errors);
    }

    [Fact]
    public void InputFieldsTest()
    {
      List<DataField> inputFields = new List<DataField> { new DataField(fieldName: "test-fieldName") };
      transactionRecordResult.InputFields = inputFields;

      Assert.Equal(inputFields, transactionRecordResult.InputFields);
      Assert.Equal(inputFields, (new TransactionRecordResult(inputFields: inputFields)).InputFields);
    }

    [Fact]
    public void EqualsTest()
    {
      string transactionID = "test-transactionID";
      TransactionRecordResult transactionID1 = new TransactionRecordResult(transactionID: transactionID);

      Assert.Equal(transactionID1, transactionID1);
      Assert.Equal(transactionID1, new TransactionRecordResult(transactionID: transactionID));
      Assert.NotEqual(transactionID1, new TransactionRecordResult(transactionID: transactionID + "1"));
      Assert.False(transactionID1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string transactionID = "test-transactionID";
      TransactionRecordResult transactionRecordResult = new TransactionRecordResult(transactionID: transactionID);
      object obj = new TransactionRecordResult(transactionID: transactionID);

      Assert.True(transactionRecordResult.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      TransactionRecordResult transactionRecordResult1 = new TransactionRecordResult();
      transactionRecordResult1.TransactionID = "test-transactionID";
      transactionRecordResult1.UploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      transactionRecordResult1.CountryCode = "test-countryCode";
      transactionRecordResult1.ProductName = "test-productName";
      transactionRecordResult1.CustomerReferenceID = "test-customerReferenceID";

      TransactionRecordResult transactionRecordResult2 = new TransactionRecordResult();
      transactionRecordResult2.TransactionID = "test-transactionID";
      transactionRecordResult2.UploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      transactionRecordResult2.CountryCode = "test-countryCode";
      transactionRecordResult2.ProductName = "test-productName";
      transactionRecordResult2.CustomerReferenceID = "test-customerReferenceID";

      Assert.Equal(transactionRecordResult1.GetHashCode(), transactionRecordResult2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string transactionID = "test-transactionID";

      Assert.Equal(new TransactionRecordResult(transactionID: transactionID).ToString(), new TransactionRecordResult(transactionID: transactionID).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string transactionID = "test-transactionID";

      Assert.Equal(new TransactionRecordResult(transactionID: transactionID).ToJson(), new TransactionRecordResult(transactionID: transactionID).ToJson());
    }
  }
}