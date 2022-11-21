using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /*özel yetki oluşturuldu ise 
     
         öncesinde öğretmen öğrenci veli müdür gibi sabit tipler olur 
         
         user özel yetki ise 
         
         o zaman özel yetki yüklenir
         
         */

    [Serializable]
    public class UserAuthority
    {
        public ObjectId AuthorityID { get; set; }
        public List<Authority> Authority { get; set; }

    }
    [Serializable]
    public class Authority
    {
        public ObjectId id { get; set; }
        public string AuthorityName { get; set; }//Yetki alanı Ders,
        public AuthorityType AuthorityType { get; set; }//ekleme,silme,yazma,okuma,admin,öğrenci,veli,müdür

        public AuthorityProcessType AuthorityProcessType { get; set; }
    }
    [Serializable]
    public enum AuthorityType
    {
        client = 0, student = 1, parent = 1, teacher = 3, assistantDirector = 5, director = 6, founder = 7, particular = 8

        /*bir kişinin bazı alanları görmesini istiyoruz ama fiyatları görmesin dediğimizde limitedRead olur fullRead her şey i görür */
    }
    [Serializable]
    public enum AuthorityProcessType
    {
        none = 0, limitedRead = 1, fullRead = 2, limitedexecute = 3, fullexecute = 4, write = 4, full = 5

        /*bir kişinin bazı alanları görmesini istiyoruz ama fiyatları görmesin dediğimizde limitedRead olur fullRead her şey i görür */
    }
}
