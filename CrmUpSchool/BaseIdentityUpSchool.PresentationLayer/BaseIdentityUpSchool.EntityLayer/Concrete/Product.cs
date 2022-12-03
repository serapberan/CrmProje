using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseIdentityUpSchool.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string  ProductImage{ get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
