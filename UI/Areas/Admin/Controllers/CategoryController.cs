using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using UI.Areas.Admin.Models;

namespace UI.Areas.Admin.Controllers
{    
    public class CategoryController : BaseController
    {
        #region Properties

        ICategoryService categoryService;

        #endregion

        #region Constructors

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #endregion

        #region Methods

        public IActionResult AllCategories()
        {
            return View(categoryService.GetAllCategories());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                Category objCategory = new Category();
                objCategory.CategoryName = categoryModel.CategoryName;
                objCategory.Description = categoryModel.Description;
                categoryService.SaveCategory(objCategory);
                return RedirectToAction("AllCategories");
            }
            else
            {
                return View(categoryModel);
            }
        }

        public IActionResult Edit(int id)
        {            
            Category category = categoryService.GetCategoryById(id);
            if (category != null)
            {
                CategoryModel objCategoryModel = new CategoryModel();
                objCategoryModel.CategoryId = category.CategoryId;
                objCategoryModel.CategoryName = category.CategoryName;
                objCategoryModel.Description = category.Description;
                return View(objCategoryModel);
            }
            else
            {
                return RedirectToAction("AllCategories");
            }            
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                Category objCategory = new Category();
                objCategory.CategoryId = categoryModel.CategoryId;
                objCategory.CategoryName = categoryModel.CategoryName;
                objCategory.Description = categoryModel.Description;
                categoryService.UpdateCategory(objCategory);
                return RedirectToAction("AllCategories");
            }
            else
            {
                return View(categoryModel);
            }
        }

        public ActionResult Delete (int id)
        {
            categoryService.DeleteCategory(id);
            return RedirectToAction("AllCategories");
        }

        #endregion

    }
}
