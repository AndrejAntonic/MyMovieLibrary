using CommunityToolkit.Mvvm.ComponentModel;
using MyMovieLibrary.Models;
using MyMovieLibrary.Services;
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
            var moviesCollection = new List<DataMovies>();

            var moviesTrendingWeek = await tmdb.GetTrendingMoviesWeek();

            if(moviesTrendingWeek != null)
                Movies = moviesTrendingWeek;

            _isInitialized = true;
        }
    }
}
