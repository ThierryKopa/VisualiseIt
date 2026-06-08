using HAK_BlazorPicoTemplate.Database;
using Microsoft.EntityFrameworkCore;
using HAK_BlazorPicoTemplate.Models;

namespace HAK_BlazorPicoTemplate.Services
{
    public class UserService
    {
        private readonly IDbContextFactory<UserDbContext> _dbContextFactory;
        public User loggedInUser { get; private set; }

        public UserService(IDbContextFactory<UserDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public (bool, string) AddUser(User newUser)
        {
            try
            {
                using(var context = _dbContextFactory.CreateDbContext())
                {
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    return (true, string.Empty);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) DeleteUser(User newUser)
        {
            try
            {
                using (var context = _dbContextFactory.CreateDbContext())
                {
                    context.Users.Remove(newUser);
                    context.SaveChanges();
                    return (true, string.Empty);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<User> GetUsers()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Users.ToList();
            }
        }
    }
}
