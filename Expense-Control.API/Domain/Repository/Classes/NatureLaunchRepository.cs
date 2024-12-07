using Expense_Control.API.Data;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expense_Control.API.Domain.Repository.Classes
{
    public class NatureLaunchRepository : INatureLaunchRepository
    {
        private readonly ApplicationContext _context;

        public NatureLaunchRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<NatureLaunch> Add(NatureLaunch entity)
        {
            await _context.NatureLaunche.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        //Delete lógico.
        public async Task Delete(NatureLaunch entity)
        {
            entity.InactiveDate = DateTime.Now;
            await Update(entity);
        }

        public async Task<IEnumerable<NatureLaunch>> Get()
        {
            return await _context.NatureLaunche.AsNoTracking().OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<NatureLaunch?> Get(long id)
        {
            return await _context.NatureLaunche.AsNoTracking()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NatureLaunch>> GetByUserId(long userId)
        {
            return await _context.NatureLaunche.AsNoTracking()
                .Where(u => u.UserId == userId)
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task<NatureLaunch> Update(NatureLaunch entity)
        {
            var results = _context.NatureLaunche
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            if (results == null)
            {
                throw new Exception("Nature launch not register");
            }
            _context.Entry(results).CurrentValues.SetValues(entity);
            _context.Update<NatureLaunch>(results);

            await _context.SaveChangesAsync();

            return results;
        }
    }
}
