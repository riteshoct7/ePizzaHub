using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace UI.ViewComponents
{
    public class PizzaMenuViewComponent : ViewComponent
    {
        #region Properies

        IProductService productService;

        #endregion

        #region Constructors

        public PizzaMenuViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        #endregion

        #region Methods

        public IViewComponentResult Invoke()
        {
            var items = productService.GetAllProducts();
            return View("~/Views/Shared/_PizzaMenu.cshtml", items);
        } 

        #endregion

    }
}
