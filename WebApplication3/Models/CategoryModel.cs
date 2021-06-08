using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class CategoryModel:BaseModel
    {
        [Required(ErrorMessage ="Ad mütləq daxil edilməlidir")]
        [StringLength(maximumLength:30,MinimumLength =3,ErrorMessage ="Adın uzunluğu 3-30 arasında olmalıdır")]
        public string Name { get; set; }
    }
}
