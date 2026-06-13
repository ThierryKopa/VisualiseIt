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
                bool seek;

                using(var context = _dbContextFactory.CreateDbContext())
                {
                    if(context.Users.Where(e => e.Username == newUser.Username).Any())
                    {
                        return (false, "Der Benutzername ist schon besetzt!");
                    }
                    else
                    {
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        return (true, string.Empty);
                    }
                    
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

        public (bool, string) LoginUser(User loginUser)
        {
            try
            {
                UserDbContext datenbankVerbindung = _dbContextFactory.CreateDbContext();

                

                bool userVorhanden = datenbankVerbindung.Users
                    .Where(u => u.Username == loginUser.Username)
                    .Where(u => u.Password == loginUser.Password)
                    .Any();

                if (userVorhanden)
                {
                    this.loggedInUser = loginUser;

                    User myUser = datenbankVerbindung.Users
                    .Where(u => u.Username == loginUser.Username)
                    .Where(u => u.Password == loginUser.Password)
                    .Single();

                    this.loggedInUser.Id = myUser.Id;

                    return (true, string.Empty);
                }
                else
                {
                    return (false, "Benutzername oder Passwort falsch.");
                }


            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
    }
}
