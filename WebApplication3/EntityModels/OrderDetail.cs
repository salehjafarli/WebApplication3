using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.EntityModels
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CookId { get; set; }
        public int ChiefId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatorId { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Chief Chief { get; set; }
        public virtual Cook Cook { get; set; }
        public virtual User Creator { get; set; }
        public virtual Order Order { get; set; }
    }
}
