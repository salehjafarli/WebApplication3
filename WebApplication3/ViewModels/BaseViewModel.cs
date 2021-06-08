using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.EntityModels;

namespace WebApplication3.ViewModels
{
    public abstract class BaseViewModel
    {
        public abstract string Header { get; }
        public UserModel CurrentUser { get; set; }

        
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
