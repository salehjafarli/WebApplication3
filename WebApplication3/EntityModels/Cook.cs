using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.EntityModels
{
    public partial class Cook
    {
        public Cook()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CookCategoryId { get; set; }
        public decimal PortionWeight { get; set; }
        public decimal PortionPrice { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatorId { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CookCategory CookCategory { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
