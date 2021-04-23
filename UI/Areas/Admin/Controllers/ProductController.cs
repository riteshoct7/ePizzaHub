using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using UI.Areas.Admin.Models;
using UI.Interfaces;

namespace UI.Areas.Admin.Controllers
{    
    public class ProductController : BaseController
    {

        #region Properties

        IProductService productService;
        ICategoryService categoryService;
        IFileHelper fileHelper; 

        #endregion

        #region Constructors

        public ProductController(IProductService productService, ICategoryService categoryService, IFileHelper fileHelper)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.fileHelper = fileHelper;
        }

        #endregion

        #region Methods

        public IActionResult GetAllProducts()
        {            
            return View(productService.GetAllProducts());
        } 

        public ActionResult Create ()
        {
            ViewBag.Categories = categoryService.GetAllCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            ViewBag.Categories = categoryService.GetAllCategories();
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    model.ImageUrl = fileHelper.UploadFile(model.File);
                }
                else
                {
                    model.ImageUrl = string.Empty;
                }
                Products objProduct = new Products();
                objProduct.ProductName = model.ProductName;
                objProduct.UnitPrice = model.UnitPrice;
                objProduct.CategoryId = model.CategoryId;
                objProduct.Description = model.Description;                
                productService.SaveProduct(objProduct);
                return RedirectToAction("GetAllProducts");
            }
            else
            {
                return View(model);    
            }            
        }


        public ActionResult Edit(int id)
        {
            ViewBag.Categories = categoryService.GetAllCategories();
            Products objProduct = productService.GetProductById(id);
            ProductModel objProductModel = new ProductModel();
            objProductModel.Productid = objProduct.Productid;
            objProductModel.ProductName = objProduct.ProductName;
            objProductModel.UnitPrice = objProduct.UnitPrice;
            objProductModel.CategoryId = objProduct.CategoryId;
            objProductModel.Description = objProduct.Description;
            objProductModel.ImageUrl = objProduct.ImageUrl;
            return View(objProductModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            ViewBag.Categories = categoryService.GetAllCategories();
            if (ModelState.IsValid)
            {   
                if (model.File !=null)
                {
                    fileHelper.DeleteFile(model.ImageUrl);
                    model.ImageUrl = fileHelper.UploadFile(model.File);
                }                
                Products objProduct = new Products();
                objProduct.Productid = model.Productid;
                objProduct.ProductName = model.ProductName;
                objProduct.UnitPrice = model.UnitPrice;
                objProduct.CategoryId = model.CategoryId;
                objProduct.Description = model.Description;
                objProduct.ImageUrl = model.ImageUrl;
                productService.UpdateProduct(objProduct);
                return RedirectToAction("GetAllProducts");
            }
            else
            {
                return View(model);
            }
        }

        [Route("~/Admin/Product/Delete{id}/{url}")]
        public IActionResult Delete (int id, string url)
        {
            url = url.Replace("%2F", "/"); //replace to find the file
            productService.DeletProduct(id);
            fileHelper.DeleteFile(url);
            return RedirectToAction("GetAllProducts");
        }
        #endregion
    }
}
