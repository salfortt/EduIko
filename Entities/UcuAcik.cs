using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Entities
{
   public class UcuAcik
    {
        public string Category { get; set; }
        public int Point { get; set; }
        public List<Words> Words { get; set; }
    }

    public class Words
    {
        public string Word { get; set; }
        public double Weight { get; set; }


    }
}
