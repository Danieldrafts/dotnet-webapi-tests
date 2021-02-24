using dotnet_webapi.Data;
using dotnet_webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_webapi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context=context;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var category = await _context.Categories.ToListAsync();
            return category;
        }


        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(Category model)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(model);
                await _context.SaveChangesAsync(); //usado para o banco InMemory
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}