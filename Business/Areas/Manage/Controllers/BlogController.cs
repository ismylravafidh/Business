using AutoMapper;
using Business.Services.Interfaces;
using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Business.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BlogController : Controller
    {
        private readonly IBlogService _service;
        private readonly IMapper _mapper;

        public BlogController(IBlogService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<BlogGetVm> list = await _service.GetAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateVm createVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.CreateAsync(createVm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            BlogUpdateVm blog = _mapper.Map<BlogUpdateVm>(await _service.GetByIdAsync(id));
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateVm updateVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.UpdateAsync(updateVm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
