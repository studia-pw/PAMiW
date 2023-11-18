using Microsoft.EntityFrameworkCore;
using P07Shop.DataSeeder;
using P06Shop.Shared.SongModel;

namespace P05Shop.API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
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
            
            modelBuilder.Entity<Song>().HasData(
                SongSeeder.GenerateSongData()
            );
        }
        
    }
}