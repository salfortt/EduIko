using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using MongoDB.Bson;

namespace BusinessLayer
{
 
    public class DuyuruBusiness
    {
        private DuyuruBusiness() { }
        private static DuyuruBusiness Instance;

        public static DuyuruBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new DuyuruBusiness();

            return Instance;
        }



        private DuyuruData _dalc;
        private DuyuruData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = DuyuruData.GetInstance();

                return _dalc;
            }
        }

        public void InsertDuyuru(Duyuru dy)
        {
            dalc.InsertDuyuru(dy);
        }

        public Duyuru GetByDuyuruID(ObjectId objectId)
        {
           return dalc.GetByDuyuruID(objectId);
        }

        public List<Duyuru> GetDuyuru()
        {
            return dalc.GetDuyuru();
        }

        public void UpdateDuyuru(Duyuru dy)
        {
            dalc.UpdateDuyuru(dy);
        }
        public void UpdateBulten(Duyuru dy)
        {
            dalc.UpdateBulten(dy);
        }

        public List<Duyuru> GetBulten()
        {
            return dalc.GetBulten();
        }

        public void InsertBulten(Duyuru dy)
        {
            dalc.InsertBulten(dy);
        }

        public List<Duyuru> GetDuyuruAndBulten()
        {
            return dalc.GetDuyuruAndBulten();
        }

     
    }
}
