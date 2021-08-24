using System;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class ServiceErrorTests
  {
    private ServiceError serviceError;

    public ServiceErrorTests()
    {
      serviceError = new ServiceError();
    }

    [Fact]
    public void CodeTest()
    {
      string code = "test-code";
      serviceError.Code = code;

      Assert.Equal(code, serviceError.Code);
      Assert.Equal(code, (new ServiceError(code: code)).Code);
    }

    [Fact]
    public void MessageTest()
    {
      string message = "test-message";
      serviceError.Message = message;

      Assert.Equal(message, serviceError.Message);
      Assert.Equal(message, (new ServiceError(message: message)).Message);
    }

    [Fact]
    public void EqualsTest()
    {
      string code = "test-code";
      ServiceError code1 = new ServiceError(code: code);

      Assert.Equal(code1, code1);
      Assert.Equal(code1, new ServiceError(code: code));
      Assert.NotEqual(code1, new ServiceError(code: code + "1"));
      Assert.False(code1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string code = "test-code";
      ServiceError serviceError = new ServiceError(code: code);
      object obj = new ServiceError(code: code);

      Assert.True(serviceError.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      ServiceError serviceError1 = new ServiceError();
      serviceError1.Code = "test-code";
      serviceError1.Message = "test-message";

      ServiceError serviceError2 = new ServiceError();
      serviceError2.Code = "test-code";
      serviceError2.Message = "test-message";

      Assert.Equal(serviceError1.GetHashCode(), serviceError2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string code = "test-code";

      Assert.Equal(new ServiceError(code: code).ToString(), new ServiceError(code: code).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string code = "test-code";

      Assert.Equal(new ServiceError(code: code).ToJson(), new ServiceError(code: code).ToJson());
    }
  }
}