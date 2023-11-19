using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.SongModel
{
    public class Song
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public long Duration { get; set; }

        public string? AlbumTitle { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Artist { get; set; }

    }
}
