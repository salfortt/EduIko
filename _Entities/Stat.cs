using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace Entities
{
    public   class Stat
    {
        public string _id{ get; set; }
        public string ContentID { get; set; }
        public int Count { get; set; }
    }
}
