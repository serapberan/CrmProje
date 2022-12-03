using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaseIdentityUpSchool.PresentationLayer.Models
{
    public class AppUserRegisterViewModel
    {
        [Required(ErrorMessage="Kullanıcı Adı Boş Geçilemez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kullanıcı Soyad  Boş Geçilemez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Maili Boş Geçilemez")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Kullanıcı Şifre Boş Geçilemez")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar")]
        public string Confirmpassword { get; set; }
    }
}
