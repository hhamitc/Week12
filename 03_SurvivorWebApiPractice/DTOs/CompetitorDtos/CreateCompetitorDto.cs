using System.ComponentModel.DataAnnotations;

namespace _03_SurvivorWebApiPractice.DTOs.CompetitorDtos
{
    public class CreateCompetitorDto
    {
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public int CategoryId { get; set; }
    }
}
