using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class BusinessRecordTests
  {
    private BusinessRecord businessRecord;

    public BusinessRecordTests()
    {
      businessRecord = new BusinessRecord();
    }

    [Fact]
    public void TransactionRecordIDTest()
    {
      string transactionRecordID = "test-transaction-record-id";
      businessRecord.TransactionRecordID = transactionRecordID;

      Assert.Equal(transactionRecordID, businessRecord.TransactionRecordID);
      Assert.Equal(transactionRecordID, (new BusinessRecord(transactionRecordID: transactionRecordID)).TransactionRecordID);
    }

    [Fact]
    public void RecordStatusTest()
    {
      string recordStatus = "match";
      businessRecord.RecordStatus = recordStatus;

      Assert.Equal(recordStatus, businessRecord.RecordStatus);
      Assert.Equal(recordStatus, (new BusinessRecord(recordStatus: recordStatus)).RecordStatus);
    }

    [Fact]
    public void DatasourceResultsTest()
    {
      List<BusinessResult> datasourceResults = new List<BusinessResult> { new BusinessResult(datasourceName: "test-name") };
      businessRecord.DatasourceResults = datasourceResults;

      Assert.Equal(datasourceResults, businessRecord.DatasourceResults);
      Assert.Equal(datasourceResults, (new BusinessRecord(datasourceResults: datasourceResults)).DatasourceResults);
    }

    [Fact]
    public void ErrorsTest()
    {
      List<ServiceError> errors = new List<ServiceError> { new ServiceError(message: "test-message") };
      businessRecord.Errors = errors;

      Assert.Equal(errors, businessRecord.Errors);
      Assert.Equal(errors, (new BusinessRecord(errors: errors)).Errors);
    }

    [Fact]
    public void EqualsTest()
    {
      string transactionRecordID = "test-transaction-record-id";
      BusinessRecord transactionRecordID1 = new BusinessRecord(transactionRecordID: transactionRecordID);

      Assert.Equal(transactionRecordID1, transactionRecordID1);
      Assert.Equal(transactionRecordID1, new BusinessRecord(transactionRecordID: transactionRecordID));
      Assert.False(transactionRecordID1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string transactionRecordID = "test-transactionRecordID";
      BusinessRecord businessRecord = new BusinessRecord(transactionRecordID: transactionRecordID);
      object obj = new BusinessRecord(transactionRecordID: transactionRecordID);

      Assert.True(businessRecord.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      BusinessRecord businessRecord1 = new BusinessRecord();
      businessRecord1.TransactionRecordID = "test-transactionRecordID";
      businessRecord1.RecordStatus = "test-recordStatus";

      BusinessRecord businessRecord2 = new BusinessRecord();
      businessRecord2.TransactionRecordID = "test-transactionRecordID";
      businessRecord2.RecordStatus = "test-recordStatus";

      Assert.Equal(businessRecord1.GetHashCode(), businessRecord2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string transactionRecordID = "test-transactionRecordID";

      Assert.Equal(new BusinessRecord(transactionRecordID: transactionRecordID).ToString(), new BusinessRecord(transactionRecordID: transactionRecordID).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string transactionRecordID = "test-transactionRecordID";

      Assert.Equal(new BusinessRecord(transactionRecordID: transactionRecordID).ToJson(), new BusinessRecord(transactionRecordID: transactionRecordID).ToJson());
    }
  }
}