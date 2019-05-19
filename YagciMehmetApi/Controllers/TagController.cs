using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YagciMehmetApi.DB;
using YagciMehmetApi.Models;

namespace YagciMehmetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : BaseController
    {
        public TagController(BlogDbContext blogDbContext, IMapper mapper) :
            base(blogDbContext, mapper)
        {
            if (this.blogDbContext.Tags.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                this.blogDbContext.Tags.Add(new Tag { Name = "Tag1" });
                this.blogDbContext.SaveChanges();
            }
        }

        // Get: api/Tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            return await this.blogDbContext.Tags.ToListAsync();
        }

        //// Get: api/Tag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(long id)
        {
            var tag = await this.blogDbContext.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }

        // POST: api/Tag
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(Tag item)
        {
            this.blogDbContext.Tags.Add(item);
            await this.blogDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTag), new { id = item.Id }, item);
        }

        // PUT: api/Tag/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(long id, Tag item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            this.blogDbContext.Entry(item).State = EntityState.Modified;
            await this.blogDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Tag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(long id)
        {
            var tag = await this.blogDbContext.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            this.blogDbContext.Tags.Remove(tag);
            await this.blogDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}