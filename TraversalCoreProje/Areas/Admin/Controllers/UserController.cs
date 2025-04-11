using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]

    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }



        public IActionResult Index()
        {
            var values = _appUserService.TGetList();

            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            using (var context = new Context())
            {
                var comments = context.Comments
                    .Where(x => x.AppUserID == id)
                    .Include(y => y.Destination)
                    .OrderByDescending(x => x.CommentDate) // Yorumları en son eklenenden en eskiye sıralar
                    .ToList();
                return View(comments);
            }

        }

        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
