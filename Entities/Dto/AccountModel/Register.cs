
using System.ComponentModel.DataAnnotations;

namespace Entities.Dto.AccountModel
{
    public class Register :SuperRegister
    {
       

        [Required(ErrorMessage = "Şifre Gerekli!")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Şifreniz \"{0}\" uzunlukta {2} asdasd", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#.?*+%!]{8,15})$", ErrorMessage = "Şifreniz Minimum 8 karekter en az 1 büyük 1 küçük harf bir sayı ve bir özel karekter(@*#.?*+%!) içermeli")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrarı Gerekli!")]
        [Compare("Password", ErrorMessage = "Şifreler Aynı Değil !")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }



    }
}
