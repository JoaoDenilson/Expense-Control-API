using Expense_Control.API.Data;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expense_Control.API.Domain.Repository.Classes
{
    public class TitleToReceiveRepository : ITitleToReceiveRepository
    {
        private readonly ApplicationContext _context;

        public TitleToReceiveRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<TitleToReceive> Add(TitleToReceive entity)
        {
            await _context.TitleToReceive.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        //Delete lógico.
        public async Task Delete(TitleToReceive entity)
        {
            entity.InactiveDate = DateTime.Now;
            await Update(entity);
        }

        public async Task<IEnumerable<TitleToReceive>> Get()
        {
            return await _context.TitleToReceive.AsNoTracking().OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<TitleToReceive?> Get(long id)
        {
            return await _context.TitleToReceive.AsNoTracking()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TitleToReceive>> GetByUserId(long userId)
        {
            return await _context.TitleToReceive.AsNoTracking()
                .Where(u => u.UserId == userId)
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task<TitleToReceive> Update(TitleToReceive entity)
        {
            var results = _context.TitleToReceive
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            if (results == null)
            {
                throw new Exception("Title To Pay not register");
            }
            _context.Entry(results).CurrentValues.SetValues(entity);
            _context.Update<TitleToReceive>(results);

            await _context.SaveChangesAsync();

            return results;
        }
    }
}
