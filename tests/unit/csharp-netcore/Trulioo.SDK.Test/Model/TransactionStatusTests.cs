using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class TransactionStatusTests
  {
    private TransactionStatus transactionStatus;

    public TransactionStatusTests()
    {
      transactionStatus = new TransactionStatus();
    }

    [Fact]
    public void TransactionIdTest()
    {
      string transactionId = "test-transactionId";
      transactionStatus.TransactionId = transactionId;

      Assert.Equal(transactionId, transactionStatus.TransactionId);
      Assert.Equal(transactionId, (new TransactionStatus(transactionId: transactionId)).TransactionId);
    }

    [Fact]
    public void TransactionRecordIdTest()
    {
      string transactionRecordId = "test-transactionRecordId";
      transactionStatus.TransactionRecordId = transactionRecordId;

      Assert.Equal(transactionRecordId, transactionStatus.TransactionRecordId);
      Assert.Equal(transactionRecordId, (new TransactionStatus(transactionRecordId: transactionRecordId)).TransactionRecordId);
    }

    [Fact]
    public void StatusTest()
    {
      string status = "test-status";
      transactionStatus.Status = status;

      Assert.Equal(status, transactionStatus.Status);
      Assert.Equal(status, (new TransactionStatus(status: status)).Status);
    }

    [Fact]
    public void UploadedDtTest()
    {
      DateTime uploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      transactionStatus.UploadedDt = uploadedDt;

      Assert.Equal(uploadedDt, transactionStatus.UploadedDt);
      Assert.Equal(uploadedDt, (new TransactionStatus(uploadedDt: uploadedDt)).UploadedDt);
    }

    [Fact]
    public void IsTimedOutTest()
    {
      bool isTimedOut = false;
      transactionStatus.IsTimedOut = isTimedOut;

      Assert.Equal(isTimedOut, transactionStatus.IsTimedOut);
      Assert.Equal(isTimedOut, (new TransactionStatus(isTimedOut: isTimedOut)).IsTimedOut);
    }

    [Fact]
    public void EqualsTest()
    {
      string transactionId = "test-transactionId";
      TransactionStatus transactionId1 = new TransactionStatus(transactionId: transactionId);

      Assert.Equal(transactionId1, transactionId1);
      Assert.Equal(transactionId1, new TransactionStatus(transactionId: transactionId));
      Assert.NotEqual(transactionId1, new TransactionStatus(transactionId: transactionId + "1"));
      Assert.False(transactionId1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string transactionId = "test-transactionId";
      TransactionStatus transactionStatus = new TransactionStatus(transactionId: transactionId);
      object obj = new TransactionStatus(transactionId: transactionId);

      Assert.True(transactionStatus.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      TransactionStatus transactionStatus1 = new TransactionStatus();
      transactionStatus1.TransactionId = "test-transactionId";
      transactionStatus1.TransactionRecordId = "test-transactionRecordId";
      transactionStatus1.Status = "test-status";
      transactionStatus1.UploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      transactionStatus1.IsTimedOut = false;

      TransactionStatus transactionStatus2 = new TransactionStatus();
      transactionStatus2.TransactionId = "test-transactionId";
      transactionStatus2.TransactionRecordId = "test-transactionRecordId";
      transactionStatus2.Status = "test-status";
      transactionStatus2.UploadedDt = DateTime.Parse("2020-09-15T00:00:00+00:00");
      transactionStatus2.IsTimedOut = false;

      Assert.Equal(transactionStatus1.GetHashCode(), transactionStatus2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string transactionId = "test-transactionId";

      Assert.Equal(new TransactionStatus(transactionId: transactionId).ToString(), new TransactionStatus(transactionId: transactionId).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string transactionId = "test-transactionId";

      Assert.Equal(new TransactionStatus(transactionId: transactionId).ToJson(), new TransactionStatus(transactionId: transactionId).ToJson());
    }
  }
}