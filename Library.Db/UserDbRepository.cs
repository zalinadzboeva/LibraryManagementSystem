using Library.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Db
{
    public class UserDbRepository
    {
        private readonly DatabaseContext databaseContext;

        public UserDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(User user)
        {
            databaseContext.Users.Add(user);
            databaseContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return databaseContext.Users.Include(u => u.Books).ToList();
        }

        public void Remove(string login)
        {
            var user = TryGetByName(login);
            if (user is null)
                return;
            databaseContext.Users.Remove(user);
            databaseContext.SaveChanges();
        }

        public void EditData(string userName, EditUserData newData)
        {
            var user = TryGetByName(userName);
            if (user is null)
                return;
            user.Address = newData.Address;
            user.PhoneNumber = newData.PhoneNumber;
            user.Name = newData.Name;
            databaseContext.SaveChanges();
        }

        public User TryGetByName(string userName)
        {
            return databaseContext.Users
                .Include(u => u.Books)
                .FirstOrDefault(u => u.UserName == userName);
        }
    }
}
