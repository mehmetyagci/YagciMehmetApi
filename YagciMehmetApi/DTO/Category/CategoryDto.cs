using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YagciMehmetApi.DTO.Shared;

namespace YagciMehmetApi.DTO
{
    public class CategoryDTO : DtoHasBaseId
    {
        public string Name { get; set; }
    }
}