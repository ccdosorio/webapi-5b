namespace webapi_5b.Exceptions;

using System;
using System.Net;

public class NotFoundException : Exception
{
  public HttpStatusCode StatusCode { get; }

  public NotFoundException(string message, HttpStatusCode statusCode = HttpStatusCode.NotFound)
      : base(message)
  {
    StatusCode = statusCode;
  }

  public NotFoundException(string message, Exception innerException, HttpStatusCode statusCode = HttpStatusCode.NotFound)
      : base(message, innerException)
  {
    StatusCode = statusCode;
  }
}
