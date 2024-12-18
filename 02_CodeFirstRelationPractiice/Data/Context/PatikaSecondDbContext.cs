using _02_CodeFirstRelationPractiice.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _02_CodeFirstRelationPractiice.Data.Context
{
    public class PatikaSecondDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS; database=PatikaCodeFirstDb2; Trusted_Connection=true; TrustServerCertificate=true"); //ConnectionString

            //optionsBuilder.UseSqlServer(@"server=LAPTOP-MCRDNKOK\SQLEXPRESS; database=PatikaFirstDB1; Trusted_Connection=true; TrustServerCertificate=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkileri tanımlama
            modelBuilder.Entity<PostEntity>()
                .HasOne(p => p.User) // Her gönderinin bir kullanıcısı vardır
                .WithMany(u => u.Posts)// Bir kullanıcının birden fazla gönderisi olabilir
                .HasForeignKey(p => p.UserId); // Gönderilerin kullanıcıları UserId ile belirlenir.



            base.OnModelCreating(modelBuilder);
        }


    }
}
