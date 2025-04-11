using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index() // VERİTABANINDAKİ ROTALARI ROTALAR SAYFASINDA LİSTELEMEK İÇİN
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public async Task <IActionResult> DestinationDetails(int id) // ROTALAR SAYFASINDA TIKLADIĞI ROTANIN ID'SİNE GÖRE SAYFAYI GETİRMESİ İÇİN
        {

            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            if (value == null)
            {
                return RedirectToAction("SignIn", "Login");
            }
            ViewBag.i = id;
            ViewBag.destID = id;
            
            ViewBag.userID = value.Id;

            var values = destinationManager.TGetDestinationWithGuide(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination p) // GİDİLEN ROTALAR SAYFASINDA BİR İŞLEM YAPMASI İÇİN P PARAMETRESİ TANIMLANDI
        {

            return View();
        }
    }
}
