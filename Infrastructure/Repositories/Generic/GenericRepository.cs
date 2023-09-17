using Domain.Entities.Common;
using Domain.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T model)
        {
            _dbSet.Add(model);
            return await SaveChangesAsync();
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            _dbSet.AddRange(datas);
            return await SaveChangesAsync();
        }

        public bool Remove(T model)
        {
            _dbSet.Remove(model);
            return SaveChanges() > 0;
        }

        public bool RemoveRange(List<T> datas)
        {
            _dbSet.RemoveRange(datas);
            return SaveChanges() > 0;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return await SaveChangesAsync();
            }
            return false;
        }

        public bool Update(T model)
        {
            _dbSet.Update(model);
            return SaveChanges() > 0;
        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = tracking ? _dbSet.AsQueryable() : _dbSet.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = GetAll(tracking).Where(method);
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = GetWhere(method, tracking);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            if (Guid.TryParse(id, out Guid entityId))
            {
                var query = GetAll(tracking).Where(e => e.Id == entityId);
                return await query.FirstOrDefaultAsync();
            }
            return null;
        }

        private int SaveChanges()
        {
            return _context.SaveChanges();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
