using CommunityToolkit.Mvvm.ComponentModel;
using MyMovieLibrary.Models;
using MyMovieLibrary.Services;
using MyMovieLibrary.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;

namespace MyMovieLibrary.ViewModels
{
    public partial class HomeViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        TMDB tmdb = new TMDB(); 

        [ObservableProperty]
        private IEnumerable<DataMovies> _movies;
        [ObservableProperty]
        private IEnumerable<DataMovies> _upcomingmovies;
        [ObservableProperty]
        private IEnumerable<DataMovies> _popularmovies;
        [ObservableProperty]
        private IEnumerable<DataMovies> _nowplayingmovies;
        [ObservableProperty]
        private IEnumerable<DataMovies> _topratedmovies;

        public void OnNavigatedFrom()
        {
            
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private async void InitializeViewModel()
        {
            var moviesTrendingWeek = await tmdb.GetTrendingMoviesWeek();
            var moviesPopular = await tmdb.GetPopularMovies();
            var moviesUpcoming = await tmdb.GetUpcomingMovies();
            var moviesNowPlaying = await tmdb.GetNowPlayingMovies();
            var moviesTopRated = await tmdb.GetTopRatedMovies();

            if(moviesTrendingWeek != null)
                Movies = moviesTrendingWeek;
            if(moviesPopular != null)
                Popularmovies = moviesPopular;
            if (moviesUpcoming != null)
                Upcomingmovies = moviesUpcoming;
            if (moviesNowPlaying != null)
                Nowplayingmovies = moviesNowPlaying;
            if (moviesTopRated != null)
                Topratedmovies = moviesTopRated;

            _isInitialized = true;
        }
    }
}
