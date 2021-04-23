using Entities;
using Microsoft.Extensions.Options;
using Razorpay.Api;
using Repository.Interfaces;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Services.Implementations
{
    public class PaymentDetailsService : IPaymentDetailsService
    {

        #region Properties

        private readonly IPaymentDetailsRepository _paymentRepository;
        private readonly IOptions<RazorPayConfig> _razorPayConfig;
        private readonly RazorpayClient _client;
        private readonly ICartRepository _cartRepo;

        #endregion

        #region Constructors

        public PaymentDetailsService(IPaymentDetailsRepository paymentRepository, IOptions<RazorPayConfig> razorPayConfig,
             ICartRepository cartRepo)
        {
            _paymentRepository = paymentRepository;
            _razorPayConfig = razorPayConfig;
            _cartRepo = cartRepo;
            if (_client == null)
            {
                _client = new RazorpayClient(_razorPayConfig.Value.Key, _razorPayConfig.Value.Secret);
            }
        }

        #endregion

        #region Methods

        public string CreateOrder(decimal amount, string currency, string receipt)
        {
            try
            {
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount",amount);
                options.Add("currency", currency);
                options.Add("receipt", receipt);
                options.Add("payment_capture", 1);
                Razorpay.Api.Order orderResponse = _client.Order.Create(options);
                return orderResponse["id"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public string CapturePayment(string paymentId, string orderId)
        {
            if (!string.IsNullOrWhiteSpace(paymentId)&& !string.IsNullOrEmpty(orderId))
            {
                try
                {
                    Payment payment = _client.Payment.Fetch(paymentId);
                    Dictionary<string, object> options = new Dictionary<string, object>();
                    options.Add("amount", payment.Attributes["amount"]);
                    options.Add("currency", payment.Attributes["currency"]);
                    Payment paymentCaptured = payment.Capture(options);
                    return paymentCaptured.Attributes["status"];
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public Payment GetPaymentDetails(string paymentId)
        {
            if (!string.IsNullOrWhiteSpace(paymentId))
            {
                return _client.Payment.Fetch(paymentId);
            }
            return null;
        }

        public bool VerifySignature(string signature, string orderId, string paymentId)
        {
            string payload = string.Format("{0}|{1}", orderId, paymentId);
            string secret = RazorpayClient.Secret;
            string actualSignature = GetActualSignature(payload, secret);
            return actualSignature.Equals(signature);
        }

        private static string GetActualSignature (string payload, string secret)
        {
            byte[] secretBytes = StringEncode(secret);            
            HMACSHA256 hashHmac = new HMACSHA256(secretBytes);
            var bytes = StringEncode(payload);
            return HashEncode(hashHmac.ComputeHash(bytes));
        }

        private static byte[] StringEncode (string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode (byte[] hash)
        {
            //return BitConverter.ToString(hash).Replace(".", "").ToLower();

            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        public int SavePaymentDetails(PaymentDetails model)
        {
            _paymentRepository.Add(model);
            var cart = _cartRepo.GetById(model.CartId);
            cart.IsActive = false;
            return _paymentRepository.SaveChanges();
        }

        #endregion

    }
}
