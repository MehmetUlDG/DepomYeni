using efCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace efCoreApp.Controllers
{
    public class MusteriController : Controller
    {
        private readonly DataContext _context;
        public MusteriController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Müsteri model)
        {

            _context.Müsteriler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }



    }
}
