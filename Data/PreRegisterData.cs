using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class PreRegisterData:MongoDocumentsDatabase
    {
        private PreRegisterData() { }
        private static PreRegisterData Instance;
        private const string collectionName = "Bursluluk";
        public static PreRegisterData GetInstance()
        {
            if (Instance == null)
                Instance = new PreRegisterData();

            return Instance;
        }

        public int InsertOnkayit(BurslulukKayit g)
        {
            return Insert(g, collectionName);
        }
    }
}
