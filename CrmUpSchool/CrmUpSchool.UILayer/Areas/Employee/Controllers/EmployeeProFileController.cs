using Crm.UpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Modes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProFileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProFileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditProfile userEditProfile = new UserEditProfile();
            userEditProfile.Name = values.Name;
            userEditProfile.SurName = values.Surname;
            userEditProfile.PhoneNumber = values.PhoneNumber;
            userEditProfile.Email = values.Email;
            return View(userEditProfile);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditProfile p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var ımageName = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImages/" + ımageName;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageURL = ımageName;

            }

            user.Name = p.Name;
            user.Surname = p.SurName;
            user.PhoneNumber = p.PhoneNumber;
            user.Email = p.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded )
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
    

