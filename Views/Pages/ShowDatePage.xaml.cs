using MenuList.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MenuList.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowDatePage.xaml
    /// </summary>
    public partial class ShowDatePage : Page
    {
        
        public ObservableCollection<T_App> Apps { get; set; }


        public ShowDatePage()
        {
            InitializeComponent();
            Apps = new ObservableCollection<T_App>(BaseClass.db.T_App.ToList());
            DataContext = this;
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        } 

        /// <summary>
        /// Логика ТекстБокса для поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateList.ItemsSource = BaseClass.db.T_App.Where(x => x.Title.Contains(TxbSearch.Text) || x.Group.Title.Contains(TxbSearch.Text)).ToList();
        }


        /// <summary>
        /// Логика для удаления данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                int id = (DateList.SelectedItem as T_App).ID;
                var del = BaseClass.db.T_App.Where(m => m.ID == id).Single();   
                BaseClass.db.T_App.Remove(del);
                MessageBox.Show("Данные удалены");
                BaseClass.db.SaveChanges();
                Apps = new ObservableCollection<T_App>(BaseClass.db.T_App.ToList());

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OperatePage((T_App)DateList.SelectedItem));
        }

    }
}
