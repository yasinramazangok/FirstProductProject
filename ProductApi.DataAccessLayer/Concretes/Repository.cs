using Microsoft.EntityFrameworkCore;
using ProductApi.DataAccessLayer.Abstracts;
using ProductApi.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.DataAccessLayer.Concretes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProductDbContext _context;

        public Repository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
