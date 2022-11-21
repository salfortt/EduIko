using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
   public class CommonData : MongoDocumentsDatabase
    {
        private CommonData() { }
        private static CommonData Instance;
        public static CommonData GetInstance()
        {
            if (Instance == null)
                Instance = new CommonData();

            return Instance;
        }

        public DataTable GetSinif()
        {
            throw new NotImplementedException();
        }

        public DataTable GetOkul()
        {
            throw new NotImplementedException();
        }

        public int InsertOgrenci(Ogrenci o)
        {
            throw new NotImplementedException();
        }

        public DataTable OgrenciGetAll()
        {
            throw new NotImplementedException();
        }

        public DataTable GetKayitByTC(string mail, string pass)
        {
            throw new NotImplementedException();
        }

        public DataTable GetOgrenciByID(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetCinsiyet()
        {
            throw new NotImplementedException();
        }

        public int UpdateKayit(Ogrenci o)
        {
            throw new NotImplementedException();
        }

        public DataTable GetCariHareketTipi()
        {
            throw new NotImplementedException();
        }

        public DataTable GetUyeTipi()
        {
            throw new NotImplementedException();
        }

        public DataTable GetUyeByType(string selectedValue)
        {
            throw new NotImplementedException();
        }

        public DataSet GetSiteData()
        {
            throw new NotImplementedException();
        }

        public void InsertRehberlik(string url, string title, string desc, string tags, string article)
        {
            throw new NotImplementedException();
        }

        public void InsertBlog(string url, string title, string desc, string tags, string article)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllDers()
        {
            throw new NotImplementedException();
        }

        public int InsertBulkDersProgrami(DataTable dtProgram)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllArticle()
        {
            throw new NotImplementedException();
        }

        public void DeleteOgrenciByID(string ogrenciID)
        {
            throw new NotImplementedException();
        }
    }
}
