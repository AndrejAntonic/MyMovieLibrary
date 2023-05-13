using MyMovieLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace MyMovieLibrary.Services
{
    public class TMDB
    {
        private const string API_key = "648408758088f2196cf7f6786db82fe3";
        private const string poster = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2";

        private object AdjustPath(MovieResponse? movieResponse)
        {
            foreach (var movie in movieResponse.Results)
            {
                movie.Poster_path = poster + movie.Poster_path;
            }

            return movieResponse;
        }

        public async Task<List<DataMovies>?> GetTrendingMoviesWeek()
        {
            string url = "https://api.themoviedb.org/3/trending/movie/week?api_key=" + API_key;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(data);
                    movieResponse = (MovieResponse?)AdjustPath(movieResponse);
                    return movieResponse.Results;
                }
                else
                {
                    MessageBox.Show("Error with getting data for weekly trending movies");
                    return null;
                }
            }
        }

        public async Task GetSearchMovie(string query)
        {
            string url = "https://api.themoviedb.org/3/search/movie?api_key=" + API_key + "&language=en-US&query=" + query + "&page=1&include_adult=false";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show("Error with searching for movies");
                }
            }
        }
    }
}
