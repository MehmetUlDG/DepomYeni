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
        public async Task<IActionResult> Index()
        {
            var musteriler = await _context.Musteriler.ToListAsync();
            return View(musteriler);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Musteri model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Musteriler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }



    }
}
