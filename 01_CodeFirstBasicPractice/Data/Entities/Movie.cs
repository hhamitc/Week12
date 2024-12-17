using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_CodeFirstBasicPractice.Data.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int Id { get; set; } //birincil anahtar ve otomatik artan.
        public string Title { get; set; }//filmin başlığı.
        public string Genre { get; set; }//filmin türü (örneğin: "Action", "Comedy", "Drama").
        public int ReleaseYear { get; set; }// filmin çıkış yılı.
    }
}
