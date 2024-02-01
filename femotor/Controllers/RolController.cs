using femotor.Data;
using femotor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace femotor.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class RolController : Controller
    {

        private readonly FeMotorDBContext _context;

        public RolController(FeMotorDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Liste()
        {

            IEnumerable<Rolee> roleList = await _context.Rolees.ToListAsync();
            return View(roleList);
        }


        public async Task<IActionResult>Ekle()
        {
            Rolee x = new Rolee();
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("RoleeID,RoleeName")] Rolee rolee)
        {



            if (ModelState.IsValid)
            {
                await _context.AddAsync(rolee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Liste", "Rol");
            }

            return View(rolee);
        }
    }
}

