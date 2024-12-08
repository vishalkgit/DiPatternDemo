using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public interface IRegisterRepository
    {
       

        int AddUser(User user);

        User getUser(User user);

       
    }
}
