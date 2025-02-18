using Avatar_Challenge.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Avatar_Challenge.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }




        public async Task<IActionResult> Index()
        {

            var items = await _context.Item.Include(s => s.SerialNumber).ToListAsync();



            return View(items);
        }
    }
}
