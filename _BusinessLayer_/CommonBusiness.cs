using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CommonBusiness
    {
        private CommonData _dalc;
        private CommonData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = CommonData.GetInstance();

                return _dalc;
            }
        }
        private CommonBusiness() { }
        private static CommonBusiness Instance;
        public static CommonBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new CommonBusiness();

            return Instance;
        }

        public DataTable GetAllSinif()
        {
            return dalc.GetSinif(); ;
        }

        public DataTable GetAllOkul()
        {
            return dalc.GetOkul();
        }


        public int InsertOgrenci(Ogrenci o)
        {
            return dalc.InsertOgrenci(o);
        }

        public DataTable OgrenciGetAll()
        {
            return dalc.OgrenciGetAll();
        }

        public DataTable GetKayitByTC(string mail, string pass)
        {
            return dalc.GetKayitByTC(mail, pass);
        }

        public DataTable GetOgrenciByID(int id)
        {
            return dalc.GetOgrenciByID(id);
        }

        public DataTable GetCinsiyet()
        {
            return dalc.GetCinsiyet();
        }


        public int UpdateKayit(Ogrenci o)
        {
            return dalc.UpdateKayit(o);
        }

        public DataTable GetCariHareketTipi()
        {
            return dalc.GetCariHareketTipi();
        }

        public DataTable GetUyeTipi()
        {
            return dalc.GetUyeTipi();
        }

        public DataTable GetUyeByType(string selectedValue)
        {
            return dalc.GetUyeByType(selectedValue);
        }

        public DataSet GetSiteData()
        {
            return dalc.GetSiteData();
        }

        public void InsertRehberlik(string url, string title, string desc, string tags, string article)
        {
            dalc.InsertRehberlik(url, title, desc, tags, article);
        }

        public void InsertBlog(string url, string title, string desc, string tags, string article)
        {
            dalc.InsertBlog(url, title, desc, tags, article);
        }
        public DataTable GetAllArticle()
        {
            return dalc.GetAllArticle();
        }

        public DataTable GetAllDers()
        {
            return dalc.GetAllDers();
        }

        public int InsertBulkDersProgrami(DataTable dtProgram)
        {
            return dalc.InsertBulkDersProgrami(dtProgram);
        }

        public void DeleteOgrenciByID(string ogrenciID)
        {
            dalc.DeleteOgrenciByID(ogrenciID);
        }
    }
}
