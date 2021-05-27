using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class RecordTests
  {
    private Trulioo.SDK.Model.Record record;

    public RecordTests()
    {
      record = new Trulioo.SDK.Model.Record();
    }

    [Fact]
    public void TransactionRecordIDTest()
    {
      string transactionRecordID = "test-transactionRecordID";
      record.TransactionRecordID = transactionRecordID;

      Assert.Equal(transactionRecordID, record.TransactionRecordID);
      Assert.Equal(transactionRecordID, (new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID)).TransactionRecordID);
    }

    [Fact]
    public void RecordStatusTest()
    {
      string recordStatus = "test-recordStatus";
      record.RecordStatus = recordStatus;

      Assert.Equal(recordStatus, record.RecordStatus);
      Assert.Equal(recordStatus, (new Trulioo.SDK.Model.Record(recordStatus: recordStatus)).RecordStatus);
    }

    [Fact]
    public void DatasourceResultsTest()
    {
      List<DatasourceResult> datasourceResults = new List<DatasourceResult> { new DatasourceResult(datasourceStatus: "test-datasourceStatus") };
      record.DatasourceResults = datasourceResults;

      Assert.Equal(datasourceResults, record.DatasourceResults);
      Assert.Equal(datasourceResults, (new Trulioo.SDK.Model.Record(datasourceResults: datasourceResults)).DatasourceResults);
    }

    [Fact]
    public void ErrorsTest()
    {
      List<ServiceError> errors = new List<ServiceError> { new ServiceError(message: "test-message") };
      record.Errors = errors;

      Assert.Equal(errors, record.Errors);
      Assert.Equal(errors, (new Trulioo.SDK.Model.Record(errors: errors)).Errors);
    }

    [Fact]
    public void RuleTest()
    {
      RecordRule rule = new RecordRule(ruleName: "test-ruleName");
      record.Rule = rule;

      Assert.Equal(rule, record.Rule);
      Assert.Equal(rule, (new Trulioo.SDK.Model.Record(rule: rule)).Rule);
    }

    [Fact]
    public void EqualsTest()
    {
      string transactionRecordID = "test-transactionRecordID";
      Trulioo.SDK.Model.Record transactionRecordID1 = new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID);

      Assert.Equal(transactionRecordID1, transactionRecordID1);
      Assert.Equal(transactionRecordID1, new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID));
      Assert.NotEqual(transactionRecordID1, new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID + "1"));
      Assert.False(transactionRecordID1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string transactionRecordID = "test-transactionRecordID";
      Trulioo.SDK.Model.Record record = new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID);
      object obj = new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID);

      Assert.True(record.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<DatasourceResult> datasourceResults = new List<DatasourceResult>();
      List<ServiceError> errors = new List<ServiceError>();

      Trulioo.SDK.Model.Record record1 = new Trulioo.SDK.Model.Record();
      record1.TransactionRecordID = "test-transactionRecordID";
      record1.RecordStatus = "test-recordStatus";
      record1.DatasourceResults = datasourceResults;
      record1.Errors = errors;
      record1.Rule = new RecordRule(ruleName: "test-ruleName");
      Trulioo.SDK.Model.Record record2 = new Trulioo.SDK.Model.Record();
      record2.TransactionRecordID = "test-transactionRecordID";
      record2.RecordStatus = "test-recordStatus";
      record2.DatasourceResults = datasourceResults;
      record2.Errors = errors;
      record2.Rule = new RecordRule(ruleName: "test-ruleName");

      Assert.Equal(record1.GetHashCode(), record2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string transactionRecordID = "test-transactionRecordID";

      Assert.Equal(new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID).ToString(), new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string transactionRecordID = "test-transactionRecordID";

      Assert.Equal(new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID).ToJson(), new Trulioo.SDK.Model.Record(transactionRecordID: transactionRecordID).ToJson());
    }
  }
}