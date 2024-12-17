using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_CodeFirstBasicPractice.Data.Entities
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int Id { get; set; } //birincil anahtar ve otomatik artan.
        public string Name { get; set; } // oyunun adı.
        public string Platform { get; set; }// oyunun oynandığı platform (örneğin: "PC", "PlayStation", "Xbox").
        public decimal Rating { get; set; }//oyunun puanı (0 ile 10 arasında).
    }
}
