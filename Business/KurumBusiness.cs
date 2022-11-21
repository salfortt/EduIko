  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using MongoDB.Bson;

namespace Business
{

   public class KurumBusiness
    {
        private KurumBusiness() { }
        private static KurumBusiness Instance;

        public static KurumBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new KurumBusiness();

            return Instance;
        }



        private KurumData _dalc;
        private KurumData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = KurumData.GetInstance();

                return _dalc;
            }
        }


        public int InsertKurum(Kurum k)
        {
            return dalc.InsertKurum(k);
        }
        public int InsertAccount(User k)
        {
            return dalc.InsertAccount(k);
        }

        public List<UserType> GetUserType()
        {
           return  dalc.GetUserType();
        }

        public User GetAccount(string u , string p)
        {
            return dalc.GetAccount(u,p);
        }


        public void  InsertAccountType(List<UserType> ut)
        {
            dalc.InsertAccountType(ut);
        }

        public User GetUser(ObjectId id)
        {
            return dalc.GetUser(id);
        }

        public List<User> GetUsersList()
        {
            return dalc.GetUsersList();
        }

        public void UpdateAccount(User u)
        {
            dalc.UserUpdate(u);
        }
        public void InsertYetki(YetkiTipi y)
        {
            dalc.InsertYetki(y);
        }

        public void InsertYetkiAlan(YetkiAlan ya)
        {
            dalc.InsertYetkiAlan(ya);
        }

        public List<YetkiAlan> GetYetkiAlan()
        {
            return dalc.GetYetkiAlan();
        }

        public List<YetkiTipi> GetYetkiTipi()
        {
            return dalc.GetYetkiTipi();
        }
    }
}
