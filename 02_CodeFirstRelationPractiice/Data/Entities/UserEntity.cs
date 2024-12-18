using System.ComponentModel.DataAnnotations;

namespace _02_CodeFirstRelationPractiice.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; } //birincil anahtar ve otomatik artan.

        public string Username { get; set; } = ""; //kullanıcının kullanıcı adı.


        public string Email { get; set; } = ""; //kullanıcının e-posta adresi.

        public List<PostEntity> Posts { get; set; }

    }
}
