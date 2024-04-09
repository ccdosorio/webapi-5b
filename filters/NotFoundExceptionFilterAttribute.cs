using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using webapi_5b.Exceptions;

namespace webapi_5b.Filters;
public class NotFoundExceptionFilterAttribute : ExceptionFilterAttribute
{
  public override void OnException(ExceptionContext context)
  {
    if (context.Exception is NotFoundException)
    {
      context.Result = new NotFoundObjectResult(context.Exception.Message);
      context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
    }
  }
}