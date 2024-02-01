using Microsoft.AspNetCore.Mvc;

namespace femotor.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Liste()
        {
            return View();
        }
    }
}
