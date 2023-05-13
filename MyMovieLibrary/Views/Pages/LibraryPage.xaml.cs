using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common.Interfaces;

namespace MyMovieLibrary.Views.Pages
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : INavigableView<ViewModels.LibraryViewModel>
    {
        public ViewModels.LibraryViewModel ViewModel
        {
            get;
        }

        public LibraryPage(ViewModels.LibraryViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}
