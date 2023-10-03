using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Exception
{
    public class DuplicateUserException:System.Exception, IServiceException
    {
        public ProblemDetails ProblemDetails => new ProblemDetails()
        {
            Status = (int) HttpStatusCode.Conflict,
            Instance = Guid.NewGuid().ToString(),
            Title = " duplicate record",
            Detail = "record already exist in the database , please try with another user",
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/409"
        };
    }
}
