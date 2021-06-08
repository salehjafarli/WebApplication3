using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ChiefModel:BaseModel
    {
        [StringLength(maximumLength:30, MinimumLength = 3,ErrorMessage ="Ad uzunlu]u 3-30 simvol arasında olmalıdır")]
        [Required( ErrorMessage ="ad boş ola bilməz")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(pattern: @"^9940(50|70|55|77)\d{7}$",ErrorMessage ="Telefon yanlış daxil edilmişdir,nümunə:9940707777777")]
        public string Phone { get; set; }
        
        [RegularExpression(pattern:@"^[a-z]{3,}@\w+\.[a-z]{2,4}$",ErrorMessage ="Email düzgün daxil edilməyib nümunə : asd@mail.com")]
        public string Email { get; set; }
    }
}
