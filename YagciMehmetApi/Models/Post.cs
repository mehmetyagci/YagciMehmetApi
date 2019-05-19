using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YagciMehmetApi.Models
{
    public class Post : Entity
    {
        [Required]
        [MaxLength(256)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        public List<Comment> Comments;

        public List<Category> Categories;

        public List<Tag> Tags;

        public Post()
        {
            Comments = new List<Comment>();
            Categories = new List<Category>();
            Tags = new List<Tag>();
        }
    }
}