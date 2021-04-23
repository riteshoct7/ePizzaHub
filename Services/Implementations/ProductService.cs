using Entities;
using Repository.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Implementations
{
    public class ProductService : IProductService
    {

        #region Properties

        IProductRepository productReository; 

        #endregion

        #region Constructors

        public ProductService(IProductRepository productReository)
        {
            this.productReository = productReository;
        }

        #endregion

        #region Methods

        public IEnumerable<Products> GetAllProducts()
        {
            return productReository.GetAll();
        }

        public Products GetProductById(int id)
        {
            return productReository.GetById(id);
        }

        public void SaveProduct(Products model)
        {
            productReository.Add(model);
            productReository.SaveChanges();
        }

        public void UpdateProduct(Products model)
        {
            productReository.Update(model);
            productReository.SaveChanges();
        }

        public void DeletProduct(int id)
        {
            productReository.Delete(id);
            productReository.SaveChanges();
        }

        #endregion
    }
}
