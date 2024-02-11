using Microsoft.AspNetCore.Mvc;
using SistemPemesananMakanan.Areas.Identity.Data;
using SistemPemesananMakanan.Models;

namespace SistemPemesananMakanan.Controllers
{
    public class MasterMenuController : Controller
    {
        private ApplicationContext db;

        public MasterMenuController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<MasterMenu> lsData = db.MasterMenu.ToList();
            return View(lsData);
        }
    }
}
