using DataAccessLayer;
using Entities;
using System.Data;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RehberlikBusiness
    {
     
        private RehberlikBusiness() { }
        private static RehberlikBusiness Instance;

        public static RehberlikBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new RehberlikBusiness();

            return Instance;
        }



        private RehberlikData _dalc;
        private RehberlikData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = RehberlikData.GetInstance();

                return _dalc;
            }
        }
          
        public int InsertRehberlik(Rehberlik r)
        {
            return dalc.InsertRehberlik(r);
        }

        public List<ObjectId> GetOgrenciTanitimFormu()
        {
            return dalc.GetOgrenciTanitimFormu();
        }
        public List<ObjectId> GetOgrenciTanitimFormuByStudentIDs(List<ObjectId> ids)
        {
            return dalc.GetOgrenciTanitimFormuByStudentIDs(ids);
        }
        public OgrenciTanimaFormu GetStudentForm(ObjectId objectId)
        {
            return dalc.GetStudentForm(objectId);
        }

        public bool StudentHaveAForm(ObjectId id)
        {
            return dalc.StudentHaveAForm(id);
        }

        public List<Rehberlik> GetAllRehberlik()
        {
            return dalc.GetAllRehberlik();
        }

     

        public Rehberlik GetRehberlikByID(ObjectId id)
        {
            return dalc.GetRehberlikByID(id);
        }
         
        public Task<long> EditRehberlikByID(Rehberlik r)
        {
            return dalc.EditRehberlikByID(r);
        }

        public void InsertOTF(OgrenciTanimaFormu otf)
        {
            dalc.InsertOTF(otf);
        }

        public void InsertRehberlikVeliFormu(VeliFormu vf)
        {
            dalc.InsertRehberlikVeliFormu(vf);
        }

        public VeliFormu GetRehberlikVeliFormuByFormID(ObjectId id)
        {
            return dalc.GetRehberlikVeliFormuByFormID(id);
        }
        public bool GuradianHaveAForm(ObjectId id)
        {
            return dalc.GuradianHaveAForm(id);
        }
        public List<VeliFormu> GetRehberlikVeliFormuALL()
        {
            return dalc.GetRehberlikVeliFormuALL();
        }

        public List<VeliFormu> GetRehberlikVeliFormuByUserIds(List<ObjectId> ids)
        {
            return dalc.GetRehberlikVeliFormuByUserIds(ids);
        }

    }
}
