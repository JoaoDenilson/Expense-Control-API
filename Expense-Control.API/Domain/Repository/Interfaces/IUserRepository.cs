using Expense_Control.API.Domain.Models;

namespace Expense_Control.API.Domain.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User, long>
    {
        Task<User?> Get(string email);

        Task DeleteUser(User entity);
    }
}
