using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YagciMehmetApi.Models
{
    public class Comment : Entity
    {
        [Required]
        public long PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        [MaxLength(2500)]
        [MinLength(2)]
        public string CommentText { get; set; }

        public string Username { get; set; }
    }
}