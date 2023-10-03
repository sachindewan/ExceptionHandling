using System.Globalization;
using System.Net;
using ExceptionHandling.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegisterController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        [HttpGet("{email}/{password}")]
        public ActionResult Register(string email, string password)
        {
            _registrationService.Register(email,password);
            return Ok();
            //return oneOfResult.Match(data => Ok(data), error => Problem(detail: "Registration error occured",statusCode:(int)error.StatusCode));
        }
    }
}
