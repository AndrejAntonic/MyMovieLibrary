using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyMovieLibrary.Models;
using MyMovieLibrary.Services;
using MyMovieLibrary.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;

namespace MyMovieLibrary.ViewModels
{
    public partial class HomeViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        TMDB tmdb = new TMDB();
        private List<DataMovies>? moviesTrendingToday;
        private List<DataMovies>? moviesTrendingWeek;
        private List<DataMovies>? moviesPopular;
        private List<DataMovies>? moviesUpcoming;
        private List<DataMovies>? moviesNowPlaying;
        private List<DataMovies>? moviesTopRated;

        [ObservableProperty]
        private IEnumerable<DataMovies> _trendingmovies;
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
            moviesTrendingToday = await tmdb.GetTrendingMoviesToday();
            moviesTrendingWeek = await tmdb.GetTrendingMoviesWeek();
            moviesPopular = await tmdb.GetPopularMovies();
            moviesUpcoming = await tmdb.GetUpcomingMovies();
            moviesNowPlaying = await tmdb.GetNowPlayingMovies();
            moviesTopRated = await tmdb.GetTopRatedMovies();

            if (moviesTrendingToday != null)
                Trendingmovies = moviesTrendingToday;
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

        public ICommand TrendingTodayCommand => new RelayCommand(SetTrendingToToday);
        private void SetTrendingToToday()
        {
            if(moviesTrendingToday != null)
            {
                Trendingmovies = moviesTrendingToday;
            }    
        }

        public ICommand TrendingWeekCommand => new RelayCommand(SetTrendingToThisWeek);
        private void SetTrendingToThisWeek()
        {
            if (moviesTrendingWeek != null)
            {
                Trendingmovies = moviesTrendingWeek;
            }
        }

    }
}
