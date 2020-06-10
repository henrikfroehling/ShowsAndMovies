using System.Collections.Generic;
using System.Threading.Tasks;
using TraktNet.Objects.Get.Movies;
using TraktNet.Objects.Get.Shows;

namespace ShowsAndMovies.Services.Trakt
{
    public interface ITraktService
    {
        Task<List<ITraktTrendingShow>> GetTrendingShowsAsync();

        Task<List<ITraktTrendingMovie>> GetTrendingMoviesAsync();

        Task<ITraktShow> GetShowDetails(string slug);
    }
}
