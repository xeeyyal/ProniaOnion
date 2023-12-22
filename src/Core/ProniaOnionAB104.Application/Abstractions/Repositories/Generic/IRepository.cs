using ProniaOnionAB104.Domain.Entities;
using System.Linq.Expressions;

namespace ProniaOnionAB104.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? orderExpression = null,
            bool IsDescending = false,
            int skip = 0,
            int take = 0,
            bool IsTracking = true,
            bool isDeleted = false,
            params string[] includes
            );

        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);
        Task SaveChangesAsync();
    }
}
