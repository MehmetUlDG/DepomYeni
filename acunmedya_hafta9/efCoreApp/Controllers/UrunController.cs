using System.Threading.Tasks;
using efCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace efCoreApp.Controllers
{

    public class UrunController : Controller
    {
        private readonly DataContext _context;

        public UrunController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var urunler = await _context.Urunler.ToListAsync();
            return View(urunler);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Urun urun)
        {
            urun.UrunBarkod = Guid.NewGuid();
            _context.Urunler.Add(urun);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunler.FirstOrDefaultAsync(urunler => urunler.UrunId == Id);
            if (urunler == null)
            {
                return NotFound();
            }
            return View(urunler);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? Id, Urun model)
        {
            if (Id!= model.UrunId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Musteriler.Any(m => m.Id == model.UrunId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

           
            return View(model);
        }
         [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunler.FirstOrDefaultAsync(urunler => urunler.UrunId==Id);
            if (urunler == null)
            {
                return NotFound();
            }
            return View(urunler);

    }
     [HttpPost]
      
public async Task<IActionResult> Delete(int Id)
{
    var urunler = await _context.Urunler.FindAsync(Id);
    if (urunler == null)
    {
        return NotFound();
    }

    try
    {
        _context.Urunler.Remove(urunler);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        
        return BadRequest($"Silme sırasında hata oluştu: {ex.Message}");
    }

    return RedirectToAction(nameof(Index));
}

}}