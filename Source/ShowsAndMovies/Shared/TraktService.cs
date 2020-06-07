﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktNet;
using TraktNet.Objects.Get.Movies;
using TraktNet.Objects.Get.Shows;
using TraktNet.Requests.Parameters;
using TraktNet.Responses;

namespace ShowsAndMovies.Shared
{
    public class TraktService
    {
        private static readonly TraktClient _client = new TraktClient("", "");

        public static async Task<List<ITraktTrendingShow>> GetTrendingShowsAsync()
        {
            TraktPagedResponse<ITraktTrendingShow> trendingShows = await _client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo { Full = true });
            return trendingShows.ToList();
        }

        public static async Task<List<ITraktTrendingMovie>> GetTrendingMoviesAsync()
        {
            TraktPagedResponse<ITraktTrendingMovie> trendingMovies = await _client.Movies.GetTrendingMoviesAsync(new TraktExtendedInfo { Full = true });
            return trendingMovies.ToList();
        }
    }
}
