using System.ComponentModel.DataAnnotations;

namespace _03_SurvivorWebApiPractice.DTOs.CategoryDtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
