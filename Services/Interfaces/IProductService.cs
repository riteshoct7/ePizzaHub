using Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IProductService
    {
        #region Methods

        IEnumerable<Products> GetAllProducts();

        void SaveProduct(Products model);

        void UpdateProduct (Products model);

        Products GetProductById(int id);

        void DeletProduct(int id);

        #endregion
    }
}
