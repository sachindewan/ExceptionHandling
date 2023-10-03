using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Exception
{
    public interface IServiceException
    {
        //public HttpStatusCode StatusCode { get; }
        //public string  ErrorMessage { get;}

        public ProblemDetails ProblemDetails { get; }
    }
}
