using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class AccountCredit
    {

        public ObjectId FK_SubscriptionTypeID { get; set; }
        public ObjectId FK_AccountID { get; set; } = ObjectId.Parse("000000000000000000000000");
        public string SubscriptionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        //    public PaymentTypeEnum PaymentTypeEnum { get; set; }

    }
    //[Serializable]
    //public enum PaymentTypeEnum
    //{
    //    Cash = 0, Taksit = 1//ingilizcesini onura sor

    //}
}
