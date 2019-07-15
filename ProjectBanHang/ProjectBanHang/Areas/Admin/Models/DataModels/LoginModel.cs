using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời bạn nhập UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Mời bạn nhập Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }  
    }
}