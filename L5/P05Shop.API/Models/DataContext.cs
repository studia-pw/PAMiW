using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;
using P07Shop.DataSeeder;

namespace P05Shop.API.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Song>()
                .Property(b => b.Title)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Song>()
                .Property(b => b.Duration)
                .HasColumnType("bigint")
                .IsRequired();

            modelBuilder.Entity<Song>()
                .Property(b => b.AlbumTitle)
                .HasMaxLength(50);

            modelBuilder.Entity<Song>()
                .Property(b => b.ReleaseDate)
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<Song>()
                .Property(b => b.Artist)
                .HasMaxLength(50)
                .IsRequired();

            // data seed 

            modelBuilder.Entity<Song>().HasData(SongSeeder.GenerateSongData());
        }
    }
}
// instalacja dotnet ef 
//dotnet tool install --global dotnet-ef

// aktualizacja 
//dotnet tool update --global dotnet-ef

// dotnet ef migrations add [nazwa_migracji]
// dotnet ef database update 


// cofniecie migraji niezaplikowanych 
//dotnet ef migrations remove