using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.AccountModel
{
    public class SuperRegister
    {
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Telefon Numarası Gerekli!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen Geçerli Bir Numara Girin!.Başında '0' olmadan yazın")]
        // [Remote("IsAlreadySigned", "MVC_Redis.Controllers.Account", HttpMethod = "POST", ErrorMessage = "Bu Telefon Numarası Sistem Kayıtlı")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Ad Gerekli!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad Gerekli!")]
        public string LastName { get; set; }

        public int AccountType { get; set; }
    }
}
