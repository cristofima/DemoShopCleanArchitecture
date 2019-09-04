using AutoMapper;
using Shop.Core.DTO;
using Shop.Infrastructure.Data.Identity;

namespace Shop.Infrastructure.Data.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ApplicationUser>().ConstructUsing(u => new ApplicationUser { Id = u.Id, UserName = u.UserName, PasswordHash = u.PasswordHash });
            CreateMap<ApplicationUser, User>().ConstructUsing(au => new User(au.Email, au.UserName, au.Id, au.PasswordHash));
        }
    }
}