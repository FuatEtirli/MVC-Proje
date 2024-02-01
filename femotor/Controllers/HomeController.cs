using femotor.Models;
using femotor.Data;
using femotor.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace femotor.Controllers
{
    public class HomeController : Controller
    {


        private readonly FeMotorDBContext _context;

        public HomeController(FeMotorDBContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Liste(int motorid,int kat, Motor motor ,BodyType bodytype)

        {
            HomeViewModel x = new HomeViewModel();
            
            x.MotorList = await _context.Motors.ToListAsync();

            x.BodyTypeList = await _context.BodyTypes.ToListAsync();
           

            if (kat > 0)
            {
                x.MotorList = await _context.Motors
                .Where(a=>a.BodyTypeID == kat)
                .ToListAsync();

                return View (x);
            }


            return View(x);        
        }

        public IActionResult Servis()
        {
            return View();
        }


        public IActionResult Hakkımızda()
        {
            return View();
        }


        public IActionResult Iletisim()
        {
            return View();
        }


    }


}