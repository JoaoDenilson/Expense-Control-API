using Expense_Control.API.Domain.Models;

namespace Expense_Control.API.Domain.Repository.Interfaces
{
    public interface ITitleToReceiveRepository : IRepository<TitleToReceive, long>
    {
        Task<IEnumerable<TitleToReceive>> GetByUserId(long userId);
    }
}
