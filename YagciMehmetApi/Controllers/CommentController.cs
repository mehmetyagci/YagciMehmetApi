using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YagciMehmetApi.DB;
using YagciMehmetApi.Models;

namespace YagciMehmetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        public CommentController(BlogDbContext blogDbContext, IMapper mapper) :
            base(blogDbContext, mapper)
        {
            if (this.blogDbContext.Comments.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                this.blogDbContext.Comments.Add(new Comment { CommentText = "CommentText1", });
                this.blogDbContext.SaveChanges();
            }
        }

        // Get: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await this.blogDbContext.Comments.ToListAsync();
        }

        //// Get: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(long id)
        {
            var comment = await this.blogDbContext.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment item)
        {
            this.blogDbContext.Comments.Add(item);
            await this.blogDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = item.Id }, item);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(long id, Comment item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            this.blogDbContext.Entry(item).State = EntityState.Modified;
            await this.blogDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(long id)
        {
            var comment = await this.blogDbContext.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            this.blogDbContext.Comments.Remove(comment);
            await this.blogDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}