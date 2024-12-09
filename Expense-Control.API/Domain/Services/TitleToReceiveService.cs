using AutoMapper;
using Expense_Control.API.Contract.NatureLaunch;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Repository.Interfaces;
using Expense_Control.API.Domain.Services.Interfaces;
using Expense_Control.API.Exceptions;

namespace Expense_Control.API.Domain.Services
{
    public class TitleToReceiveService : IService<TitleToReceiveRequestDTO, TitleToReceiveResponseDTO, long>
    {
        private readonly ITitleToReceiveRepository _titleToReceiveRepository;
        private readonly IMapper _mapper;

        public TitleToReceiveService(ITitleToReceiveRepository titleToReceiveRepository, IMapper mapper)
        {
            _titleToReceiveRepository = titleToReceiveRepository;
            _mapper = mapper;
        }

        public async Task<TitleToReceiveResponseDTO> Add(TitleToReceiveRequestDTO entity, long userId)
        {
            validityValueIsNull(entity);
            var titleToReceive = _mapper.Map<TitleToReceive>(entity);

            titleToReceive.RegisterDate = DateTime.Now;
            titleToReceive.UserId = userId;

            titleToReceive = await _titleToReceiveRepository.Add(titleToReceive);

            return _mapper.Map<TitleToReceiveResponseDTO>(titleToReceive);
        }

        public async Task<IEnumerable<TitleToReceiveResponseDTO>> Get(long userId)
        {
            var titleToReceive = await _titleToReceiveRepository.GetByUserId(userId);

            return titleToReceive.Select(x => _mapper.Map<TitleToReceiveResponseDTO>(x));
        }

        public async Task<TitleToReceiveResponseDTO> Get(long id, long userId)
        {
            var titleToReceive = await GetByIdBindId(id, userId);

            return _mapper.Map<TitleToReceiveResponseDTO>(titleToReceive);
        }

        public async Task Inactive(long id, long userId)
        {
            var titleToReceive = await GetByIdBindId(id, userId);

            await _titleToReceiveRepository.Delete(titleToReceive);
        }

        public async Task<TitleToReceiveResponseDTO> Update(long id, TitleToReceiveRequestDTO entity, long userId)
        {
            validityValueIsNull(entity);
            var titleToReceive = await GetByIdBindId(id, userId);

            var contract = _mapper.Map<TitleToReceive>(titleToReceive);
            contract.Id = titleToReceive.Id;
            contract.Notes = titleToReceive.Notes!;
            contract.OriginalValue = titleToReceive.OriginalValue;



            contract = await _titleToReceiveRepository.Update(contract);

            return _mapper.Map<TitleToReceiveResponseDTO>(contract);
        }

        private async Task<TitleToReceive> GetByIdBindId(long id, long userId)
        {
            var titleToReceive = await _titleToReceiveRepository.Get(id);

            if (titleToReceive == null || titleToReceive.UserId != userId)
            {
                throw new NotfoundException($"Title to Receive by Id - {id} not found");
            }

            return titleToReceive;
        }
        private void validityValueIsNull(TitleToReceiveRequestDTO entity)
        {
            if (entity.OriginalValue < 0 || entity.OriginalValue < 0)
            {
                throw new BadRequestException("Os campos valor original e valor recebimento não pode ser negativos");
            }
        }
    }
}
