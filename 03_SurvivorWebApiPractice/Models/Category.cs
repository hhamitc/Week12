namespace _03_SurvivorWebApiPractice.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; } = "";
        public List<Competitor>? Competitors { get; set; } = new List<Competitor>();
    }
}
