using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для HttpPage.xaml
    /// </summary>
    public partial class HttpPage : Page
    {
        public HttpPage()
        {
            InitializeComponent();
        }

        private async void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var request = new HttpClient();
                if (TxbRequest.Text.Contains("jpg") || TxbRequest.Text.Contains("png"))
                {
                    Loading.Source = null;
                    ImgBox.Source = new BitmapImage(new Uri(TxbRequest.Text));

                } else
                {
                    string icoPath = @"C:\Users\Domovski\Desktop\Load.gif";
                    Loading.Source =new Uri(icoPath);
                    
                    
                    request.BaseAddress = new Uri(TxbRequest.Text);

                    var response = await request.GetAsync(request.BaseAddress);
                    var result = await response.Content.ReadAsStringAsync();

                    FlowDocument fdoc = new FlowDocument();
                    fdoc.Blocks.Add(new Paragraph(new Run(result)));
                    RtbResult.Document = fdoc;
                    Loading.Source = null;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void Loading_MediaEnded(object sender, RoutedEventArgs e)
        {
            Loading.Position = new TimeSpan(0, 1, 0);
            Loading.Play();
        }
    }
}
