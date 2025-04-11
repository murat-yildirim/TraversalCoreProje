using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous] //ALTINADA BULUNAN BÜTÜN KODLARI GEÇERLİ BÜTÜN KURALLARDAN MUAF TUTUYOR
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager; //LOGİN İŞLEMİ İÇİN



        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp() //KAYIT OLMAK İÇİN KULLANILACAK
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName

            };


            //ŞİFRE ARKA TARAFTA HASH'LENEREK GÖNDERİLECEĞİ İÇİN BURADA KONTROL EDİYORUZ
            // VE ASYNC METOT KULLANIYORUZ
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "Member"); //KAYIT OLUNCA ROLÜNÜ VERİYORUZ

                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn() //LOGİN İŞLEMİ İÇİN
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, true, true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(p.username);
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin") || roles.Contains("Editor"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Profile", new { area = "Member" });
                    }
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Login");
        }
    }
}
