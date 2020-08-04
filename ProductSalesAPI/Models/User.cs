using System;
using System.Collections.Generic;

namespace ProductSalesAPI
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
            Product = new HashSet<Product>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool? AccountActive { get; set; }
        public bool? AccountExpired { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
