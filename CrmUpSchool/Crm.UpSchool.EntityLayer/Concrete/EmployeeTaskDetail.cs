using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.EntityLayer.Concrete
{
    public class EmployeeTaskDetail
    {
        public int EmployeeTaskDetailID { get; set; }
        public int EmployeeTaskID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
    }
}
