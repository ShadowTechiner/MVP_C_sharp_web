using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MVC_PROJECT.Models.Exceptions;
using MVC_PROJECT.Models.Repository;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MVC_PROJECT.Models.Service
{
    public class UserService : IUserService
    {
        Regex regex = new Regex("[a-z]+");
        IUserRepository userRepository = default!;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Register(User user, string password)
        {
            userRepository.CreateUser(user, GetPasswordSha(password));
        }

        private string GetPasswordSha(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes("salt");
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public void ValidateRegister(User user, string password)
        {
            if (string.IsNullOrEmpty(user.Login))
            {
                throw new ValidationException("Login is required");
            }

            if (!regex.IsMatch(user.Login))
            {
                throw new ValidationException("Login should contain lowercase Latin letters");
            }

            if (user.Login.Length > 24)
            {
                throw new ValidationException("Login can't be longer than 24 symbols");
            }

            if (userRepository.FindByLogin(user.Login)!= null)
            {
                throw new ValidationException("Login is already in use");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ValidationException("Password is required");
            }

            if (password.Length > 64)
            {
                throw new ValidationException("Password can't be longer than 64 symbols");
            }
        }

        public User FindByLoginAndPassword(string login, string password)
        {
            return userRepository.FindByLoginAndPasswordSha(login,GetPasswordSha(password));
        }
    }
}
