using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class AccountContact
    {
        public ObjectId id { get; set; }
        public ContactType Type { get; set; }
        public ContactInfo ContactInfo { get; set; }//tipe göre bilgiler buraya gelecek

        public bool IsActive { get; set; }
        public bool CommunicationPreference { get; set; }
    }
    [Serializable]
    public enum ContactType
    {
        phone = 0, address = 1, mail = 2
    }


    [Serializable]
    public class ContactInfo
    {



        public int Phone { get; set; }
        public string Mail { get; set; }
        public string Token { get; set; }//resetleme aramasında bulmak  için
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public bool IsRegistered { get; set; }
        public DateTime ActivatedDate { get; set; }


    }
}
