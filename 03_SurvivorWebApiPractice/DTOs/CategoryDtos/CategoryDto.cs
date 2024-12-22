using _03_SurvivorWebApiPractice.DTOs.CompetitorDtos;

namespace _03_SurvivorWebApiPractice.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CompetitorDto> Competitors { get; set; }
    }
}
