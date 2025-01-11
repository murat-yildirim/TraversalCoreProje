using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(MailRequest mailRequest)
		{
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","traversalcore2@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom); //kimden geldiği bilgisi

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo); //gidecek olan kişi bilgileri ekleniyor

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody=mailRequest.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject=mailRequest.Subject;

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			//Buradaki şifre ve mail veritabanından alınması gerekiyor denem için yazılmıştır
			//Buradaki yazılan şifreyi google kabul etmiyor gmail ayarları yapıldıktan sonra
			//bize verdiği şifreyi buraya yazıyoruz
			client.Authenticate("traversalcore2@gmail.com", "123456+");
			client.Send(mimeMessage);
			client.Disconnect(true);

			return View();
		}
	}
}
