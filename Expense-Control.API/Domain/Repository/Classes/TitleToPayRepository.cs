using Expense_Control.API.Data;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expense_Control.API.Domain.Repository.Classes
{
    public class TitleToPayRepository : ITitleToPayRepository
    {
        private readonly ApplicationContext _context;

        public TitleToPayRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<TitleToPay> Add(TitleToPay entity)
        {
            await _context.TitleToPay.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        //Delete lógico.
        public async Task Delete(TitleToPay entity)
        {
            entity.InactiveDate = DateTime.Now;
            await Update(entity);
        }

        public async Task<IEnumerable<TitleToPay>> Get()
        {
            return await _context.TitleToPay.AsNoTracking().OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<TitleToPay?> Get(long id)
        {
            return await _context.TitleToPay.AsNoTracking()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TitleToPay>> GetByUserId(long userId)
        {
            return await _context.TitleToPay.AsNoTracking()
                .Where(u => u.UserId == userId)
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task<TitleToPay> Update(TitleToPay entity)
        {
            var results = _context.TitleToPay
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            if (results == null)
            {
                throw new Exception("Title To Pay not register");
            }
            _context.Entry(results).CurrentValues.SetValues(entity);
            _context.Update<TitleToPay>(results);

            await _context.SaveChangesAsync();

            return results;
        }
    }
}
