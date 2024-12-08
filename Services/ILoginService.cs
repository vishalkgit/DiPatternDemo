using DiPatternDemo.Models;

namespace DiPatternDemo.Services
{
    public interface ILoginService
    {

        User AddUser(User user);

        User getUser(User user);
    }

}
