using CMS.Infrastructure;
using CMS.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CMS.Infrastructure.SeedWork
{
    public class RepositoryBase<T, Key> : IRepository<T, Key> where T : class
    {
        private readonly CMS_DBContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(CMS_DBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Key id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
public class RepositoryBase<T, Key> : IRepository<T, Key> where T : class
{
    private readonly DbSet<T> _dbSet;
    protected readonly CMS_DBContext _context;
    public RepositoryBase(CMS_DBContext context)
    {
        _dbSet = context.Set<T>();
        _context = context;
    }
    public void Add(T entity)
    {
        _dbSet.AddAsync(entity);
    }
    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<T> GetByIdAsync(Key id)
    {
        return await _dbSet.FindAsync(id);
    }
    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}