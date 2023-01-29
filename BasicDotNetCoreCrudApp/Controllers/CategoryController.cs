using BasicDotNetCoreCrudApp.Data;
using BasicDotNetCoreCrudApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicDotNetCoreCrudApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<CategoryModel> objCategoryList = _db.Categories;

            return View(objCategoryList);
        }
    }
}
