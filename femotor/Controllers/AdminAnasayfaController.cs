using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace femotor.Controllers
{

    
    public class AdminAnasayfaController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
