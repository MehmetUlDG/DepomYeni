using System.Threading.Tasks;
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
        public IActionResult Create(Musteri musteri)
        {

            _context.Musteriler.Add(musteri);
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

            var musteri = await _context.Musteriler.FirstOrDefaultAsync(musteri => musteri.Id == Id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? Id, Musteri model)
        {
            if (Id != model.Id)
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
                    if (!_context.Musteriler.Any(m => m.Id == model.Id))
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

            var musteri = await _context.Musteriler.FirstOrDefaultAsync(musteri => musteri.Id == Id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);

    }
     [HttpPost]
      
public async Task<IActionResult> Delete(int Id)
{
    var musteri = await _context.Musteriler.FindAsync(Id);
    if (musteri == null)
    {
        return NotFound();
    }

    try
    {
        _context.Musteriler.Remove(musteri);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        
        return BadRequest($"Silme sırasında hata oluştu: {ex.Message}");
    }

    return RedirectToAction(nameof(Index));
}

}}