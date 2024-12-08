using DiPatternDemo.Models;
using DiPatternDemo.Repositories;

namespace DiPatternDemo.Services
{
    public class RegisterService:IRegisterService
    {
        private readonly IRegisterRepository repo;

        public RegisterService(IRegisterRepository repo)
        {
            this.repo = repo;
        }

        public int AddUser(User user)
        {
            return repo.AddUser(user);
        }

        public User getUser(User user)
        {
           return user;
        }
    }
}
