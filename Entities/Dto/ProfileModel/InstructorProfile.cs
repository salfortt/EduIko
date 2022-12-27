using Entities.Dto.AccountModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.ProfileModel
{
    public class InstructorProfile : SuperProfile
    {

        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Web { get; set; }

        public List<string> Languages { get; set; }

		[Required(ErrorMessage = "Adres Gerekli!")]
		public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public String About { get; set; }
    }
}
