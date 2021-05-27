using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessSearchResponseTests
  {
    private BusinessSearchResponse businessSearchResponse;

    public BusinessSearchResponseTests()
    {
      businessSearchResponse = new BusinessSearchResponse();
    }

    [Fact]
    public void TransactionIDTest()
    {
      string transactionID = "test-transactionID";
      businessSearchResponse.TransactionID = transactionID;

      Assert.Equal(transactionID, businessSearchResponse.TransactionID);
      Assert.Equal(transactionID, (new BusinessSearchResponse(transactionID: transactionID)).TransactionID);
    }

    [Fact]
    public void UploadedDtTest()
    {
      DateTime uploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      businessSearchResponse.UploadedDt = uploadedDt;

      Assert.Equal(uploadedDt, businessSearchResponse.UploadedDt);
      Assert.Equal(uploadedDt, (new BusinessSearchResponse(uploadedDt: uploadedDt)).UploadedDt);
    }

    [Fact]
    public void CountryCodeTest()
    {
      string countryCode = "test-countryCode";
      businessSearchResponse.CountryCode = countryCode;

      Assert.Equal(countryCode, businessSearchResponse.CountryCode);
      Assert.Equal(countryCode, (new BusinessSearchResponse(countryCode: countryCode)).CountryCode);
    }

    [Fact]
    public void ProductNameTest()
    {
      string productName = "test-productName";
      businessSearchResponse.ProductName = productName;

      Assert.Equal(productName, businessSearchResponse.ProductName);
      Assert.Equal(productName, (new BusinessSearchResponse(productName: productName)).ProductName);
    }

    [Fact]
    public void RecordTest()
    {
      BusinessRecord record = new BusinessRecord(transactionRecordID: "test-transactionRecordID");
      businessSearchResponse.Record = record;

      Assert.Equal(record, businessSearchResponse.Record);
      Assert.Equal(record, (new BusinessSearchResponse(record: record)).Record);
    }

    [Fact]
    public void ErrorsTest()
    {
      List<ServiceError> errors = new List<ServiceError> { new ServiceError(message: "test-message") };
      businessSearchResponse.Errors = errors;

      Assert.Equal(errors, businessSearchResponse.Errors);
      Assert.Equal(errors, (new BusinessSearchResponse(errors: errors)).Errors);
    }

    [Fact]
    public void EqualsTest()
    {
      string transactionID = "test-transactionID";
      BusinessSearchResponse transactionID1 = new BusinessSearchResponse(transactionID: transactionID);

      Assert.Equal(transactionID1, transactionID1);
      Assert.Equal(transactionID1, new BusinessSearchResponse(transactionID: transactionID));
      Assert.NotEqual(transactionID1, new BusinessSearchResponse(transactionID: transactionID + "1"));
      Assert.False(transactionID1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string transactionID = "test-transactionID";
      BusinessSearchResponse businessSearchResponse = new BusinessSearchResponse(transactionID: transactionID);
      object obj = new BusinessSearchResponse(transactionID: transactionID);

      Assert.True(businessSearchResponse.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<ServiceError> errors = new List<ServiceError> { new ServiceError(message: "test-message") };

      BusinessSearchResponse businessSearchResponse1 = new BusinessSearchResponse();
      businessSearchResponse1.TransactionID = "test-transactionID";
      businessSearchResponse1.UploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      businessSearchResponse1.CountryCode = "test-countryCode";
      businessSearchResponse1.ProductName = "test-productName";
      businessSearchResponse1.Record = new BusinessRecord(transactionRecordID: "test-transactionRecordID");
      businessSearchResponse1.Errors = errors;

      BusinessSearchResponse businessSearchResponse2 = new BusinessSearchResponse();
      businessSearchResponse2.TransactionID = "test-transactionID";
      businessSearchResponse2.UploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      businessSearchResponse2.CountryCode = "test-countryCode";
      businessSearchResponse2.ProductName = "test-productName";
      businessSearchResponse2.Record  = new BusinessRecord(transactionRecordID: "test-transactionRecordID");
      businessSearchResponse2.Errors = errors;

      Assert.Equal(businessSearchResponse1.GetHashCode(), businessSearchResponse2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string transactionID = "test-transactionID";

      Assert.Equal(new BusinessSearchResponse(transactionID: transactionID).ToString(), new BusinessSearchResponse(transactionID: transactionID).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string transactionID = "test-transactionID";

      Assert.Equal(new BusinessSearchResponse(transactionID: transactionID).ToJson(), new BusinessSearchResponse(transactionID: transactionID).ToJson());
    }
  }
}