using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktNet;
using TraktNet.Objects.Get.Movies;
using TraktNet.Objects.Get.Shows;
using TraktNet.Requests.Parameters;
using TraktNet.Responses;

namespace ShowsAndMovies.Services.Trakt
{
    public class TraktService : ITraktService
    {
        private readonly TraktClient _client;

        public TraktService()
        {
            _client = new TraktClient("", "");
        }

        public async Task<List<ITraktTrendingShow>> GetTrendingShowsAsync()
        {
            TraktPagedResponse<ITraktTrendingShow> trendingShows = await _client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo { Full = true });
            return trendingShows.ToList();
        }

        public async Task<List<ITraktTrendingMovie>> GetTrendingMoviesAsync()
        {
            TraktPagedResponse<ITraktTrendingMovie> trendingMovies = await _client.Movies.GetTrendingMoviesAsync(new TraktExtendedInfo { Full = true });
            return trendingMovies.ToList();
        }

        public async Task<ITraktShow> GetShowDetails(string slug)
        {
            return (await _client.Shows.GetShowAsync(slug, new TraktExtendedInfo { Full = true })).Value;
        }

        public async Task<ITraktMovie> GetMovieDetails(string slug)
        {
            return (await _client.Movies.GetMovieAsync(slug, new TraktExtendedInfo { Full = true })).Value;
        }
    }
}
