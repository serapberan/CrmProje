using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    public class UserSignUpModel
    {
        [Required(ErrorMessage ="lütfen kullanıcı adını giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "lütfen soyadınızı giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "lütfen mailinizi giriniz")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir mail giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "lütfen telefonunuzu giriniz")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "lütfen şifrenizi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "lütfen şifreyi tekrar giriniz")]
        [Compare("Password",ErrorMessage ="şifreler uyuşmuyor lütfen tekrar deneyin")]
        public string ConfirmPassword { get; set; }
    }
}
