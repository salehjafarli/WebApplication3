using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        [StringLength(250)]
        public string Note { get; set; }
    }
}
