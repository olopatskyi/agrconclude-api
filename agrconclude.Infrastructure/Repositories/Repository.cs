using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using agrconclude.Domain.Entities;
using agrconclude.Infrastructure.Data;

namespace agrconclude.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params string[] properties)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (properties != null)
        {
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(string id, params string[] props)
    {
        IQueryable<T> query = _dbSet;
        
        if (props != null)
        {
            foreach (var prop in props)
            {
                query = query.Include(prop);
            }    
        }

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
