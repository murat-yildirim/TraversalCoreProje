using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    
    [Area("Member")]
    [Route("Member/Reservation")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("MyCurrentReservation")]
        public async Task< IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByAccepted(values.Id);
            return View(valuesList);
        }
        [Route("MyOldReservation")]
        public async Task< IActionResult> MyOldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByPrevious(values.Id);
            return View(valuesList);
        }
        [Route("MyAppprovalReservation")]
        public async Task<IActionResult> MyAppprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByWaitAprroval(values.Id);
            return View(valuesList);
        }

        [Route("NewReservation")]
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [Route("NewReservation")]
        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var user = await _userManager.GetUserAsync(User);
            p.AppUserId = user.Id;
            p.Status = "Onay Bekliyor";
            reservationManager.TAdd(p);
            return RedirectToAction("MyAppprovalReservation", "Reservation");
        }

        public IActionResult Deneme()
        {
            return View();
        }
    }
}
