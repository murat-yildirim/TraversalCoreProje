using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebar : ViewComponent
    {
        private readonly Context context;

        public _AdminLayoutSidebar(Context context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.MessageCount = context.Announcements.Count();
            ViewBag.ActiveReservation = context.Reservations.Where(x => x.Status == "Onay Bekliyor")
                .Count();
            return View();
        }
    }

}
