using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Account
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public List<ObjectId> FK_CompaniesID { get; set; } //   merkez ve şubeler
        public AccountTypeEnum Type { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PicturePath { get; set; }
        public bool IsActive { get; set; } = true;

    }
    [Serializable]
    public class AccountInfo
    {
        public ObjectId id { get; set; }
        public ObjectId FK_AccountID { get; set; }
        public int Sort { get; set; }
        public List<string> NotifyIDs { get; set; } = new List<string>();
        public Int64 TCNo { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public List<ObjectId> FK_AccountRelationIDs { get; set; }  // Çoklu veli ya da öğrenci seçeneğini ayarlas
        public List<Contact> Contacts { get; set; }
        public List<ObjectId> Classes { get; set; }
        public List<string> Branches { get; set; }
        public AccountCV CV { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public DateTime DeleteDate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool AcsessSite { get; set; } = false;
    }
    [Serializable]
    public enum GenderType
    {
        girl = 1, male = 2
    }


    [Serializable]
    public enum AccountTypeEnum
    {
        admin = -11, student = 1, gardian/*onura sor*/ = 2, officer = 3, staff = 4, technician = 5, teacher = 6, assistantDirector = 7, director = 8, founder = 9

    }


}
