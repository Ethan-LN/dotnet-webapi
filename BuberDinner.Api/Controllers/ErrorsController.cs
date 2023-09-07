using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
  [Route("/error")]
  public IActionResult Error()
  {
    Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    var (statusCode, message) = exception switch
    {
      DuplicateEmailExcetion => (StatusCodes.Status409Conflict, "Email already exsits"),
      _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured."),
    };
     return Problem(statusCode: statusCode, title: message);
  }
}