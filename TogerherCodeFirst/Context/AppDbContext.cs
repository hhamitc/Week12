using Microsoft.EntityFrameworkCore;
using TogetherCodeFirst.Models;

namespace TogetherCodeFirst.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<StudentEntity> Students { get; set; } // StudentEntity yapılarının tutulacağı veritablonuzun adını Students olarak belirlediniz.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // @ -> ters slash sorun yaratmasın diye.

            // Windows Authentication için
            //optionsBuilder.UseSqlServer(@"server=LAPTOP-MCRDNKOK\SQLEXPRESS; database=PatikaFirstDB;        Trusted_Connection=true; TrustServerCertificate=true");

            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS; database=PatikaFirstDB;   Trusted_Connection=true; TrustServerCertificate=true");

            // Sql Server Authentication için
            // optionsBuilder.UseSqlServer(@"server=SrtnWorkBook-2; database=PatikaFirstDB; uid=sa; pwd=sa; TrustServerCertificate=true");


            base.OnConfiguring(optionsBuilder);
        }
    }
}
