using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public interface ILoginRepository
    {
        int AddUser(User user);

        User getUser(User user);

    }
}
