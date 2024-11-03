using AutoMapper;
using Expense_Control.API.Contract.User;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Repository.Interfaces;
using Expense_Control.API.Domain.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Expense_Control.API.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        // private readonly TokenService _tokenService;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> Add(UserRequestDTO entity, long userId)
        {
            var user = _mapper.Map<User>(entity);

            user.Password = GenerateHashPassword(user.Password);
            user.RegisterDate = DateTime.Now;
            user = await _userRepository.Add(user);

            return _mapper.Map<UserResponseDTO>(user);
        }

        public Task<UserLoginResponseDTO> Authenticate(UserLoginRequestDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserResponseDTO>> Get(long userId)
        {
            var user = await _userRepository.Get();

            return user.Select(user => _mapper.Map<UserResponseDTO>(user));
        }

        public async Task<UserResponseDTO> Get(long id, long userId)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO> Get(string email)
        {
            var user = await _userRepository.Get(email);

            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task Inactive(long id, long userId)
        {
            var user = _userRepository.Get(id) ?? throw new Exception("User not found.");

            await _userRepository.DeleteUser(_mapper.Map<User>(user));

        }

        public async Task<UserResponseDTO> Update(long id, UserRequestDTO entity, long userId)
        {
            _ = _userRepository.Get(id) ?? throw new Exception("User not found.");

            var user = _mapper.Map<User>(entity);

            user.Id = id;
            user.Password = GenerateHashPassword(user.Password);

            user = await _userRepository.Update(user);

            return _mapper.Map<UserResponseDTO>(user);
        }

        private string GenerateHashPassword(string password)
        {
            string hashPassword;

            using(SHA256 sha256 = SHA256.Create()) 
            {
                byte[] bytePassword = Encoding.UTF8.GetBytes(password);
                byte[] bytesPassword = sha256.ComputeHash(bytePassword);
                hashPassword = BitConverter.ToString(bytesPassword).Replace("-", "").Replace("-", "").ToLower();
                // hashPassword = BitConverter.ToString(bytesPassword).ToLower();
            }

            return hashPassword;
        }
    }
}
