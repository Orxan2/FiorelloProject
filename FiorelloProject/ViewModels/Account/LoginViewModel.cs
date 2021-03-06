using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required, DataType("nvarchar(50)")]
        public string Username { get; set; }
        //[Required, DataType(DataType.EmailAddress)]
        //public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
