using System;
using System.Collections.Generic;

namespace Entities
{
    public class Cart
    {
        #region Constructors
        public Cart()
        {
            Items = new List<CartItem>();
            CreatedTime = DateTime.Now;
            IsActive = true;
        } 
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public virtual List<CartItem> Items { get; set; }
        public bool IsActive { get; set; } 
        #endregion
    }
}
