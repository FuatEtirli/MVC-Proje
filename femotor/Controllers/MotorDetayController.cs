using femotor.Data;
using femotor.Models;
using femotor.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace femotor.Controllers
{

    public class MotorDetayController : Controller
    {

        private readonly FeMotorDBContext _context;

        public MotorDetayController(FeMotorDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            MotorDetailViewModel x = new MotorDetailViewModel();
            x.motor = await _context.Motors.FirstOrDefaultAsync(a => a.MotorID == id);
            
            return View(x);
        }
        
    }

       
        
    
}
