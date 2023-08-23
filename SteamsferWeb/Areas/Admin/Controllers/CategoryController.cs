using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Steamsfer.DataAccess.Data;
using Steamsfer.DataAccess.Repository.IRepository;
using Steamsfer.Models;

namespace SteamsferWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            //Getting Categories as a list
            var categoryList = _categoryRepo.GetAll().ToList();

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

                ModelState.AddModelError("Name", "Category Name cannot contain '@'");
            }

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Category? categoryIdFromDb = _categoryRepo.Get(u => u.Id == id);
            return View(categoryIdFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoryRepo.Update(category);
            _categoryRepo.Save();
            return RedirectToAction("Index", "Category");
        }


        //Delete yapınca tablodan silinsin tablo refresh olsun
        public IActionResult Delete(int id)
        {
            if (id != null && _categoryRepo != null)
            {
                Category? deletedCategory = _categoryRepo.Get(u => u.Id == id);
                _categoryRepo?.Remove(deletedCategory);
                _categoryRepo?.Save();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return NotFound();
            }

        }
    }
}
