namespace Expense_Control.API.Domain.Repository.Interfaces
{
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T?> Get(I id);

        Task<T> Add(T entity);

        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
