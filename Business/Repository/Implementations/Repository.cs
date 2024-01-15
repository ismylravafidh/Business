using Business.Common;
using Business.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Business.Repository.Interfaces;

namespace Business.Repository.Implementations
{
    public class Repository<Entity> : IRepository<Entity> where Entity : BaseEntity, new()
    {
        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<Entity> Table => _dbContext.Set<Entity>();
        public async Task<IQueryable<Entity>> GetAllAsync(Expression<Func<Entity, bool>>? expression = null, Expression<Func<Entity, object>>? orderbyExpression = null, bool isDescinding = false, params string[]? includes)
        {
            IQueryable<Entity> query = Table.Where(c => c.IsDeleted == false);
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderbyExpression != null)
            {
                query = isDescinding ? query.OrderByDescending(orderbyExpression) : query.OrderBy(orderbyExpression);
            }
            if (includes != null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }
        public async Task<Entity> GetByIdAsync(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task Create(Entity entity)
        {
            await Table.AddAsync(entity);
        }
        public async Task Update(Entity entity)
        {
            Table.Update(entity);
        }
        public async Task Delete(Entity entity)
        {
            Table.Update(entity);
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
