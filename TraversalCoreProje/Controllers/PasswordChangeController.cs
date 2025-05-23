﻿using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","traversalcore2@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom); //kimden geldiği bilgisi

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
			mimeMessage.To.Add(mailboxAddressTo); //gidecek olan kişi bilgileri ekleniyor

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody=passwordResetTokenLink;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

			mimeMessage.Subject="Şifre Değişiklik Talebi";

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

        [HttpGet]
        public IActionResult ResetPassword(string userid , string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if(userid==null || token==null)
            {
                //hata mesajı
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user,token.ToString(),resetPasswordViewModel.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
;            }
            return View();
        }
    }
}
