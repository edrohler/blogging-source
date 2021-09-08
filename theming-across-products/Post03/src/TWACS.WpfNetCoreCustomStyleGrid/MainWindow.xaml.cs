using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using TBACS.BlazorGridCustomStyle.Shared;
using Telerik.Reporting;

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

        public async Task<List<Product>> GetDataAsync()
        {
            string json = await new HttpClient().GetStringAsync("https://sampledataapi.azurewebsites.net/api/v1/Products");
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public async Task<List<string>> GetReportFilesAsync()
        {
            /*  
                The HttpClient RequestURI is set to the localhost and port of the TBACS.BlazorGridCustomStyle.Server
                This may change for each development environment.
                See the launchSettings.json for what to change this to 
            */
            string json = await new HttpClient().GetStringAsync("https://localhost:44380/api/files");
            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        private async void RadComboBox1_Loaded(object sender, RoutedEventArgs e)
        {
            RadComboBox1.ItemsSource = await GetReportFilesAsync();
            RadComboBox1.SelectedIndex = 1;

            reportViewer1.ReportSource = new UriReportSource
            {
                Uri = RadComboBox1.SelectedItem as string
            };
        }

        private async void RadGridView1_Loaded(object sender, RoutedEventArgs e)
        {
            RadGridView1.ItemsSource = await GetDataAsync();
        }

        private void RadComboBox1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            reportViewer1.ReportSource = new UriReportSource
            {
                Uri = RadComboBox1.SelectedItem as string
            };
        }
    }
}
