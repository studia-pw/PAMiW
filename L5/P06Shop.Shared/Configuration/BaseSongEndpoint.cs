using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Configuration
{
    public class BaseSongEndpoint
    {
        public string Base_url { get; set; }
        public string GetAllSongsEndpoint { get; set; }
        public string GetSongEndpoint { get; set; }
        public string DeleteSongEndpoint { get; set; }
        public string UpdateSongEndpoint { get; set; }
        public string CreateSongEndpoint { get; set; }
    }
}
