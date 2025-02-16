using Avatar_Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Avatar_Challenge.Dtos;
using Avatar_Challenge.Data;
using Microsoft.EntityFrameworkCore;

namespace Avatar_Challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        private readonly string[] allowedExtensions = { ".docx", ".pdf", ".txt", ".jpg", ".jpeg", ".png", ".webp" };

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var avatars = await _context.Avatars.ToListAsync();

            return View(avatars);

        }


        [HttpGet]
        public async Task<IActionResult> CreateChallenge()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChallenge(AvatarDto model)
        {


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //allowed extension checks

            string extension = Path.GetExtension(model.FormFile.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                return View(model);
            }

            //file saving (security considerations)

            string fnamewithoutextension = Path.GetFileNameWithoutExtension(model.FormFile.FileName);

            string uuid = Guid.NewGuid().ToString();

            string securefilename = $"{fnamewithoutextension}_{uuid}{extension}";

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            var fullpath = Path.Combine(filepath, securefilename);


            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }



            using (var fs = new FileStream(fullpath, FileMode.Create))
            {
                await model.FormFile.CopyToAsync(fs);
            }


            //saving now to db

            AvatarModel avatarModel = new AvatarModel() { FullNames = model.FullNames, Email = model.Email, RegistrationNumber = model.RegistrationNumber, AvatarName = securefilename };

            _context.Avatars.Add(avatarModel);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //

        /*
         * Delete and Edit route
         */

        public async Task<IActionResult> DeleteAvatar(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var avatar = await _context.Avatars.FirstOrDefaultAsync(a => a.Id == id);

            if (avatar != null)
            {
                _context.Avatars.Remove(avatar);
                await _context.SaveChangesAsync();
            }

        
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
