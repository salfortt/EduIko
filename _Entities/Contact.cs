using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Contact
    {
        public ObjectId id { get; set; }
        public string name_contact { get; set; }
        public string lastname_contact { get; set; }
        public string email_contact { get; set; }
        public string phone_contact { get; set; }
        public string message_contact { get; set; }
 
        public DateTime message_date { get; set; }
    }

   
}
