using _03_SurvivorWebApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_SurvivorWebApiPractice.Data
{
    public class CompetitorCategoryContext : DbContext
    {
        public CompetitorCategoryContext(DbContextOptions<CompetitorCategoryContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Competitor> Competitors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS; database=SurvivorDb; Trusted_Connection=true; TrustServerCertificate=true"); //ConnectionString

            //optionsBuilder.UseSqlServer(@"server=LAPTOP-MCRDNKOK\SQLEXPRESS; database=SurvivorDb; Trusted_Connection=true; TrustServerCertificate=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkileri tanımlama
            modelBuilder.Entity<Competitor>()
                .HasOne(co => co.Category) // Her Yarışmacının bir Kategorisi vardır
                .WithMany(ca => ca.Competitors)// Bir Kategorinin birden fazla yarışmacısı olabilir
                .HasForeignKey(co => co.CategoryId); // Yarışmacıların kategorileri CategoryId ile belirlenir.


            //modelBuilder.Entity<Category>()
            //    .HasMany(ca => ca.Competitors) // Bir kategorinin biden çok Yarışmacısı vardır.
            //    .WithOne(co => co.Category)   // Her yarışmacının sadece bir kategorisi vardır.
            //    .HasForeignKey(co => co.CategoryId); //  Yarışmacıların kategorileri CategoryId ile belirlenir.


            modelBuilder.Entity<Category>()
               .HasData(
                   new Category { Id = 1, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, Name = "Ünlüler" },
                   new Category { Id = 2, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, Name = "Gönüllüler" }
               );

            modelBuilder.Entity<Competitor>()
               .HasData(
                   new Competitor { Id = 1, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Acun", LastName = "Ilıcalı", CategoryId = 1 },
                   new Competitor { Id = 2, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Aleyna", LastName = "Avcı", CategoryId = 1 },
                   new Competitor { Id = 3, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Hadise", LastName = "Açıkgöz", CategoryId = 1 },
                   new Competitor { Id = 4, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Sertan", LastName = "Bozkuş", CategoryId = 1 },
                   new Competitor { Id = 5, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Özge", LastName = "Açık", CategoryId = 1 },
                   new Competitor { Id = 6, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Kıvanç", LastName = "Tatlıtuğ", CategoryId = 1 },
                   new Competitor { Id = 7, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Ahmet", LastName = "Yılmaz", CategoryId = 2 },
                   new Competitor { Id = 8, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Elif", LastName = "Demirtaş", CategoryId = 2 },
                   new Competitor { Id = 9, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Cem", LastName = "Öztürk", CategoryId = 2 },
                   new Competitor { Id = 10, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00), IsDeleted = false, FirstName = "Ayşe", LastName = "Karaca", CategoryId = 2 }
               );


            base.OnModelCreating(modelBuilder);
        }
    }
}
