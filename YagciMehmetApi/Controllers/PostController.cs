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
    public class PostController : BaseController
    {
        public PostController(BlogDbContext blogDbContext, IMapper mapper) :
            base(blogDbContext, mapper)
        {
            if (this.blogDbContext.Posts.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                this.blogDbContext.Posts.Add(new Post { Title = "Title1", Content = "Content1" });
                this.blogDbContext.SaveChanges();
            }
        }

        // Get: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await this.blogDbContext.Posts.ToListAsync();
        }

        //// Get: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            var post = await this.blogDbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST: api/Post
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post item)
        {
            this.blogDbContext.Posts.Add(item);
            await this.blogDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = item.Id }, item);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(long id, Post item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            this.blogDbContext.Entry(item).State = EntityState.Modified;
            await this.blogDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(long id)
        {
            var post = await this.blogDbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            this.blogDbContext.Posts.Remove(post);
            await this.blogDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}