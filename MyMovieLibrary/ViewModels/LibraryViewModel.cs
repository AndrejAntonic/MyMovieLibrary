using CommunityToolkit.Mvvm.ComponentModel;
using MyMovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Wpf.Ui.Common.Interfaces;

namespace MyMovieLibrary.ViewModels
{
    public partial class LibraryViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

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

        private void InitializeViewModel()
        {
            var moviesCollection = new List<DataMovies>();

            moviesCollection.Add(new DataMovies
            {
                Original_title = "Avatar",
                Image = "../../Assets/jRXYjXNq0Cs2TcJjLkki24MLp7u.jpg"
            });

            Movies = moviesCollection;

            _isInitialized = true;
        }
    }
}
