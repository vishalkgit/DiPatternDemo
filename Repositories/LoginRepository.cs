using DiPatternDemo.Data;
using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public class LoginRepository:ILoginRepository
    {
        private readonly ApplicationDBContext db;

        public LoginRepository(ApplicationDBContext db)
        {
            this.db = db;
            
        }

        public int AddUser(User user)
        {
            int result = 0;
            db.Users.Add(user);
            result = db.SaveChanges();
            return result;
        }

        public User getUser(User user)
        {
            return db.Users?.Where(x => x.EmailId == user.EmailId & x.Password == user.Password).FirstOrDefault();
        }
    }
}
