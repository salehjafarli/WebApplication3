using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class CookModel:BaseModel
    {
        [Required(ErrorMessage = "Ad mütləq daxil edilməlidir")]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Adın uzunluğu 3-30 arasında olmalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Porsiya çəkisi mütləq daxil edilməlidir")]
        public decimal PortionWeight { get; set; }
        [Required(ErrorMessage = "Porsiya qiyməti mütləq daxil edilməlidir")]
        public decimal PortionPrice { get; set; }
        [Required(ErrorMessage = "Kateqoriya mütləq seçilməlidir")]
        public CategoryModel CookCategory { get; set; }
        [JsonIgnore]
        public List<SelectListItem> Categories { get; set; }
    }
}
