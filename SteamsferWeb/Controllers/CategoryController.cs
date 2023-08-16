using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SteamsferWeb.Data;
using SteamsferWeb.Models;

namespace SteamsferWeb.Controllers
{
    public class CategoryController : Controller
    {
        //Creating empty _dbContext as a backing field
        private readonly ApplicationDBContext _dbContext;
        public CategoryController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //Getting Categories as a list
            var categoryList = _dbContext.Categories.ToList();

            return View(categoryList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name.Contains("@"))
            {

                ModelState.AddModelError("Name","Category Name cannot contain '@'");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Category? categoryIdFromDb = _dbContext.Categories.Find(id);

            return View(categoryIdFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _dbContext.Update(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Category");
        }


        //Delete yapınca tablodan silinsin tablo refresh olsun
        public IActionResult Delete(int id)
        {
            if (id != null && _dbContext.Categories != null)
            {
                Category? deletedCategory = _dbContext.Categories.Find(id);
                _dbContext?.Remove(deletedCategory);
                _dbContext?.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return NotFound();
            }

        }
    }
}
 