using Business.ViewModels;

namespace Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<BlogGetVm>> GetAllAsync();
        Task<BlogGetVm> GetByIdAsync(int id);
        Task CreateAsync(BlogCreateVm createVm);
        Task UpdateAsync(BlogUpdateVm updateVm);
        Task DeleteAsync(int id);
    }
}
