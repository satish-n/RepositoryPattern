using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryPattern.Repository.Interface
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;
        string errorMessage = string.Empty;

        public Repository(DbContext context)
        {
            this._context = context;
            this._entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._entities.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> match)
        {
            return await this._entities.Where(match).ToListAsync();
        }

        public Task<int> Count()
        {
            return this._entities.CountAsync();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }
    }
}
