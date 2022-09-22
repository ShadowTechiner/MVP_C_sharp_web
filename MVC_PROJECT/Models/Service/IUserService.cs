namespace MVC_PROJECT.Models.Service
{
    public interface IUserService
    {
        void ValidateRegister(User user, string password);
        void Register(User user, string password);
        User FindByLoginAndPassword(string login, string password);
    }
}
