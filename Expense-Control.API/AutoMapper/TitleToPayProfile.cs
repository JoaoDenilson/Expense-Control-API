using AutoMapper;
using Expense_Control.API.Contract.NatureLaunch;
using Expense_Control.API.Contract.User;
using Expense_Control.API.Domain.Models;

namespace Expense_Control.API.AutoMapper
{
    public class TitleToPayProfile : Profile
    {
        public TitleToPayProfile()
        {
            CreateMap<TitleToPay, TitleToPayRequestDTO>().ReverseMap();
            CreateMap<TitleToPay, TitleToPayResponseDTO>().ReverseMap();
        }
    }
}
