using MenuList.Base;
using MenuList.Views.Pages;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace MenuList.Views
{

    public partial class GridWind : Window
    {
        public ObservableCollection<T_App> Apps { get; set; }
        public List<Group> Groups { get; set; }

        public GridWind()
        {
            InitializeComponent();
            Apps = new ObservableCollection<T_App>(BaseClass.db.T_App.ToList());
            DataContext = this;
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (MyGrid.SelectedItem as T_App).ID;
            var del = BaseClass.db.T_App.Where(x => x.ID == id).Single();
            MessageBoxResult result = MessageBox.Show("Удалить?", "Вы уверены, что хотите удалить выбранный элемент?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Item was deleted");
                Apps.Remove(del);
            }

            //BaseClass.db.SaveChanges();
            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BaseClass.db.SaveChanges();
        }


        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.CancelEdit();
        }
    }
}
