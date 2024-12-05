using Expense_Control.API.Data;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expense_Control.API.Domain.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext contexto)
        {
            _context = contexto;
        }

        public async Task<User> Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(User entity)
        {
            // Delete físico
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(User entity)
        {
            // Delete lógico 
            var result = _context.Users.Find(entity.Id);

            if (result != null)
            {
                result.InactiveDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> Get(string email)
        {
             var results = await _context.Users.AsNoTracking()
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();

            return results;
        }

        public async Task<User?> Get(long id)
        {
            return await _context.Users.AsNoTracking()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.AsNoTracking().OrderBy(u=> u.Id).ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            var results = _context.Users
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            if (results == null)
            {
                throw new Exception("User not register");
            }
            _context.Entry(results).CurrentValues.SetValues(entity);
            _context.Update<User>(results);

            await _context.SaveChangesAsync();

            return results;
        }
    }
}
