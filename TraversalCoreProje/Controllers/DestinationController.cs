using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index() // VERİTABANINDAKİ ROTALARI ROTALAR SAYFASINDA LİSTELEMEK İÇİN
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet] 
        public IActionResult DestinationDetails(int id) // ROTALAR SAYFASINDA TIKLADIĞI ROTANIN ID'SİNE GÖRE SAYFAYI GETİRMESİ İÇİN
        {
            ViewBag.i = id;
            var values =destinationManager.TGetByID(id);
            return View(values);
        }

        [HttpPost] 
        public IActionResult DestinationDetails(Destination p) // GİDİLEN ROTALAR SAYFASINDA BİR İŞLEM YAPMASI İÇİN P PARAMETRESİ TANIMLANDI
        {
            return View();
        }
    }
}
