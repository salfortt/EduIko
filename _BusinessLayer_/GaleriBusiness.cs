using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLayer
{
    public class GaleriBusiness
    {
        private GaleriBusiness() { }
        private static GaleriBusiness Instance;

        public static GaleriBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new GaleriBusiness();

            return Instance;
        }



        private GaleriData _dalc;
        private GaleriData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = GaleriData.GetInstance();

                return _dalc;
            }
        }

        public int GaleriInsert(SiteGaleri g) {

            dalc.InsertGaleriAdi(g);

            return 1;
        }
        public int GaleriUpdate(SiteGaleri g)
        {

            dalc.UpdateGaleri(g);

            return 1;
        }
        public List<SiteGaleri> GetGaleri()
        {



            return dalc.GetGaleri();
        }

        public SiteGaleri GetGaleriByID(string id)
        {
            return dalc.GetGaleriByID(id);
        }
    }
}
