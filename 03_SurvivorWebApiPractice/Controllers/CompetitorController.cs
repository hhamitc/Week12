using _03_SurvivorWebApiPractice.Data;
using _03_SurvivorWebApiPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace _03_SurvivorWebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {

        private readonly CompetitorCategoryContext _context;

        public CompetitorController(CompetitorCategoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Competitor> GetAllCompetitors()
        {
            var competitors = _context.Competitors.ToList();

            return competitors;
        }

        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Competitor> GetCompetitorById(int id)
        {
            var competitor = _context.Competitors.Find(id);

            if (competitor == null)
            {
                return NotFound($"Yarışmacı Id {id} bulunamadı");
            }

            return Ok(competitor);

        }

        [HttpPost]
        public ActionResult<Competitor> CreateCompetitor([FromBody] Competitor competitor)
        {
            _context.Competitors.Add(competitor);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCompetitorById), new { id = competitor.Id }, competitor);
        }

        [HttpPut("update/{id:int:min(1)}")]
        public IActionResult UpdateCompetitor(int id, [FromBody] Competitor competitor)
        {
            var competitorToUpdate = _context.Competitors.Find(id);

            if (competitor == null)
            {
                return NotFound($"Yarışmacı Id {id} bulunamadı.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            competitorToUpdate.FirstName = competitor.FirstName;
            competitorToUpdate.LastName = competitor.LastName;
            competitorToUpdate.CategoryId = competitor.CategoryId;
            competitorToUpdate.ModifiedDate = DateTime.Now;

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
                return NotFound($"Yarışmacı Id {id} bulunamadı.");
            }

            _context.Categories.Remove(categoryToRemove);
            _context.SaveChanges();
            return NoContent();
        }




    }
}
