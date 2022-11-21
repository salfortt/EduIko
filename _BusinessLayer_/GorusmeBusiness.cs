using DataAccessLayer;
using Entities;
using System.Data;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GorusmeBusiness
    {
        private GorusmeBusiness() { }
        private static GorusmeBusiness Instance;

        public static GorusmeBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new GorusmeBusiness();

            return Instance;
        }



        private GorusmeData _dalc;
        private GorusmeData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = GorusmeData.GetInstance();

                return _dalc;
            }
        }
        public int InsertGorusme(Gorusme g)
        {
            return dalc.InsertGorusme(g);
        }
 

        //public DataTable GetAllGorusme()
        //{
        //    return new DataTable();
        //}

        public List<Gorusme> GetGorusmeler()
        {
            return dalc.GetGorusmeler();
        }

        public Gorusme GetGorusmeByID(ObjectId id)
        {
            return dalc.GetGorusmeByID(id);
        }

     

        

        public int InsertGorusmeTipi(List<GorusmeTipi> lGorusmeTipi)
        {
            return dalc.InsertGorusmeTipi(lGorusmeTipi);
        }

        public List<Contact> GetContacts()
        {
            return dalc.GetContacts();
        }

        public List<BurslulukKayit> GetBursluluklar()
        {
            return dalc.GetBursluluklar();
        }

        public List<GorusmeTipi> GetGorusmeTipi()
        {
            return dalc.GetGorusmeTipi();
        }

        public Task<long> EditGorusmeByID(Gorusme g)
        {
            return dalc.EditGorusmeByID(g);
        }

        public BurslulukKayit GetBurslulukByID(ObjectId objectId)
        {
            return dalc.GetBurslulukByID(objectId);
        }

        public void UpdateBursluluk(BurslulukKayit g)
        {
            dalc.UpdateBursluluk(g);
        }
    }
}
