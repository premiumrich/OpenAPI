using System;
using Trulioo.SDK.Client;

namespace Trulioo.SampleApp.Models
{
  public class ObjectResult
  {

    public ObjectResult (int errorCode, string message, string operation)
    {
      this.ErrorCode = errorCode;
      this.Message = message;
      this.Operation =  operation;
    }

    public int ErrorCode
    {
      get;
      set;
    }

    public string Message
    {
      get;
      set;
    }

    public string Operation
    {
      get;
      set;
    }
  }
}