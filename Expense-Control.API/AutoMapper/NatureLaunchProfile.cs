using AutoMapper;
using Expense_Control.API.Contract.NatureLaunch;
using Expense_Control.API.Contract.User;
using Expense_Control.API.Domain.Models;

namespace Expense_Control.API.AutoMapper
{
    public class NatureLaunchProfile : Profile
    {
        public NatureLaunchProfile()
        {
            CreateMap<NatureLaunch, NatureLaunchRequestDTO>().ReverseMap();
            CreateMap<NatureLaunch, NatureLaunchResponseDTO>().ReverseMap();
        }
    }
}
