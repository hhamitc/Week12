namespace _02_CodeFirstRelationPractiice.Data.Entities
{
    public class PostEntity
    {
        public int Id { get; set; } //birincil anahtar ve otomatik artan.

        public string Title { get; set; } = ""; //gönderinin başlığı.

        public string Content { get; set; } = ""; //gönderinin içeriği.

        public int UserId { get; set; } //gönderinin yazarı (kullanıcının kimliği).


        public UserEntity User { get; set; }
    }
}
