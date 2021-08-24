using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class VerifyResultTests
  {
    private VerifyResult verifyResult;

    public VerifyResultTests()
    {
      verifyResult = new VerifyResult();
    }

    [Fact]
    public void TransactionIDTest()
    {
      string transactionID = "test-transactionID";
      verifyResult.TransactionID = transactionID;

      Assert.Equal(transactionID, verifyResult.TransactionID);
      Assert.Equal(transactionID, (new VerifyResult(transactionID: transactionID)).TransactionID);
    }

    [Fact]
    public void UploadedDtTest()
    {
      DateTime uploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      verifyResult.UploadedDt = uploadedDt;

      Assert.Equal(uploadedDt, verifyResult.UploadedDt);
      Assert.Equal(uploadedDt, (new VerifyResult(uploadedDt: uploadedDt)).UploadedDt);
    }

    [Fact]
    public void CountryCodeTest()
    {
      string countryCode = "test-countryCode";
      verifyResult.CountryCode = countryCode;

      Assert.Equal(countryCode, verifyResult.CountryCode);
      Assert.Equal(countryCode, (new VerifyResult(countryCode: countryCode)).CountryCode);
    }

    [Fact]
    public void ProductNameTest()
    {
      string productName = "test-productName";
      verifyResult.ProductName = productName;

      Assert.Equal(productName, verifyResult.ProductName);
      Assert.Equal(productName, (new VerifyResult(productName: productName)).ProductName);
    }

    [Fact]
    public void RecordTest()
    {
      Trulioo.SDK.Model.Record record = new Trulioo.SDK.Model.Record(transactionRecordID: "test-transactionRecordID");
      verifyResult.Record = record;

      Assert.Equal(record, verifyResult.Record);
      Assert.Equal(record, (new VerifyResult(record: record)).Record);
    }

    [Fact]
    public void CustomerReferenceIDTest()
    {
      string customerReferenceID = "test-customerReferenceID";
      verifyResult.CustomerReferenceID = customerReferenceID;

      Assert.Equal(customerReferenceID, verifyResult.CustomerReferenceID);
      Assert.Equal(customerReferenceID, (new VerifyResult(customerReferenceID: customerReferenceID)).CustomerReferenceID);
    }

    [Fact]
    public void ErrorsTest()
    {
      List<ServiceError> errors = new List<ServiceError> { new ServiceError(message: "test-message") };
      verifyResult.Errors = errors;

      Assert.Equal(errors, verifyResult.Errors);
      Assert.Equal(errors, (new VerifyResult(errors: errors)).Errors);
    }

    [Fact]
    public void EqualsTest()
    {
      string transactionID = "test-transactionID";
      VerifyResult transactionID1 = new VerifyResult(transactionID: transactionID);

      Assert.Equal(transactionID1, transactionID1);
      Assert.Equal(transactionID1, new VerifyResult(transactionID: transactionID));
      Assert.NotEqual(transactionID1, new VerifyResult(transactionID: transactionID + "1"));
      Assert.False(transactionID1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string transactionID = "test-transactionID";
      VerifyResult verifyResult = new VerifyResult(transactionID: transactionID);
      object obj = new VerifyResult(transactionID: transactionID);

      Assert.True(verifyResult.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<ServiceError> errors = new List<ServiceError>();
      VerifyResult verifyResult1 = new VerifyResult();
      verifyResult1.TransactionID = "test-transactionID";
      verifyResult1.UploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      verifyResult1.CountryCode = "test-countryCode";
      verifyResult1.ProductName = "test-productName";
      verifyResult1.CustomerReferenceID = "test-customerReferenceID";
      verifyResult1.Record = new Trulioo.SDK.Model.Record(transactionRecordID: "test-transactionRecordID");
      verifyResult1.Errors = errors;

      VerifyResult verifyResult2 = new VerifyResult();
      verifyResult2.TransactionID = "test-transactionID";
      verifyResult2.UploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      verifyResult2.CountryCode = "test-countryCode";
      verifyResult2.ProductName = "test-productName";
      verifyResult2.CustomerReferenceID = "test-customerReferenceID";
      verifyResult2.Record = new Trulioo.SDK.Model.Record(transactionRecordID: "test-transactionRecordID");
      verifyResult2.Errors = errors;

      Assert.Equal(verifyResult1.GetHashCode(), verifyResult2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string transactionID = "test-transactionID";

      Assert.Equal(new VerifyResult(transactionID: transactionID).ToString(), new VerifyResult(transactionID: transactionID).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string transactionID = "test-transactionID";

      Assert.Equal(new VerifyResult(transactionID: transactionID).ToJson(), new VerifyResult(transactionID: transactionID).ToJson());
    }
  }
}