using AutoMapper;
using Expense_Control.API.Contract.NatureLaunch;
using Expense_Control.API.Contract.User;
using Expense_Control.API.Domain.Models;

namespace Expense_Control.API.AutoMapper
{
    public class TitleToReceiveProfile : Profile
    {
        public TitleToReceiveProfile()
        {
            CreateMap<TitleToReceive, TitleToReceiveRequestDTO>().ReverseMap();
            CreateMap<TitleToReceive, TitleToReceiveResponseDTO>().ReverseMap();
        }
    }
}
