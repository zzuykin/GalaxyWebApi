using AutoMapper;
using Galaxy.Storage.Models;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<EditUser, User>();
            CreateMap<User, EditUser>();
        }
    }
}
