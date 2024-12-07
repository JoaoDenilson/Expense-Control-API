using Expense_Control.API.Domain.Models;

namespace Expense_Control.API.Domain.Repository.Interfaces
{
    public interface ITitleToPayRepository : IRepository<TitleToPay, long>
    {
        Task<IEnumerable<TitleToPay>> GetByUserId(long userId);
    }
}
