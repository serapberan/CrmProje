using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmanSalary> departmanSalaries = new List<DepartmanSalary>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DepartmanChart()
        {
            departmanSalaries.Add(new DepartmanSalary
            {
                departmanname = "Muhasebe",
                salaryavg = 10000
            });

            departmanSalaries.Add(new DepartmanSalary
            {
                departmanname = "Yazılım",
                salaryavg = 30000
            });

            departmanSalaries.Add(new DepartmanSalary
            {
                departmanname = "Pazarlama",
                salaryavg = 15000
            });



            return Json(new { jsonList = departmanSalaries});
        }
    }
}
