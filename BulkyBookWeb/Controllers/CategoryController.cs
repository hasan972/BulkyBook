using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
           IEnumerable<Category>  objCategoryList = _db.categories;
            return View(objCategoryList);
        }
        //GET Action Methode 
        public IActionResult Create()
        {
            
            return View();
        }
        //Post Action Methode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.CategoryOrder.ToString())
            {
                // ModelState.AddModelError("CustomError", "The Display Can't exactly Match The Name!");
                ModelState.AddModelError("Name", "The Display Can't Exactly Match The Name");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //For Edite 
        public IActionResult Edite(int? id) 
        {
            if(id == null || id==0) 
            {
                return NotFound();
            }
            //Three Typpe of retrive the Category
            var categoryFromDB = _db.categories.Find(id);
           // var categoryFromDBFirst = _db.categories.FirstOrDefault(u=>u.Id==id);
           // var categoryFromDBSingle = _db.categories.SingleOrDefault(u => u.Id == id); 

            if(categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edite(Category obj)
        {
            if (obj.Name == obj.CategoryOrder.ToString())
            {
                // ModelState.AddModelError("CustomError", "The Display Can't exactly Match The Name!");
                ModelState.AddModelError("Name", "The Display Can't Exactly Match The Name");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }

}
