using System.ComponentModel.DataAnnotations;

namespace _03_SurvivorWebApiPractice.DTOs.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "İsim alanı zorunludur!")]
        public string Name { get; set; }

    }
}
