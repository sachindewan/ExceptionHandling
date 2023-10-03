using ExceptionHandling.Exception;
using OneOf;

namespace ExceptionHandling.Services
{
    public interface IRegistrationService
    {
        void Register(string email,string password);
        //OneOf<bool, IServiceException> Register(string email,string password);
    }
}
