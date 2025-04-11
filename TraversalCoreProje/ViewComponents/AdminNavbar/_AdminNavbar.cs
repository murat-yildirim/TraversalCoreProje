using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.AdminNavbar
{
    public class _AdminNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public _AdminNavbar(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
           
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();
                ViewBag.userName = user.Name + " " + user.Surname;
                ViewBag.userImage = user.ImageUrl;
                ViewBag.userRole = role ??  "Rol Yok";

            }
            else
            {
                ViewBag.userName = "Admin";
                ViewBag.userImage = "default.png";
                ViewBag.userRole = "Rol Atanmamış";
            }
            return View();
        }
    }
   
}
