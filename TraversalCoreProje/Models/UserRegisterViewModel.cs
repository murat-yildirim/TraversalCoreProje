﻿using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Lütfen Mail Adresini Giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi Giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
		[Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil")]//Kayıt olurken şifre uyumsuzluğu hatası
		public string ConfirmPassword { get; set; }
	}
}
