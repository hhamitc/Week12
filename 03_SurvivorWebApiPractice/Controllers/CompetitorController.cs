using _03_SurvivorWebApiPractice.Data;
using _03_SurvivorWebApiPractice.DTOs.CompetitorDtos;
using _03_SurvivorWebApiPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<CompetitorDto>> GetAllCompetitors()
        {
            List<Competitor> competitors = _context.Competitors.Include(c => c.Category).ToList();

            List<CompetitorDto> competitorDtos = new List<CompetitorDto>();

            foreach (Competitor competitor in competitors)
            {
                competitorDtos.Add(new CompetitorDto
                {
                    Id = competitor.Id,
                    FirstName = competitor.FirstName,
                    LastName = competitor.LastName,
                    CategoryId = competitor.CategoryId,
                    CategoryName = competitor.Category.Name

                });
            }

            return Ok(competitorDtos);
        }


        [HttpGet("{id:int:min(1)}")]
        public ActionResult<CompetitorDto> GetCompetitorById(int id)
        {
            Competitor? competitor = _context.Competitors.Include(c => c.Category).FirstOrDefault(c => c.Id == id);


            if (competitor == null)
            {
                return NotFound($"Yarışmacı Id {id} bulunamadı");
            }


            CompetitorDto competitorDto = new CompetitorDto
            {
                Id = competitor.Id,
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                CategoryId = competitor.CategoryId,
                CategoryName = competitor?.Category?.Name
            };

            return Ok(competitorDto);

        }

        [HttpPost]
        public IActionResult CreateCompetitor([FromBody] CreateCompetitorDto newCompetitor)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Category? category = _context.Categories.Find(newCompetitor.CategoryId);

            if (category == null)
                return BadRequest("Kategori bulunamadı.");

            Competitor competitor = new Competitor
            {
                FirstName = newCompetitor.FirstName,
                LastName = newCompetitor.LastName,
                CategoryId = newCompetitor.CategoryId
            };

            _context.Competitors.Add(competitor);

            _context.SaveChanges();

            return Created();

        }



        [HttpPut("update/{id:int:min(1)}")]
        public IActionResult UpdateCompetitor(int id, [FromBody] UpdateCompetitorDto updateCompetitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Competitor? competitor = _context.Competitors.Find(id);

            if (competitor == null)
            {
                return NotFound($"Yarışmacı Id {id} bulunamadı.");
            }


            competitor.FirstName = updateCompetitor.FirstName;
            competitor.LastName = updateCompetitor.LastName;
            competitor.CategoryId = updateCompetitor.CategoryId;
            competitor.ModifiedDate = DateTime.Now;

            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id:int:min(1)}")]
        public IActionResult DeleteCompetitor(int id)
        {
            Competitor? competitorToRemove = _context.Competitors.Find(id);

            if (competitorToRemove == null)
            {
                return NotFound($"Yarışmacı Id {id} bulunamadı.");
            }

            _context.Competitors.Remove(competitorToRemove);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
