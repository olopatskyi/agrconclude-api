using System.Linq.Expressions;
using agrconclude.Domain.Entities;

namespace agrconclude.Infrastructure.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, params string[] properties);

    Task<T?> GetByIdAsync(string id, params string[] props);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task SaveAsync();
}