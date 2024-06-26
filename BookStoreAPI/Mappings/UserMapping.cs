using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Mappings
{
    public class UserMapping: Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>();
            CreateMap<Reader, UserDto>();
            CreateMap<Admin, UserDto>();
        }

    }
}
