using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SubscriptionData : MongoDocumentsDatabase
    {
        private SubscriptionData() { }
        private static SubscriptionData Instance;
        private const string collectionName = "Subscription";
        private const string collectionNameSubscriptionType = "SubscriptionType";

        public static SubscriptionData GetInstance()
        {
            if (Instance == null)
                Instance = new SubscriptionData();

            return Instance;
        }
        public List<SubscriptionType> GetSubscriptionTypes()
        {
            return GetToList<SubscriptionType>(collectionNameSubscriptionType);
        }

    }
}
