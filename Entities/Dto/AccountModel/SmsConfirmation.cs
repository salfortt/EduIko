using System.ComponentModel.DataAnnotations;

namespace Entities.Dto.AccountModel
{
    public class SmsConfirmation
    {
        public string PhoneNumber { get; set; }

        [StringLength(8, ErrorMessage = "Şifreniz \"{0}\" uzunlukta {2} Olmalı", MinimumLength = 8)]
        public string SmsCode { get; set; }
    }
}
