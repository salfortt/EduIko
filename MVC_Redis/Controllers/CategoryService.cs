using MVC_Redis.Models;
using System.Text.Json;

namespace MVC_Redis.Controllers
{
    public class CategoryService : ICategoryService
    {
        static List<CategoryModel> categories = new()
    {
        new CategoryModel { Id = 1, Name = "Electronic" },
        new CategoryModel { Id = 2, Name = "Clothes" }, 
        new CategoryModel { Id = 3, Name = "test" },
        new CategoryModel { Id = 4, Name = "tst2" }
    };
        public List<CategoryModel> categories2 => new()
    {
        new CategoryModel { Id = 5, Name = "test" },
        new CategoryModel { Id = 6, Name = "tst2" }
    };
        public ICacheService CacheService { get; }

        public CategoryService(ICacheService cacheService)
        {
            CacheService = cacheService;
            
        }
        public List<CategoryModel> GetAllCategory()
        {
           
            return GetCategoriesFromCache();
        }
        private List<CategoryModel> GetCategoriesFromCache()
        
        {

             categories.AddRange(categories2);
           // CacheService.ClearAll();

            CacheService.SetValueAsync("allcategories", JsonSerializer.Serialize(categories));
           // CacheService.GetOrAdd("allcategories", () => { return categories; });
            return CacheService.GetOrAdd("allcategories", () => { return categories; });
        }
    }


 

 
}
