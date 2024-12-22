namespace _03_SurvivorWebApiPractice.DTOs.CompetitorDtos
{
    public class CompetitorDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }

    }
}
