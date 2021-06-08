using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.EntityModels
{
    public partial class CookCategory
    {
        public CookCategory()
        {
            Cooks = new HashSet<Cook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatorId { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<Cook> Cooks { get; set; }
    }
}
