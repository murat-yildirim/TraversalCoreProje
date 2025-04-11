using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")] //BURADA BİR ATTRİBUTE OLUŞTURUCAZ AREA İÇİN
   
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

       
        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = commentManager.TGetListUserComments(values.Id);
            return View(valuesList);
        }
    }
}
