using MVC_Redis.Controllers;
using MVC_Redis.Models;

namespace MVC_Redis
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAllCategory();
    }
}
