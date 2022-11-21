using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Entities
{
   public  class BlogPost
    {

        public ObjectId id { get; set; }
        public ObjectId UserId { get; set; }
        public string Title { get; set; }
        public string Owner { get; set; }
        public string URL { get; set; }//title+20170618 date Paremetresi
        public string Description { get; set; }

        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAccessed { get; set; }

        public List<LookedUp> Onaylayanlar { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Tags { get; set; }
  
    }
}
