using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace BlogPage.Models
{
	public class UserRegisterViewModel
	{
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage="Adınızı giriniz")]
		public string Name { get; set; }
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Soyadınızı giriniz")]
		public string SurName { get; set; }
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Kullanıcı Adınızı giriniz")]
		public string UserName { get; set; }
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Mail Adresinizi giriniz")]
		public string Mail { get; set; }
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Şifrenizi giriniz")]
		public string Password { get; set; }
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Şifrenizi TekrarLayınız giriniz")]
		[Compare("Password",ErrorMessage ="Şifreler uyumlu değil")]
        public string RePassword { get; set; }
    }
}
