using Entities;

namespace Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        #region "Methods"

        Category GetCategoryByName(string catgeoryName);

        Category GetCategoryByDescription(string description); 

        #endregion

    }
}
