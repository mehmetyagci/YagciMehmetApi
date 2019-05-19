using System.ComponentModel.DataAnnotations;
using YagciMehmetApi.DTO.Shared;

namespace YagciMehmetApi.DTO.Category
{
    public class CategoryUpdateDTO : DtoHasBaseId
    {
        [Required]
        [MaxLength(256)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}