using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  
    public class Rapor
    {

        public string Name { get; set; }
        public string Date { get; set; }
        public int Count { get; set; }


    }

    public class ToplamRapor
    {

        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
        public int Count { get; set; }



    }

}
