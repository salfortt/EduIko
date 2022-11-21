using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class YetkisizGiris
    {
        public User user { get; set; }
        public List<string> ServerData { get; set; }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
