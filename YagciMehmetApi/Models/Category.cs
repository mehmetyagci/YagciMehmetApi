using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YagciMehmetApi.Models
{
    public class Category : Entity
    {
        [Required]
        [MaxLength(256)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}