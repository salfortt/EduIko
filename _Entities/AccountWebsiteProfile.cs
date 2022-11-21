using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class AccountWebsiteProfile
    {
        public ObjectId id { get; set; }

        public ObjectId FK_AccountID { get; set; }
        public string About { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Motto { get; set; }
        public string MottoOwner { get; set; }
        public string ProfilePicPath { get; set; }
    }
}
