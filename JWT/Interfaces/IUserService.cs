using JWT.Data;

namespace JWT.Interfaces
{
    public interface IUserService
    {

       
        public Task RegisterAsync(string Login, string Paswword,string role);
        public Task<Token> LoginAsync(string Login, string password);
        public Task<List<User>> GetAllUser();
    }
}
