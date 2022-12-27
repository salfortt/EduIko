using Entities.Dto.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.ProfileModel
{
    public class SuperProfile:SuperRegister
    {
        public int id { get; set; }
        public string PhotoPath { get; set; }

        public string Email { get; set; }
    }
}
