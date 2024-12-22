using _03_SurvivorWebApiPractice.Data;
using _03_SurvivorWebApiPractice.DTOs.CategoryDtos;
using _03_SurvivorWebApiPractice.DTOs.CompetitorDtos;
using _03_SurvivorWebApiPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<CategoryDto>> GetAllCategories()
        {
            List<Category> categories = _context.Categories.Include(c => c.Competitors).ToList();

            List<CategoryDto> categoriesDto = new List<CategoryDto>();


            foreach (Category category in categories)
            {

                List<CompetitorDto> competitors = new List<CompetitorDto>();

                foreach (Competitor competitor in category.Competitors)
                {

                    competitors.Add(new CompetitorDto { Id = competitor.Id, FirstName = competitor.FirstName, LastName = competitor.LastName });
                }

                categoriesDto.Add(new CategoryDto
                {
                    Name = category.Name,
                    Id = category.Id,
                    Competitors = competitors

                });
            }

            return Ok(categoriesDto);
        }

        [HttpGet("{id:int:min(1)}")]
        public ActionResult<CategoryDto> GetCategoryById(int id)
        {
            Category? category = _context.Categories.Include(c => c.Competitors).FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound($"Kategori Id {id} bulunamadı");
            }

            List<CompetitorDto> competitors = new List<CompetitorDto>();

            foreach (Competitor competitor in category.Competitors)
            {

                competitors.Add(new CompetitorDto { Id = competitor.Id, FirstName = competitor.FirstName, LastName = competitor.LastName });
            }

            CategoryDto categoryDto = new CategoryDto
            {
                Name = category.Name,
                Id = category.Id,
                Competitors = competitors
            };

            return Ok(categoryDto);

        }

        [HttpPost]
        public ActionResult<CategoryDto> CreateCategory([FromBody] CreateCategoryDto newCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Category category = new Category
            {
                Name = newCategory.Name,
            };


            _context.Categories.Add(category);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }



        [HttpPut("update/{id:int:min(1)}")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Category? category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound($"Kategori Id {id} bulunamadı.");
            }


            category.Name = updateCategory.Name;
            category.ModifiedDate = DateTime.Now;

            _context.SaveChanges();

            return NoContent();
        }




        [HttpDelete("{id:int:min(1)}")]
        public IActionResult DeleteCompetitor(int id)
        {
            Category? category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound($"Kategori Id {id} bulunamadı.");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
