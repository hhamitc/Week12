namespace _03_SurvivorWebApiPractice.Models
{
    public class Competitor : BaseModel
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
