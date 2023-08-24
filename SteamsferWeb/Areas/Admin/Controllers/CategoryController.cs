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

        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //Getting Categories as a list
            var categoryList = _unitOfWork.CategoryRepository.GetAll().ToList();

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
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Category? categoryIdFromDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            return View(categoryIdFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Category");
        }


        //Delete yapınca tablodan silinsin tablo refresh olsun
        public IActionResult Delete(int id)
        {
            if (id != null && _unitOfWork.CategoryRepository != null)
            {
                Category? deletedCategory = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
                _unitOfWork.CategoryRepository?.Remove(deletedCategory);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return NotFound();
            }

        }
    }
}
