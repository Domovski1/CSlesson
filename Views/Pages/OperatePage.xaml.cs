using MenuList.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для OperatePage.xaml
    /// </summary>
    public partial class OperatePage : Page
    {
        public T_App Apps { get; set; }
        public List<Group> Groups { get; set; }


        public OperatePage(T_App app)
        {
            InitializeComponent();
            Apps = app;
            Groups = BaseClass.db.Group.ToList();
            this.DataContext = this;

        }
         

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Apps.ID == 0) 
                BaseClass.db.T_App.Add(Apps);
            
            BaseClass.db.SaveChanges();
            MessageBox.Show("Операция выполнена!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
