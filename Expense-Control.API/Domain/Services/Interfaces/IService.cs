namespace Expense_Control.API.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface genérica para criação de serviços CRUD
    /// </summary>
    /// <typeparam name="RQ">Contract request</typeparam>
    /// <typeparam name="RS">Contract response</typeparam>
    /// <typeparam name="I">Type ID </typeparam>
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Get(I userId);
        Task<RS> Get(I id, I userId);
        Task<RS> Add(RQ entity, I userId);
        Task<RS> Update(I id, RQ entity, I userId);
        Task Inactive(I id, I userId);
    }
}
