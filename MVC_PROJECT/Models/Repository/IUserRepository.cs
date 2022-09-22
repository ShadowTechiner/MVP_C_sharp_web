namespace MVC_PROJECT.Models.Repository
{
    public interface IUserRepository
    {
        public User FindByLogin(string login);
        public void CreateUser(User user, string password);
        public void DeleteUser(User user);
        public User FindByLoginAndPasswordSha(string login, string password);
    }
}
