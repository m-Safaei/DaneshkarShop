using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Domain.DTOs.SiteSide.Account
{
    public class UserRegisterDTO
    {
        public string Mobile { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه‌ی عبور و تکرار آن یکسان نیستند")]
        public string RePassword { get; set; }
    }
}
