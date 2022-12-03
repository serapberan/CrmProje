using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen rol adını boş geçmeyin")]
        public string RoleName { get; set; }
    }
}
