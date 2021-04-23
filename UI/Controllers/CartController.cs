using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Services.Interfaces;
using UI.Helpers;
using System;
using System.Text.Json;
using UI.Interfaces;

namespace UI.Controllers
{
    public class CartController : BaseController
    {
        #region Properties

        ICartService cartService;
        ICartItemService cartItemService;

        Guid CartId
        { 
            get
            {
                Guid Id;
                string CId = Request.Cookies["CId"];
                if (string.IsNullOrEmpty(CId))
                {
                    Id = Guid.NewGuid();
                    Response.Cookies.Append("CId", Id.ToString());
                }
                else
                {
                    Id = new Guid(CId);
                }
                return Id;
            }
        }

        #endregion

        #region Constructors

        //public CartController(ICartService cartService, ICartItemService cartItemService, UserManager<User> userManager) : base(userManager)
        //{
        //    this.cartService = cartService;
        //    this.cartItemService = cartItemService;

        //}

        public CartController(ICartService cartService, ICartItemService cartItemService, IUserAccessor userAccessor) : base(userAccessor)
        {
            this.cartService = cartService;
            this.cartItemService = cartItemService;

        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            CartModel cart = cartService.GetCartDetails(CartId);
            if (CurrentUser !=null && cart !=null)
            {
                TempData.Set("Cart", cart);
                cartService.UpdateCart(cart.Id, CurrentUser.Id);
            }
            return View(cart);
        }
        [Route("Cart/AddToCart/{ItemId}/{UnitPrice}/{Quantity}")]
        public IActionResult AddToCart(int ItemId, decimal UnitPrice, int Quantity)
        {
            int UserId = CurrentUser != null ? CurrentUser.Id : 0;

            if (ItemId > 0 && Quantity > 0)
            {
                Cart cart = cartService.AddItem(UserId, CartId, ItemId, UnitPrice, Quantity);
                var data = JsonSerializer.Serialize(cart);
                return Json(data);
            }
            else
            {
                return Json("");
            }
        }

        public IActionResult DeleteItem(int Id)
        {
            int count = cartService.DeleteItem(CartId, Id);
            return Json(count);
        }

        [Route("Cart/UpdateQuantity/{Id}/{Quantity}")]
        public IActionResult UpdateQuantity(int Id, int Quantity)
        {
            int count = cartService.UpdateQuantity(CartId, Id, Quantity);
            return Json(count);
        }

        public IActionResult GetCartCount()
        {
            int count = cartService.GetCartCount(CartId);
            return Json(count);
        }

        public IActionResult CheckOut ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Address address)
        {
            TempData.Set("Address", address);
            return RedirectToAction("Index", "Payment");
        }

        #endregion
    }
}
