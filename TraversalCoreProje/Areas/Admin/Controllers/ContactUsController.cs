using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class ContactUsController : Controller
	{
		private readonly IContactUsService _contactUsService;

		public ContactUsController(IContactUsService contactUsService)
		{
			_contactUsService = contactUsService;
		}

		public IActionResult Index()
		{
			var values = _contactUsService.TGetListContactUsByTrue();
			return View(values);
		}

		public IActionResult OpenIncomingMessage(int id)
		{
			using (var context = new Context())
			{
				var comments = context.ContactUses
					.Where(x => x.ContactUsID == id).ToList();
				return View(comments);
			}
		}

		
	}
}
