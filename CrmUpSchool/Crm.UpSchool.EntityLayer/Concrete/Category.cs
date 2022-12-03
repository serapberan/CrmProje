using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.EntityLayer.Concrete
{
    public class Category
    {
        [Key]     
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDecription { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
