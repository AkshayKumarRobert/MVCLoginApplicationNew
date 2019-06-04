using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLoginApplication.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage="Username is Required")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}