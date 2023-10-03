using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Exception.MiddleWare
{
    public class GlobalExceptionMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception exception)
            {
                ProblemDetails problemDetails;
                //var (ProblemDetails ) = exception switch
                //{
                //    IServiceException serviceException => serviceException.ProblemDetails,
                //    _ => new ProblemDetails(){ Detail = "An un expected error occored", Status = (int)HttpStatusCode.InternalServerError}

                //};

                switch (exception)
                {
                    case IServiceException serviceException:
                         problemDetails = serviceException.ProblemDetails;
                        break;
                    default:
                        problemDetails = new ProblemDetails()
                        {
                            Detail = "An un expected error occored", Status = (int) HttpStatusCode.InternalServerError
                        };
                        break;
                }

                context.Response.StatusCode = (int)problemDetails?.Status;
                var json  = JsonSerializer.Serialize(problemDetails);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
