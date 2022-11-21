using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Data
{

    public class RehberlikData : MongoDocumentsDatabase
    {
        private RehberlikData() { }
        private static RehberlikData Instance;
        private const string collectionName = "Rehberlik";
        private const string collectionNameVeliFormu = "VeliFormu";
        private const string collectionNameOgrenciTanimaFormu = "OgrenciTanimaFormu";
        public static RehberlikData GetInstance()
        {
            if (Instance == null)
                Instance = new RehberlikData();

            return Instance;
        }

        

        public int InsertRehberlik(Rehberlik r)
        {
            return Insert(r, collectionName);
        }

        public List<Rehberlik> GetAllRehberlik()
        {
            return GetToList<Rehberlik>(collectionName).Where(q=>q.IsActive==true).ToList();
        }

        public Rehberlik GetRehberlikByID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Rehberlik> collection = MongoDB.GetCollection<Rehberlik>(collectionName);
            return collection.AsQueryable<Rehberlik>().Where(q => q.id.Equals(id) ).FirstOrDefault();

        }

        public List<ObjectId> GetOgrenciTanitimFormuByStudentIDs(List<ObjectId> ids)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OgrenciTanimaFormu> collection = MongoDB.GetCollection<OgrenciTanimaFormu>(collectionNameOgrenciTanimaFormu);



            var projection = Builders<OgrenciTanimaFormu>
                    .Projection
                    .Include(x => x.FK_StudentID).Exclude(x => x.id);


            // return collection.Find(_ => true).ToList().Select(s => s.FK_StudentID).Distinct().ToList();

            return collection.Find(x => ids.Contains( x.FK_StudentID)).Project(projection).ToList().Select(s => ObjectId.Parse(s["FK_StudentID"].ToString())).ToList();
        }

        public OgrenciTanimaFormu GetStudentForm(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OgrenciTanimaFormu> collection = MongoDB.GetCollection<OgrenciTanimaFormu>(collectionNameOgrenciTanimaFormu);


            //var fieldsBuilder = Builders<OgrenciTanimaFormu>.Projection;
            //var fields = fieldsBuilder.Include(d => d.FK_StudentID);

            // ProjectionDefinition<TDocument, TNewProjection> projection

            return collection.Find(f  =>f.FK_StudentID== objectId).FirstOrDefault();
        }

        public List<VeliFormu> GetRehberlikVeliFormuByUserIds(List<ObjectId> ids)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<VeliFormu> collection = MongoDB.GetCollection<VeliFormu>(collectionNameVeliFormu);
            return collection.AsQueryable<VeliFormu>().Where(q => q.IsActive && ids.Contains(q.FK_StudentID)).ToList();
        }

        public List<ObjectId> GetOgrenciTanitimFormu()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OgrenciTanimaFormu> collection = MongoDB.GetCollection<OgrenciTanimaFormu>(collectionNameOgrenciTanimaFormu);



            var projection = Builders<OgrenciTanimaFormu>
                    .Projection
                    .Include(x => x.FK_StudentID).Exclude(x => x.id);


           // return collection.Find(_ => true).ToList().Select(s => s.FK_StudentID).Distinct().ToList();

            return collection.Find(x => true).Project(projection).ToList().Select(s => ObjectId.Parse(s["FK_StudentID"].ToString())).ToList();

        }

        public void InsertRehberlikVeliFormu(VeliFormu vf)
        {
            Insert(vf, collectionNameVeliFormu);
        }
        public VeliFormu GetRehberlikVeliFormuByFormID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<VeliFormu> collection = MongoDB.GetCollection<VeliFormu>(collectionNameVeliFormu);
            return collection.AsQueryable<VeliFormu>().Where(q => q.id.Equals(id)).FirstOrDefault();
        }

        public List<VeliFormu> GetRehberlikVeliFormuALL( )
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<VeliFormu> collection = MongoDB.GetCollection<VeliFormu>(collectionNameVeliFormu);
            return collection.AsQueryable<VeliFormu>().Where(q => q.IsActive).ToList();
        }
        public bool GuradianHaveAForm(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<VeliFormu> collection = MongoDB.GetCollection<VeliFormu>(collectionNameVeliFormu);

            var filterDef = new FilterDefinitionBuilder<VeliFormu>();
            var filter = filterDef.Eq(x => x.FK_GuardianID, id);

            return collection.Count(Builders<VeliFormu>.Filter.Eq(s => s.FK_GuardianID, id)) > 0 ? true : false;


            // return collection.Count(Builders<Grade>.Filter.Eq(s => s.FK_TeacherID, teachId) & Builders<Grade>.Filter.Eq(s => s.IsActive, true) & Builders<Grade>.Filter.Eq(s => s.ClassType, EnumClassType.openClass));

        }

        public bool StudentHaveAForm(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OgrenciTanimaFormu> collection = MongoDB.GetCollection<OgrenciTanimaFormu>(collectionNameOgrenciTanimaFormu);

            var filterDef = new FilterDefinitionBuilder<OgrenciTanimaFormu>();
            var filter = filterDef.Eq(x => x.FK_StudentID, id);

            return collection.Count(Builders<OgrenciTanimaFormu>.Filter.Eq(s => s.FK_StudentID, id)) > 0 ? true:false;


           // return collection.Count(Builders<Grade>.Filter.Eq(s => s.FK_TeacherID, teachId) & Builders<Grade>.Filter.Eq(s => s.IsActive, true) & Builders<Grade>.Filter.Eq(s => s.ClassType, EnumClassType.openClass));

        }

        public async Task<long> EditRehberlikByID(Rehberlik r)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Rehberlik> collection = MongoDB.GetCollection<Rehberlik>(collectionName);
            Task<ReplaceOneResult> result = collection.ReplaceOneAsync(c => c.id == r.id, r);

            var res = await result;


            if (res.IsModifiedCountAvailable)
                return res.ModifiedCount;




            return 0;
        }

        public void InsertOTF(OgrenciTanimaFormu otf)
        {
              Insert(otf, collectionNameOgrenciTanimaFormu);
        }
    }
}
