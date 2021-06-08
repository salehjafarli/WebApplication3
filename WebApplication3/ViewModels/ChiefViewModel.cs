using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class ChiefViewModel : BaseViewModel
    {
        public override string Header => "Chiefs";

        public List<ChiefModel> Models { get; set; }
    }
}
