using Business.Common;
using Business.Context;
using Business.Repository.Interfaces;

namespace Business.Repository.Implementations
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
