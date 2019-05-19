using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YagciMehmetApi.DB;
using YagciMehmetApi.DTO;
using YagciMehmetApi.Models;

namespace YagciMehmetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(BlogDbContext blogDbContext, IMapper mapper) :
            base(blogDbContext, mapper)
        {
            if (this.blogDbContext.Categories.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                this.blogDbContext.Categories.Add(new Category { Name = "Category1" });
                this.blogDbContext.SaveChanges();
            }
        }

        // Get: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var entities = await blogDbContext.Categories.ToListAsync();
            return this.mapper.Map<List<Category>, List<CategoryDTO>>(entities);
        }

        //// Get: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(long id)
        {
            var category = await blogDbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryCreateDTO item)
        {
            var entity = this.mapper.Map<Category>(item);
            this.blogDbContext.Categories.Add(entity);

            await blogDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = entity.Id }, item);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            blogDbContext.Entry(item).State = EntityState.Modified;
            await blogDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var category = await blogDbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            blogDbContext.Categories.Remove(category);
            await blogDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}