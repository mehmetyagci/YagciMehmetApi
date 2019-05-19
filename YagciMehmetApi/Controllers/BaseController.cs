using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YagciMehmetApi.DB;

namespace YagciMehmetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly BlogDbContext blogDbContext;
        public readonly IMapper mapper;

        public BaseController(BlogDbContext blogDbContext, IMapper mapper)
        {
            this.blogDbContext = blogDbContext;
            this.mapper = mapper;
        }
    }
}