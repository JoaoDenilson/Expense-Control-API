using AutoMapper;
using Expense_Control.API.Contract.NatureLaunch;
using Expense_Control.API.Contract.User;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Repository.Classes;
using Expense_Control.API.Domain.Repository.Interfaces;
using Expense_Control.API.Domain.Services.Interfaces;

namespace Expense_Control.API.Domain.Services
{
    public class NatureLaunchService : IService<NatureLaunchRequestDTO, NatureLaunchResponseDTO, long>
    {
        private readonly INatureLaunchRepository _natureLaunchRepository;
        private readonly IMapper _mapper;

        public NatureLaunchService(INatureLaunchRepository natureLaunchRepository, IMapper mapper)
        {
            _natureLaunchRepository = natureLaunchRepository;
            _mapper = mapper;
        }

        public async Task<NatureLaunchResponseDTO> Add(NatureLaunchRequestDTO entity, long userId)
        {
            var natureLaunch = _mapper.Map<NatureLaunch>(entity);

            natureLaunch.RegisterDate = DateTime.Now;
            natureLaunch.UserId = userId;

            natureLaunch = await _natureLaunchRepository.Add(natureLaunch);

            return _mapper.Map<NatureLaunchResponseDTO>(natureLaunch);
        }

        public async Task<IEnumerable<NatureLaunchResponseDTO>> Get(long userId)
        {
            var natureslaunch = await _natureLaunchRepository.GetByUserId(userId);

            return natureslaunch.Select(x => _mapper.Map<NatureLaunchResponseDTO>(x));
        }

        public async Task<NatureLaunchResponseDTO> Get(long id, long userId)
        {
            var natureLaunch = await GetByIdBindId(id, userId);

            return _mapper.Map<NatureLaunchResponseDTO>(natureLaunch);
        }

        public async Task Inactive(long id, long userId)
        {
            var natureLaunch = await GetByIdBindId(id, userId);

            await _natureLaunchRepository.Delete(natureLaunch);
        }

        public async Task<NatureLaunchResponseDTO> Update(long id, NatureLaunchRequestDTO entity, long userId)
        {
            var natureLaunch = await GetByIdBindId(id, userId);

            natureLaunch.Description = entity.Description;
            natureLaunch.Notes = entity.Notes;

            natureLaunch = await _natureLaunchRepository.Update(natureLaunch);

            return _mapper.Map<NatureLaunchResponseDTO>(natureLaunch);
        }

        private async Task<NatureLaunch> GetByIdBindId(long id, long userId)
        {
            var natureLaunch = await _natureLaunchRepository.Get(id);

            if (natureLaunch == null || natureLaunch.UserId != userId)
            {
                throw new Exception($"Nature launch by Id - {id} not found");
            }

            return natureLaunch;
        }
    }
}
