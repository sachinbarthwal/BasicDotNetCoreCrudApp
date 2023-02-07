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

		//Get
		public IActionResult Create()
		{
			return View();
		}

		//Post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CategoryModel obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("SameValueError", "Name and Display cannot be same");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category Created Successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		//Get
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var categoryDB = _db.Categories.Find(id);
			//categoryDB = _db.Categories.FirstOrDefault(x=>x.Id==id);
			//categoryDB = _db.Categories.SingleOrDefault(x=>x.Id ==id);

			if (categoryDB == null)
				return NotFound();
			return View(categoryDB);
		}

		//Post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(CategoryModel obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("SameValueError", "Name and Display cannot be same");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category Updated Successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		//Get
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var categoryDB = _db.Categories.Find(id);

			if (categoryDB == null)
				return NotFound();
			return View(categoryDB);
		}

		//Post
		[HttpPost,ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category Deleted Successfully";
			return RedirectToAction("Index");
		}
	}
}
