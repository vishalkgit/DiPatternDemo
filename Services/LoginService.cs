using DiPatternDemo.Models;
using DiPatternDemo.Repositories;

namespace DiPatternDemo.Services
{
    public class LoginService:ILoginService
    {
        private readonly IRegisterRepository repo;

        public LoginService(IRegisterRepository repo)
        {
            this.repo = repo;
        }

        public int AddUser(User user)
        {
            return repo.AddUser(user);
        }

        public User getUser(User user)
        {
           return repo.getUser(user);
        }
    }
}
