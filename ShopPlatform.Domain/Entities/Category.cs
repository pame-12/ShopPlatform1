using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPlatform.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }   
        public string CategoryName { get; set; }
        public string Description { get; set; }

        
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }

        
        public bool Deleted { get; set; }
    }
}

