using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin,Editor")]
    public class DashboardController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
