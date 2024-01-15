using Business.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.Repository.Interfaces
{
    public interface IRepository<Entity> where Entity : BaseEntity, new()
    {
        Task<IQueryable<Entity>> GetAllAsync(Expression<Func<Entity, bool>>? expression = null,
            Expression<Func<Entity, object>>? orderbyExpression = null,
            bool isDescinding = false,
            params string[]? includes);
        Task<Entity> GetByIdAsync(int id);
        Task Create(Entity entity);
        Task Update(Entity entity);
        Task Delete(Entity entity);
        Task SaveChangesAsync();
        DbSet<Entity> Table { get; }
    }
}
