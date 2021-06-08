using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.EntityModels
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatorId { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User Creator { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
