using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YagciMehmetApi.DTO.Shared
{
    public abstract class DtoHasBaseId : DtoBase
    {
        public long Id { get; set; }
    }
}