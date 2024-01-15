
using Business.Services.Interfaces;
using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _service;

        public HomeController(IBlogService blogService)
        {
            _service = blogService;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogGetVm> list = await _service.GetAllAsync();
            return View(list);
        }
    }
}
