using AutoMapper;
using Business.Common;
using Business.Helpers;
using Business.Migrations;
using Business.Repository.Interfaces;
using Business.Services.Interfaces;
using Business.ViewModels;

namespace Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public BlogService(IBlogRepository repository,IMapper mapper,IWebHostEnvironment environment)
        {
            _repository = repository;
            _mapper = mapper;
            _environment = environment;
        }
        public async Task<List<BlogGetVm>> GetAllAsync()
        {
            IQueryable<Blog> blogs = await _repository.GetAllAsync();
            if (blogs==null) throw new Exception();
            List<BlogGetVm> result = new List<BlogGetVm>();
            foreach (Blog blog in blogs)
            {
                result.Add(_mapper.Map<BlogGetVm>(blog));
            }
            return result;

        }
        public async Task<BlogGetVm> GetByIdAsync(int id)
        {
            Blog blog = await _repository.GetByIdAsync(id);
            if (blog==null) throw new Exception();
            BlogGetVm getVm = _mapper.Map<BlogGetVm>(blog);
            return getVm;
        }
        public async Task CreateAsync(BlogCreateVm createVm)
        {
            if (createVm == null) throw new ArgumentNullException();

            if(!createVm.ImgFile.ContentType.Contains("image")) throw new Exception("Yalniz Image Yukleye Bilersiz");
            if (createVm.ImgFile.Length > 3000 * 1024) throw new Exception("Sekil 3 MB-dan boyuk olammaz");

            createVm.ImgUrl = createVm.ImgFile.Upload(_environment.WebRootPath, "/Upload/BlogImage/");

            Blog blog = _mapper.Map<Blog>(createVm);
            await _repository.Create(blog);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(BlogUpdateVm updateVm)
        {
            if(updateVm == null) throw new ArgumentNullException();

            if(updateVm.ImgFile != null)
            {
                if (!updateVm.ImgFile.ContentType.Contains("image")) throw new Exception("Yalniz Image Yukleye Bilersiz");
                if (updateVm.ImgFile.Length > 3000 * 1024) throw new Exception("Sekil 3 MB-dan boyuk olammaz");

                updateVm.ImgUrl.DeleteFile(_environment.WebRootPath, "/Upload/BlogImage/");

                updateVm.ImgUrl = updateVm.ImgFile.Upload(_environment.WebRootPath, "/Upload/BlogImage/");
            }
            Blog oldBlog = _mapper.Map<Blog>(await GetByIdAsync(updateVm.Id));
            _mapper.Map(updateVm, oldBlog);
            await _repository.Update(oldBlog);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Blog oldBlog = _mapper.Map<Blog>(await GetByIdAsync(id));
            oldBlog.IsDeleted = true;
            await _repository.Delete(oldBlog);
            await _repository.SaveChangesAsync();
        }
    }
}
