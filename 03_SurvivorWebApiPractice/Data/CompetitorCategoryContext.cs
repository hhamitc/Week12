using _03_SurvivorWebApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_SurvivorWebApiPractice.Data
{
    public class CompetitorCategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Competitor> Competitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS; database=PatikaCodeFirstDb2; Trusted_Connection=true; TrustServerCertificate=true"); //ConnectionString

            //optionsBuilder.UseSqlServer(@"server=LAPTOP-MCRDNKOK\SQLEXPRESS; database=PatikaFirstDB1; Trusted_Connection=true; TrustServerCertificate=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkileri tanımlama
            modelBuilder.Entity<Competitor>()
                .HasOne(co => co.Category) // Her Yarışmacının bir Kategorisi vardır
                .WithMany(ca => ca.Competitors)// Bir Kategorinin birden fazla yarışmacısı olabilir
                .HasForeignKey(co => co.CategoryId); // Yarışmacıların kategorileri CategoryId ile belirlenir.


            modelBuilder.Entity<Category>()
                .HasMany(ca => ca.Competitors) // Bir kategorinin biden çok Yarışmacısı vardır.
                .WithOne(co => co.Category)   // Her yarışmacının sadece bir kategorisi vardır.
                .HasForeignKey(co => co.CategoryId); //  Yarışmacıların kategorileri CategoryId ile belirlenir.


            base.OnModelCreating(modelBuilder);
        }
    }
}
