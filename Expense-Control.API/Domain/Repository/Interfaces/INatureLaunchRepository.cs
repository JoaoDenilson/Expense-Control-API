using Expense_Control.API.Domain.Models;

namespace Expense_Control.API.Domain.Repository.Interfaces
{
    public interface INatureLaunchRepository : IRepository<NatureLaunch, long>
    {
        Task<IEnumerable<NatureLaunch>> GetByUserId(long userId);
    }
}
