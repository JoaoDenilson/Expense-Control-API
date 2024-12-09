using AutoMapper;
using Expense_Control.API.Contract.NatureLaunch;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Repository.Interfaces;
using Expense_Control.API.Domain.Services.Interfaces;
using Expense_Control.API.Exceptions;

namespace Expense_Control.API.Domain.Services
{
    public class TitleToPayService : IService<TitleToPayRequestDTO, TitleToPayResponseDTO, long>
    {
        private readonly ITitleToPayRepository _titleToPayRepository;
        private readonly IMapper _mapper;

        public TitleToPayService(ITitleToPayRepository titleToPayRepository, IMapper mapper)
        {
            _titleToPayRepository = titleToPayRepository;
            _mapper = mapper;
        }

        public async Task<TitleToPayResponseDTO> Add(TitleToPayRequestDTO entity, long userId)
        {
            validityValueIsNull(entity);

            var titleToPay = _mapper.Map<TitleToPay>(entity);

            titleToPay.RegisterDate = DateTime.Now;
            titleToPay.UserId = userId;

            titleToPay = await _titleToPayRepository.Add(titleToPay);

            return _mapper.Map<TitleToPayResponseDTO>(titleToPay);
        }

        public async Task<IEnumerable<TitleToPayResponseDTO>> Get(long userId)
        {
            var titleToPay = await _titleToPayRepository.GetByUserId(userId);

            return titleToPay.Select(x => _mapper.Map<TitleToPayResponseDTO>(x));
        }

        public async Task<TitleToPayResponseDTO> Get(long id, long userId)
        {
            var titleToPay = await GetByIdBindId(id, userId);

            return _mapper.Map<TitleToPayResponseDTO>(titleToPay);
        }

        public async Task Inactive(long id, long userId)
        {
            var titleToPay = await GetByIdBindId(id, userId);

            await _titleToPayRepository.Delete(titleToPay);
        }

        public async Task<TitleToPayResponseDTO> Update(long id, TitleToPayRequestDTO entity, long userId)
        {
            validityValueIsNull(entity);

            var titleToPay = await GetByIdBindId(id, userId);

            var contract = _mapper.Map<TitleToPay>(titleToPay);
            contract.Id = titleToPay.Id;
            contract.Notes = titleToPay.Notes!;
            contract.OriginalValue = titleToPay.OriginalValue;



            contract = await _titleToPayRepository.Update(contract);

            return _mapper.Map<TitleToPayResponseDTO>(contract);
        }

        private async Task<TitleToPay> GetByIdBindId(long id, long userId)
        {
            var titleToPay = await _titleToPayRepository.Get(id);

            if (titleToPay == null || titleToPay.UserId != userId)
            {
                throw new NotfoundException($"Title to pay by Id - {id} not found");
            }

            return titleToPay;
        }
        private void validityValueIsNull(TitleToPayRequestDTO entity)
        {
            if (entity.OriginalValue < 0 || entity.OriginalValue < 0)
            {
                throw new BadRequestException("Os campos valor original e valor recebimento não pode ser negativos");
            }
        }
    }
}
