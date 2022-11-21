using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using Common;

namespace Business
{
    public class SiteSettings
    {

        private static Dictionary<string, Setting> _settings;
        private static Dictionary<string, Setting> settings
        {
            get
            {
                if (_settings == null)
                {
                    SiteSettingsDALC dalc = new SiteSettingsDALC();
                    _settings = dalc.LoadSettings();
                }
                return _settings;
            }
        }
        private const string http = "http://";
        private const string https = "https://";
        private static SiteSettings Instance;
        public SiteSettings()
        {
            LoadOgrenciler();
        }

      

        private void LoadOgrenciler()
        {
            if (Ogrenciler == null || Ogrenciler.Count == 0)
            {
                Ogrenciler = FillOgrenciler();

            }
        }

       
       
        //Dictionary<long, List<string>> _summary;

        //public Dictionary<long, List<string>> Summary
        //{
        //    get { return _summary; }
        //    set
        //    {
        //        _summary = value;

        //        foreach (var member in Members)
        //        {
        //            List<string> list;
        //            if (_summary.TryGetValue(member.objectId, out list))
        //            {
        //                if (member.summary == null)
        //                    member.summary = new List<string>();
        //                member.summary.AddRange(list);
        //            }
        //        }
        //    }
        //}

        public static Dictionary<ObjectId, List<User>> _ogrenciler;


        public static Dictionary<ObjectId, List<User>> Ogrenciler
        {

            get { return _ogrenciler; }
            set
            {
                _ogrenciler = value;


                List<User> liste = SiteSettingsDALC.GetInstance().GetOgrenciler();//SezonGet.GetInstance().SezonName


                _ogrenciler =liste.GroupBy(x => x.FK_ClassId).ToDictionary(g => g.Key, g => g.Select(x => x).ToList());
                }




            //get { return _ogr; }
            //set
            //{
            //    Ogrenciler = value;

            //    foreach (User item in SiteSettingsDALC.GetInstance().GetOgrenciler())
            //    {
            //        List<User> list;
            //        if (Ogrenciler.TryGetValue(item.KurumIlgisi.FirstOrDefault().FK_ClassId, out list))
            //        {
            //            if (item.KurumIlgisi.FirstOrDefault().FK_ClassId == null)
            //                item.KurumIlgisi= new List<IlgiTipi>();
            //            list.Add(item);
            //        }
            //    }
         


    
        }

        public void UpdateMenu(List<Menu> tmp)
        {
            dalc.UpdateMenu(tmp);
        }

        public void InsertKisiler(List<Kisi> kisiler)
        {
            dalc.InsertKisiler(kisiler);
        }

        public void InsertSMSMessages(List<MessageSMS> lmes)
        {
            dalc.InsertSMSMessages(lmes);
        }

        public List<MessageSMS> GetSMSMessages()
        {
            return dalc.GetSMSMessages();
        }
        public void UpdateKisi(Kisi item)
        {
            dalc.UpdateKisi(item);
        }
        public Dictionary<ObjectId, List<User>> FillOgrenciler()
        {
             
            List<User> liste = SiteSettingsDALC.GetInstance().GetOgrenciler();//SezonGet.GetInstance().SezonName


            _ogrenciler = liste.GroupBy(x => x.FK_ClassId).ToDictionary(g => g.Key, g => g.Select(x => x).ToList());

            return Ogrenciler;
        }

        public void FlushOgrenciler()
        {

            Ogrenciler = null;
        }
        public static SiteSettings GetInstance()
        {
            if (Instance == null)
                Instance = new SiteSettings();
            return Instance;
        }


        SiteSettingsDALC dalc = new SiteSettingsDALC();

        public List<User> GetAllUser()
        {
            return SiteSettingsDALC.GetInstance().GetUsers();
        }
 
        public List<Menu> GetMenuList()
        {
            return dalc.GetMenuList(); //statik datay çek */************//////////////////
        }

        public List<Grade> GetSiniflar(string sezon)
        {
            return dalc.GetSiniflar(sezon);  
        }
        public List<Grade> GetSiniflarByKurumID(ObjectId kurumID)
        {

            //if (Siniflar == null)//burayo session a taşımalı

            //}
            return dalc.GetSiniflarByKurumID(kurumID);
        }


        public List<User> GetOgrenciByClassID(ObjectId classId) 
        {
            return Ogrenciler[classId];
        }

        public void UpdateSMSMessage(MessageSMS m)
        {
            dalc.UpdateSMSMessage(m);
        }

        public Dictionary<ObjectId, List<User>> GetAllOgrenci()
        {
            List<User> liste = SiteSettingsDALC.GetInstance().GetOgrenciler();//SezonGet.GetInstance().SezonName
             
            return liste.GroupBy(x => x.FK_ClassId).ToDictionary(g => g.Key, g => g.Select(x => x).ToList());
        }


        public int InsertMenu(Menu m)
        {
            return dalc.InsertMenu(m);
        }

        public string HtmlTemplate_Css
        {
            get { return settings["HtmlTemplate.Css"].Value; }
        }

        public void InsertLookedUpDB(LookedUp lup)
        {
            dalc.InsertLookedUpDB(lup);
        }
    }
}
