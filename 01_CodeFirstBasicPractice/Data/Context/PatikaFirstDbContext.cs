using _01_CodeFirstBasicPractice.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_CodeFirstBasicPractice.Data.Context
{
    public class PatikaFirstDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS; database=PatikaFirstDB1;   Trusted_Connection=true; TrustServerCertificate=true");

            //optionsBuilder.UseSqlServer(@"server=LAPTOP-MCRDNKOK\SQLEXPRESS; database=PatikaFirstDB1; Trusted_Connection=true; TrustServerCertificate=true");

            base.OnConfiguring(optionsBuilder);
        }




    }
}
