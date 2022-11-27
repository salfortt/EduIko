using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Redis.Models.Account
{
	public class Register
	{
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Telefon Numarası")]
		[Required(ErrorMessage = "Telefon Numarası Gerekli!")]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen Geçerli Bir Numara Girin!.Başında '0' olmadan yazın")]
        [Remote("IsAlreadySigned", "Account", HttpMethod = "POST", ErrorMessage = "Bu Telefon Numarası Sistem Kayıtlı")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Şifre Gerekli!")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#.?*+%!]{8,15})$", ErrorMessage = "Şifreniz Minimum 8 karekter en az 1 büyük 1 küçük harf bir sayı ve bir özel karekter(@*#.?*+%!) içermeli")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrarı Gerekli!")]
        [Compare("Password", ErrorMessage = "Şifreler Aynı Değil !")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "Ad Gerekli!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad Gerekli!")]
        public string LastName { get; set; }

        public int AccountType { get; set; }

    }
}
