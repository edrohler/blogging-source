using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using TBACS.BlazorGridCustomStyle.Shared;

namespace TWACS.WpfNetCoreCustomStyleGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static async Task<List<Product>> GetDataAsync()
        {
            string json = await new HttpClient().GetStringAsync("https://sampledataapi.azurewebsites.net/api/v1/Products");
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        private async void RadGridView1_Loaded(object sender, RoutedEventArgs e)
        {
            RadGridView1.ItemsSource = await GetDataAsync();
        }
    }
}
