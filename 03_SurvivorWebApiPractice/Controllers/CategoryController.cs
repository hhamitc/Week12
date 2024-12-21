using _03_SurvivorWebApiPractice.Data;
using _03_SurvivorWebApiPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace _03_SurvivorWebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CompetitorCategoryContext _context;

        public CategoryController(CompetitorCategoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> GetAllCategories()
        {
            var categories = _context.Categories.ToList();

            return categories;
        }

        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound($"Kategori Id {id} bulunamadı");
            }

            return Ok(category);

        }

        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category category)
        {
            _context.Categories.Add(category);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("update/{id:int:min(1)}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            var categoryToUpdate = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound($"Kategori Id {id} bulunamadı.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            categoryToUpdate.Name = category.Name;
            categoryToUpdate.ModifiedDate = DateTime.Now;

            _context.SaveChanges();

            //return NoContent();
            return NoContent();
        }

        [HttpDelete("{id:int:min(1)}")]
        public IActionResult DeleteCompetitor(int id)
        {
            var categoryToRemove = _context.Categories.Find(id);

            if (categoryToRemove == null)
            {
                return NotFound($"Kategori Id {id} bulunamadı.");
            }

            _context.Categories.Remove(categoryToRemove);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
