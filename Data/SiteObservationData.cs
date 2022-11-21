using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
    public  class SiteObservationData:MongoDocumentsDatabase
    {
        private SiteObservationData() { }
        private static SiteObservationData Instance;
        private const string collectionName = "log";
        public static SiteObservationData GetInstance()
        {
            if (Instance == null)
                Instance = new SiteObservationData();

            return Instance;
        }
    }
}
