using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Username mütləq daxil edilməlidir")]
        [StringLength(20)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password mütləq daxil edilməlidir")]
        public string Password { get; set; }
        public string message { get; set; }
    }
}
