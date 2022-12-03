using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
   

    public class CustomerController : Controller
    {

        Context db = new Context();
        public IActionResult Index(Customer customer)
        {
           var values= db.Customers.ToList();

            return View(values);
        }
    }
}
