using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.CacheController;
using DataAccessLayer;
using Entities;
using MongoDB.Bson;

namespace BusinessLayer
{

   public class AccountBusiness
    {
 
        private AccountBusiness() { }
        private static AccountBusiness Instance;

        public static AccountBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new AccountBusiness();

            return Instance;
        }

        private AccountMap LoadMap()
        {
           
             List<User> UserList = dalc.GetUsersList();
           
            return new AccountMap(UserList);
        }

        private AccountMap Map
        {
            get
            {
                Caching rc = Caching.GetInstance();
                AccountMap map = rc.GetAccountMap();

                if (map == null)
                {
                    map = LoadMap();
                }

                return map;
            }
        }



        public User GetUserByID(ObjectId userID)
        {
            return dalc.GetUsersListByIDs(userID);
          //  return Map.GetUserByID(userID);
        }



        private AccountData _dalc; // dalc buradan kalkacak account map bu ';' yapoacak ya cache ya da dalc
        private AccountData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = AccountData.GetInstance();

                return _dalc;
            }
        }
        public List<ObjectId> GetUsersObjectIdByGradeID(ObjectId id)
        {
            return dalc.GetUsersObjectIdByGradeID(id);
        }
        public  List<User> GetUsersByGradeID(ObjectId id)
        {
            return dalc.GetUsersByGradeID(id);
        }
        public int InsertAccount(User k)
        {
            return dalc.InsertAccount(k);
        }

        public List<UserType> GetUserType()
        {
           return  dalc.GetUserType();
        }

        public User GetAccount(string u , string p)
        {
            return dalc.GetAccount(u,p);
        }
        public User GetAccountTCNO(string u, string p)
        {
            return dalc.GetAccountTCNO(u, p);
        }



        public void  InsertAccountType(List<UserType> ut)
        {
            dalc.InsertAccountType(ut);
        }

        public User GetUser(ObjectId id)
        {
            return dalc.GetUser(id);
        }

        public List<User> GetUsersList()
        {
            return dalc.GetUsersList();
        }
        public List<User> GetUsersListByIDs(List<ObjectId> list)
        {
            return dalc.GetUsersListByIDs(list);
        }
      
        public void UpdateAccount(User u)
        {
            dalc.UserUpdate(u);
        }
        public void InsertYetki(YetkiTipi y)
        {
            dalc.InsertYetki(y);
        }

        public void InsertYetkiAlan(YetkiAlan ya)
        {
            dalc.InsertYetkiAlan(ya);
        }

        public List<YetkiAlan> GetYetkiAlan()
        {
            return dalc.GetYetkiAlan();
        }

        public List<User> GetUsersIdarecilerList()
        {
            return dalc.GetUsersIdarecilerList();
        }

        public List<YetkiTipi> GetYetkiTipi()
        {
            return dalc.GetYetkiTipi();
        }

        public void InsertYetkisizGiris(YetkisizGiris yg)
        {
              dalc.InsertYetkisizGiris(yg);
        }

        public void InsertAccountFC(FCPerson person)
        {
            dalc.InsertAccountFC(person);
        }

        public User GetAccountByFaceID(string id)
        {
            return dalc.GetAccountByFaceID(id);
        }

        public FCPerson GetFaceAccountByFaceID(string id)
        {
            return dalc.GetFaceAccountByFaceID(id);
        }

        public static List<User> GetUsersByTeacherID(ObjectId id)
        {
            throw new NotImplementedException();
        }

      
    }
    public class AccountMap
    {
      
        private Dictionary<ObjectId, User> Users { get; set; }
        public AccountMap(List<User> users)
        {
            this.Users = users.ToDictionary(d=>d.id,d=>d);
          
        }
         
        public User GetUserByID(ObjectId userID)
        {
            if (Users.ContainsKey(userID))
                return Users[userID];
            else
                return null;
        }
    }
}



/*
 
      public class CategoryMap
    {
        private Dictionary<int, CategoryGroup> categoryGroupMap { get; set; }
        private Dictionary<int, Category> categoryMap { get; set; }
        private Dictionary<string, int> categoryIdSEONameMap { get; set; }
        public List<CategoryGroup> CategoryGroups { get; set;}
        public List<Category> Categories { get; set; }
        public List<Category> CategoriesOnHeader { get; set; }

        public CategoryMap(List<CategoryGroup> groups, List<Category> categories)
        {
            this.CategoryGroups = groups;
            this.Categories = categories;
            BuildCategoryTree(groups, categories);
        }


        public Category GetCategory(int categoryId)
        {
            if (categoryMap.ContainsKey(categoryId))
                return categoryMap[categoryId];
            else
                return null;
        }

        public Category GetCategory(string categorySEOName)
        {
            if (categoryIdSEONameMap.ContainsKey(categorySEOName))
                return GetCategory(categoryIdSEONameMap[categorySEOName]);
            else
                return null;
        }

        public CategoryGroup GetCategoryGroup(int groupId)
        {
            return categoryGroupMap[groupId];
        }


        private void BuildCategoryTree(List<CategoryGroup> groups, List<Category> categories)
        {
            CachingController cc = CachingController.GetInstance();
            categoryGroupMap = new Dictionary<int, CategoryGroup>();
            foreach (CategoryGroup cg in groups)
            {
                categoryGroupMap.Add(cg.GroupId, cg);
            }

            CategoriesOnHeader = new List<Category>();
            categoryMap = new Dictionary<int, Category>();
            categoryIdSEONameMap = new Dictionary<string, int>();
            foreach (Category c in categories)
            {
                categoryMap.Add(c.CategoryId, c);
                categoryIdSEONameMap.Add(c.SearchEngineURL, c.CategoryId);
                if (c.DisplayOnHeader)
                {
                    CategoriesOnHeader.Add(c);
                }
            }

            Category rootCat = null;
            if (categoryMap.ContainsKey(0))
            {
                rootCat = categoryMap[0];
            }
            else
            {
                //add root category to map
                rootCat = new Category();
                categoryMap.Add(0, rootCat);
            }
            

            foreach (Category c in categories)
            {

                if (c.ParentCategoryId == 0)
                {
                    //add to category group and root category
                    if (categoryGroupMap.ContainsKey(c.GroupId))
                    {
                        CategoryGroup cg = categoryGroupMap[c.GroupId];
                        cg.Categories.Add(c);
                        rootCat.Categories.Add(c);
                    }

                }
                else
                {
                    //add to parent category
                    if (categoryMap.ContainsKey(c.ParentCategoryId))
                    {
                        Category cat = categoryMap[c.ParentCategoryId];
                        cat.Categories.Add(c);
                    }
                }

            }
        }
    }
     
     */
