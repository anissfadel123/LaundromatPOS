using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaundroAPI.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Username or Email is required")]
        public string UsernameOrEmail { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
