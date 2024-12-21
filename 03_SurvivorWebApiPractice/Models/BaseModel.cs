namespace _03_SurvivorWebApiPractice.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CretedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
