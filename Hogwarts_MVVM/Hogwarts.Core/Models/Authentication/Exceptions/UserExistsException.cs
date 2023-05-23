using System.Security.Authentication;

namespace Hogwarts.Core.Models.Authentication.Exceptions
{
    public class UserExistsException : AuthenticationException
    {
        public UserExistsException()
        {
        }

        public UserExistsException(string username) : base($"Username {username} already exists.")
        {
        }

        public UserExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
