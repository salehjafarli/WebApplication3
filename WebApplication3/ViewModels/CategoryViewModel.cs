using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public override string Header => "Categories";
        public List<CategoryModel> Categories { get; set; }
    }
}
