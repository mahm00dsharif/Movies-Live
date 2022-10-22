using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MoviesLive.Api.DTOs.User;

namespace MoviesLive.Api.DTOs
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterRequest, IdentityUser>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }

    }
}
