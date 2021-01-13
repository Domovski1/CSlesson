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

namespace MenuList.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void ShowDate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowDatePage());
        }

        private void AddDate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateDatePage());
        }

        private void CreateData_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OperatePage(new Base.T_App()));
        }

        private void ShowDataGrid_Click(object sender, RoutedEventArgs e)
        {
            GridWind wind = new GridWind();
            wind.Show();
        }

        private void btnHttp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HttpPage());
        }
    }
}
