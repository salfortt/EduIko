using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using MongoDB.Bson;

namespace Entities
{
    public class Setting
    {
        public ObjectId id { get; set; }
        public ObjectId kurumId { get; set; }
        public String key { get; set; }
        public String Value { get; set; }
       
    }
}
