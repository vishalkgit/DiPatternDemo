using DiPatternDemo.Models;

namespace DiPatternDemo.Services
{
    public interface IRegisterService
    {
        User AddUser(User user);

        User getUser(User user);
    }
}
