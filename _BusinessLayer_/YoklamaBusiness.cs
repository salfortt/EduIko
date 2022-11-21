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

   public class YoklamaBusiness
    {
        private YoklamaBusiness() { }
        private static YoklamaBusiness Instance;

        public static YoklamaBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new YoklamaBusiness();

            return Instance;
        }



        private YoklamaData _dalc;
        private YoklamaData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = YoklamaData.GetInstance();

                return _dalc;
            }
        }


        public int InsertYoklama(Yoklama y)
        {
            return dalc.InsertYoklama(y);

        }

        public Yoklama GetYoklamaById(ObjectId objectId)
        {
            return dalc.GetYoklamaById(objectId);
        }

        public void DeleteYoklamaById(ObjectId objectId)
        {
             dalc.DeleteYoklamaById(objectId);
        }

        public List<Yoklama> GetYoklamaList(string gradeDay, string classId)
        {
            return dalc.GetYoklamaList(gradeDay, classId);
        }

        public void UpdateYoklamaByID(Yoklama y)
        {
            dalc.UpdateYoklamaByID(y);
        }
    }
}
