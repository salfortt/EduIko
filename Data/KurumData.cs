using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;

namespace Data
{
  public  class KurumData :MongoDocumentsDatabase
    {


        private KurumData() { }
        private static KurumData Instance;
        private const string collectionName = "Kurum";
        public static KurumData GetInstance()
        {
            if (Instance == null)
                Instance = new KurumData();

            return Instance;
        }

        public List<YetkiTipi> GetYetkiTipi()
        {
            throw new NotImplementedException();
        }

        public List<YetkiAlan> GetYetkiAlan()
        {
            throw new NotImplementedException();
        }

        public void InsertYetkiAlan(YetkiAlan ya)
        {
            throw new NotImplementedException();
        }

        public int InsertKurum(Kurum k)
        {
            return Insert(k, collectionName);
        }

        public int InsertAccount(User k)
        {
            throw new NotImplementedException();
        }

        public void InsertYetki(YetkiTipi y)
        {
            throw new NotImplementedException();
        }

        public List<UserType> GetUserType()
        {
            throw new NotImplementedException();
        }

        public void UserUpdate(User u)
        {
            throw new NotImplementedException();
        }

        public User GetAccount(string u, string p)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersList()
        {
            throw new NotImplementedException();
        }

        public void InsertAccountType(List<UserType> ut)
        {
            throw new NotImplementedException();
        }

        public User GetUser(ObjectId id)
        {
            throw new NotImplementedException();
        }
    }
}
