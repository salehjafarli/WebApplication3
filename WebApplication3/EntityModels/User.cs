using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.EntityModels
{
    public partial class User
    {
        public User()
        {
            Chiefs = new HashSet<Chief>();
            CookCategories = new HashSet<CookCategory>();
            Cooks = new HashSet<Cook>();
            InverseCreator = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatorId { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
        public decimal? Salary { get; set; }

        public virtual User Creator { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        public virtual ICollection<Chief> Chiefs { get; set; }
        public virtual ICollection<CookCategory> CookCategories { get; set; }
        public virtual ICollection<Cook> Cooks { get; set; }
        public virtual ICollection<User> InverseCreator { get; set; }
    }
}
