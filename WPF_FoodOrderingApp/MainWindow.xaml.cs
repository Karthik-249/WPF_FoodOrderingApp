using System.Windows;
using System.Windows.Media;
using WPF_FoodOrderingApp.ViewModels;

namespace WPF_FoodOrderingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MenuCategoriesListView.Focus();
        }
    }
}