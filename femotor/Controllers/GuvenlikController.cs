using femotor.Data;
using femotor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace femotor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class GuvenlikController : Controller
    {
        private readonly FeMotorDBContext _context;

        public GuvenlikController(FeMotorDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Yetkilendirme()
        {
            IEnumerable<Userr> userList = await _context.Userrs.Include(a=>a.Rolee).Where(a=>a.RoleeID==2 || a.RoleeID == 3).ToListAsync();
            return View(userList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdmindenCikar(int id)
        {
            Userr selectedUser = await _context.Userrs.FirstOrDefaultAsync(a => a.UserrID == id);

            selectedUser.RoleeID = 2;

            _context.Userrs.Update(selectedUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Yetkilendirme", "Guvenlik");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminYap(int id)
        {
            Userr selectedUser = await _context.Userrs.FirstOrDefaultAsync(a => a.UserrID == id);

            selectedUser.RoleeID = 3;

            _context.Userrs.Update(selectedUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Yetkilendirme", "Guvenlik");

        }


    }
}
