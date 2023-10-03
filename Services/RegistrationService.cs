using System.Runtime.InteropServices;
using ExceptionHandling.Exception;
using OneOf;

namespace ExceptionHandling.Services
{
    public class RegistrationService: IRegistrationService
    {
        private static Dictionary<string, string> _cacheUser = new Dictionary<string,string>();
        public void Register(string email, string password)
        {
            if (UserExists(email, password))
            {
                throw new DuplicateUserException();
            }
        }

        private bool UserExists(string email,string password)
        {

            ref var valorNew = ref CollectionsMarshal.GetValueRefOrAddDefault(_cacheUser, email, out var isExists);
            if (!isExists)
            {
                valorNew = password;

                return false;
            }
            return true;
        }
    }
}
