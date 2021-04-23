using Entities;
using Repository.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region Variables

        ICategoryRepository categoryRepo;

        #endregion

        #region Constuctors
        
        public CategoryService(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        #endregion

        #region Methods

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepo.GetAll();
        }

        public Category GetCatgeoryByDescription(string description)
        {
            return categoryRepo.GetCategoryByDescription(description);
        }

        public Category GetCatgeoryByName(string categoryName)
        {
            return categoryRepo.GetCategoryByName(categoryName);
        }

        public void SaveCategory(Category model)
        {
            categoryRepo.Add(model);
            categoryRepo.SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            return categoryRepo.GetById(id);
        }

        public void UpdateCategory(Category model)
        {
            categoryRepo.Update(model);
            categoryRepo.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            categoryRepo.Delete(id);
            categoryRepo.SaveChanges();
        } 

        #endregion
    }
}
