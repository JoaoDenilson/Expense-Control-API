using Expense_Control.API.Contract.User;

namespace Expense_Control.API.Domain.Services.Interfaces
{
    public interface IUserService : IService<UserRequestDTO, UserResponseDTO, long>
    {
        Task<UserLoginResponseDTO> Authenticate(UserLoginRequestDTO user);
        Task<UserResponseDTO> Get(string email);
    } 
}
