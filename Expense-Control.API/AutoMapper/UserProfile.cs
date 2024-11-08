using AutoMapper;
using Expense_Control.API.Contract.User;
using Expense_Control.API.Domain.Models;

namespace Expense_Control.API.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserRequestDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
        }
    }
}
