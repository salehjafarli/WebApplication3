using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class CookViewModel : BaseViewModel
    {
        public override string Header => "Cooks";
        public List<CookModel> Cooks { get; set; }
    }
}
