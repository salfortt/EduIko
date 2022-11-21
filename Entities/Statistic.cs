using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace Entities
{
    public class Statistic
    {
        public ObjectId id { get; set; }
        public string MachineName { get; set; }
        public string Mac { get; set; }
        public string IP { get; set; }
        public string Domain { get; set; }
        public string UserName { get; set; }
        public DateTime _DateTime { get; set; }
        public string ContentID { get; set; }
        public string Home { get; set; }
       
    }
}
