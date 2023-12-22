using Microsoft.EntityFrameworkCore;
using ProniaOnionAB104.Application.Abstractions.Repositories;
using ProniaOnionAB104.Domain.Entities;
using ProniaOnionAB104.Persistence.Contexts;
using System.Linq.Expressions;

namespace ProniaOnionAB104.Persistence.Implementations.Repositories.Common
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbSet<T> _table;
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _table = context.Set<T>();
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public void SoftDelete(T item)
        {
            item.IsDeleted = true;
            _table.Update(item);
        }
        public IQueryable<T> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? orderExpression = null,
            bool isDescending = false,
            int skip = 0,
            int take = 0,
            bool isTracking = true,
            bool isDeleted = false,
            params string[] includes)
        {
            var query = _table.AsQueryable();

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            if (orderExpression is not null)
            {
                if (isDescending) query = query.OrderByDescending(orderExpression);
                else query = query.OrderBy(orderExpression);
            }

            if (skip != 0) query = query.Skip(skip);

            if (take != 0) query = query.Take(take);

            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (isDeleted) query = query.IgnoreQueryFilters();
            return isTracking ? query : query.AsNoTracking();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            T? entity = await _table.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
