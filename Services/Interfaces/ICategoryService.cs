using Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICategoryService
    {

        #region Methods

        IEnumerable<Category> GetAllCategories();

        Category GetCatgeoryByName(string categroyName);

        Category GetCatgeoryByDescription(string description);

        void SaveCategory(Category model);

        Category GetCategoryById(int id);

        void UpdateCategory(Category model);

        void DeleteCategory(int id);

        #endregion

    }
}
