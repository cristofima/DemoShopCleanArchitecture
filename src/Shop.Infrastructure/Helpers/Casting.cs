using Shop.Core.DTO;
using Shop.Infrastructure.Data.Identity;

namespace Shop.Infrastructure.Helpers
{
    public class Casting
    {
        public static User ApplicationUserToUser(ApplicationUser appUser)
        {
            return new User(appUser.Email, appUser.UserName, appUser.Id, appUser.PasswordHash);
        }

        public static ApplicationUser UserToApplicationUser(User user)
        {
            return new ApplicationUser { Id = user.Id, UserName = user.UserName, Email = user.Email, PasswordHash = user.PasswordHash };
        }
    }
}