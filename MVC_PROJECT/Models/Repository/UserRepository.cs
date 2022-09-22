using MVC_PROJECT.App_Data;
using MVC_PROJECT.Models.Repository;

namespace MVC_PROJECT.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public User FindByLogin(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login);
        }
        public User FindByLoginAndPasswordSha(string login, string passwordSha)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login && u.Password == passwordSha);
        }

        public void CreateUser(User user, string password)
        {
            try
            {
                user.Password = password;
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
