using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar :ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            ViewBag.UserName = user?.Name;
            ViewBag.UserSurname = user?.Surname;
            return View();
        }
    }
}
