using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Reservation")]
    [Authorize(Roles = "Admin,Editor")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            using (var context = new Context())
            {
                var comments = context.Reservations
                    .Where(x=>x.Status=="Onay Bekliyor")
                    .Include(y => y.Destination)
                    .Include(x => x.AppUser)
                    .ToList();
                return View(comments);
            }
           
        }
        [Route("ReservationDetail/{id}")]
        public IActionResult ReservationDetail(int id)
        {
            using (var context = new Context())
            {
                var comments = context.Reservations
                    .Where(x => x.ReservationID == id)
                    .Include(y => y.Destination)
                    .Include(x => x.AppUser)
                    .ToList();
                return View(comments);
            }
        }
        [Route("ChangeStatusApproved/{id}")]
        public IActionResult ChangeStatusApproved(int id)
        {
            _reservationService.ChangeStatusApproved(id);
            return RedirectToAction("Index", "Reservation");
        }
        [Route("ApprovedIndex")]
        public IActionResult ApprovedIndex()
        {
            using (var context = new Context())
            {
                var comments = context.Reservations
                    .Where(x => x.Status == "Onaylandı")
                    .Include(y => y.Destination)
                    .Include(x => x.AppUser)
                    .ToList();
                return View(comments);
            }
        }
        [Route("PreviousIndex")]
        public IActionResult PreviousIndex()
        {
            using (var context = new Context())
            {
                var comments = context.Reservations
                    .Where(x => x.Status == "Geçmiş Rezervasyon")
                    .Include(y => y.Destination)
                    .Include(x => x.AppUser)
                    .ToList();
                return View(comments);
            }
        }


        [Route("ChangeStatusPassivation/{id}")]
        public IActionResult ChangeStatusPassivation(int id)
        {
            _reservationService.ChangeStatusPassivation(id);
            return RedirectToAction("Index", "Reservation");
        }


        [Route("PassivationIndex")]
        public IActionResult PassivationIndex()
        {
            using (var context = new Context())
            {
                var comments = context.Reservations
                    .Where(x => x.Status == "İptal Edildi")
                    .Include(y => y.Destination)
                    .Include(x => x.AppUser)
                    .ToList();
                return View(comments);
            }
        }
    }
}
