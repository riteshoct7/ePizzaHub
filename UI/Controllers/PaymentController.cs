using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repository.Models;
using Services.Interfaces;
using Services.Models;
using System;
using UI.Helpers;
using UI.Interfaces;
using UI.Models;

namespace UI.Controllers
{
    
    public class PaymentController : BaseController
    {

        #region Properties

        private readonly IPaymentDetailsService paymentService;
        //private readonly IUserAccessor userAccessor;
        private readonly IOrderService orderService;
        private readonly IOptions<RazorPayConfig> razorPayConfig;

        #endregion

        #region Constructors

        public PaymentController(IPaymentDetailsService paymentService,
            IUserAccessor userAccessor, IOrderService orderService, IOptions<RazorPayConfig> razorPayConfig):base(userAccessor)
        {
            this.paymentService = paymentService;            
            this.orderService = orderService;
            this.razorPayConfig = razorPayConfig;
        } 

        #endregion

        #region Methods

        public IActionResult Index()
        {
            PaymentModel payment = new PaymentModel();
            CartModel cart = TempData.Peek<CartModel>("Cart");
            if (cart!=null)
            {
                payment.Cart = cart;
            }
            payment.GrandTotal = Math.Round(cart.GrandTotal);
            payment.Currency = "INR";
            string items = "";
            foreach (var item in cart.Items)
            {
                items += item.ProductName + ",";
            }
            payment.Description = items;
            
            payment.RazorpayKey = razorPayConfig.Value.Key;            
            payment.Receipt = Guid.NewGuid().ToString();

            //flow in razor pay need to create order first  and ahinst order we get the payment
            payment.OrderId = paymentService.CreateOrder(payment.GrandTotal * 100, payment.Currency, payment.Receipt);
            return View(payment);
        } 

        [HttpPost]
        public IActionResult Status (IFormCollection form)
        {
            try
            {
                if (form.Keys.Count > 0 && !string.IsNullOrWhiteSpace(form["rzp_paymentid"]))
                {
                    string paymentId = form["rzp_paymentid"];
                    string orderId = form["rzp_orderid"];
                    string signature = form["rzp_signature"];
                    string transactionId = form["Receipt"];
                    string currency = form["Currency"];

                    var payment = paymentService.GetPaymentDetails(paymentId);
                    bool IsSignVerified = paymentService.VerifySignature(signature, orderId, paymentId);

                    if (IsSignVerified && payment != null) 
                    {
                        CartModel cart = TempData.Get<CartModel>("Cart");
                        PaymentDetails model = new PaymentDetails();
                        model.CartId = cart.Id;
                        model.Total = cart.Total;
                        model.Tax = cart.Tax;
                        model.GrandTotal = cart.GrandTotal;

                        model.Status = payment.Attributes["status"];//captured
                        model.TransactionId = transactionId;
                        model.Currency = payment.Attributes["currency"];
                        model.Email = payment.Attributes["email"];
                        model.Id = paymentId;
                        model.UserId = CurrentUser.Id;
                        int status = paymentService.SavePaymentDetails(model);
                        if (status > 0)
                        {
                            Response.Cookies.Append("CId", "");
                            Address address = TempData.Get<Address>("Address");
                            //orderService.PlaceOrder(CurrentUser.Id, orderId, paymentId, cart, address);

                            //TO DO :Send email
                            TempData.Set("PaymentDetails", model);
                            return RedirectToAction("Receipt");
                        }
                        else
                        {
                            ViewBag.Message = "Although, due to som etchnical issues it's not get updated in our side. " +
                                "We will contact you soon"; 

                        }
                    }



                }

            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.Message = "Your payment has failed.";
            return View();

        }


        public IActionResult Receipt ()
        {
            PaymentDetails model = TempData.Peek<PaymentDetails>("PaymentDetails");
            return View(model);
        }
        #endregion
    }
}
