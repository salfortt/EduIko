using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SubscriptionBusiness
    {

        private SubscriptionBusiness() { }
        private static SubscriptionBusiness Instance;

        public static SubscriptionBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new SubscriptionBusiness();

            return Instance;
        }



        private SubscriptionData _dalc;
        private SubscriptionData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = SubscriptionData.GetInstance();

                return _dalc;
            }
        }

        public List<SubscriptionType> GetSubscriptionTypes()
        {
            return dalc.GetSubscriptionTypes();
        }
    }
}
