using System.Diagnostics;
using System.Net;
using ExceptionHandling.Exception;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult Error()
        //{
        //    System.Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        //    var (statusCode, Message) = exception switch
        //    {
        //        IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
        //        _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured")

        //    };
        //    return Problem(title:Message,statusCode:statusCode);
        //}
    }
}
