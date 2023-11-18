using Bogus;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;

namespace P07Shop.DataSeeder
{
    public class SongSeeder
    {
        public static List<Song> GenerateSongData()
        {
            int songId = 1;
            var songFaker = new Faker<Song>()
                .UseSeed(123456)
                .RuleFor(x=>x.Title, x=>x.Commerce.ProductName())
                .RuleFor(x => x.Duration, x => x.Random.Int(30, 300))
                .RuleFor(x => x.AlbumTitle, x => x.Commerce.ProductMaterial())
                .RuleFor(x => x.ReleaseDate, x => x.Date.Past(10))
                .RuleFor(x => x.Artist, x => x.Person.FullName)
                .RuleFor(x=>x.Id, x=> songId++);

            return songFaker.Generate(30).ToList();

        }
    }
}