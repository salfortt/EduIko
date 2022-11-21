using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public  class Menu
    {
        public ObjectId id { get; set; }
        public string     ID { get; set; }
       public string   Link { get; set; }
       public string   Text { get; set; }
       public string   Image { get; set; }
       public string   GrantType { get; set; }
        public List<UserTypeEnum> GrantUserType { get; set; }//ana menüyü görecek tipler
        public bool IsViewInMainMenu { get; set; }
        public string GrantController { get; set; }
       public List<SubMenu> SubMenu { get; set; }


    }
    [Serializable]
    public class SubMenu
    {
        public List<UserTypeEnum> GrantUserType { get; set; }//alt menüyü görecek tipler
        public ObjectId id { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string GrantType { get; set; }
        public string GrantController { get; set; }
        public bool IsSeen { get; set; }
    }


    [Serializable]
    public class UserMenu
    {
        public ObjectId id { get; set; }
        public UserTypeEnum MenuType { get; set; }

        public List<Menu> Menus { get; set; }

    }
    
}
