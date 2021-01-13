using MenuList.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MenuList.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateDatePage.xaml
    /// </summary>
    public partial class CreateDatePage : Page 
    {
        public CreateDatePage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Ограничение на ввод цифр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }


        /// <summary>
        /// Логика кнопки назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        /// <summary>
        /// Логика кнопки генерации данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {

            int CountNewApp = Convert.ToInt32(TxbCount.Text);

            T_App ap = new T_App();
            Random rand = new Random();


            // Массив программ
            string[] AppList = new string[20] {
            "Photoshop",
            "cmd",
            "PowerShell",
            "Excel",
            "Word",
            "Visual Studio",
            "Visual Code",
            "MS SQL",
            "Google Chrome",
            "GitHub",
            "Discord",
            "Telegram",
            "Whats App",
            "YouTube",
            "VK Messenger",
            "Paint",
            "Microsoft Edge",
            "Picasa",
            "Visio",
            "Проводник"
            };

            //Цикл генерции
            for (int i = 0; i < CountNewApp; i++)
            {

                try
                {
                    ap.Title = AppList[rand.Next(20)];
                    ap.GroupID = rand.Next(1, 5);
                    BaseClass.db.T_App.Add(ap);
                    BaseClass.db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            
            MessageBox.Show("Успех",
                            "Данные успешно добавлены!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

            NavigationService.Navigate(new ShowDatePage());
        }
    }
}
