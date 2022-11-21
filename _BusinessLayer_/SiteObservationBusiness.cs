using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
   
    public class SiteObservationBusiness
    {
        private SiteObservationData _dalc;
        private SiteObservationData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = SiteObservationData.GetInstance();

                return _dalc;
            }
        }
        private SiteObservationBusiness() { }
        private static SiteObservationBusiness Instance;
        public static SiteObservationBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new SiteObservationBusiness();

            return Instance;
        }
    }
}
