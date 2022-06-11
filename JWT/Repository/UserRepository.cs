using JWT.Data;
using JWT.Interfaces;

namespace JWT.Repository
{
    public class UserRepository : IUserRepository
    {
        
       
        private List<User> _users = new List<User>() { new User("Admin","SuperAdmin","Admin"),
        new User("Uzytkownik","Password","User"),
        new User("Tester","Welcome1","User")
        };

        public async Task<User> GetAsync(string login)
         => await Task.FromResult(_users.SingleOrDefault(x => x.Login.ToLowerInvariant() == login.ToLowerInvariant()));


        public async Task<List<User>> GetAll()
        {
            return await Task.FromResult(_users);
        }
        public async Task AddAsync(User user)
        {
            var userExists = _users.SingleOrDefault(x => x.Login == user.Login);
            if(userExists != null)
            {
                throw new Exception("Login jest zajety");
            }
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }


        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

    }
}
