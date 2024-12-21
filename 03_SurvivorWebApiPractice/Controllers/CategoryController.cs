using _03_SurvivorWebApiPractice.Data;
using Microsoft.AspNetCore.Mvc;

namespace _03_SurvivorWebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CompetitorCategoryContext _context;

        public CategoryController(SurvivorDbContext context)
        {
            _context = context;
        }


    }
}
