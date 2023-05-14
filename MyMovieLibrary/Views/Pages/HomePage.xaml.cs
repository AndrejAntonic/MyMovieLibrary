using MyMovieLibrary.Services;
using MyMovieLibrary.ViewModels;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : INavigableView<ViewModels.HomeViewModel>
    {
        public ViewModels.HomeViewModel ViewModel
        {
            get;
        }

        public HomePage(ViewModels.HomeViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }

        private void btnToday_Click(object sender, RoutedEventArgs e)
        {
            btnToday.Background = new SolidColorBrush(Colors.White);
            btnThisWeek.Background = new SolidColorBrush(Colors.Gray);
        }

        private void btnThisWeek_Click(object sender, RoutedEventArgs e)
        {
            btnToday.Background = new SolidColorBrush(Colors.Gray);
            btnThisWeek.Background = new SolidColorBrush(Colors.White);
        }
    }
}
