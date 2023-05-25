using P03WeatherForecastWPF.Services;
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

namespace P03WeatherForecastWPF
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

        private void btnGetTemperature_Click(object sender, RoutedEventArgs e)
        {
            WeatherForecastService wfs = new WeatherForecastService();
            tbTemperature.Text = "";
            string[] cities = txtCity.Text.Split(Environment.NewLine);
            foreach (var city in cities)
            {
                int temp = wfs.GetTemperature(city);
                tbTemperature.Text+= $"Temperature in {city} is {temp} C" + Environment.NewLine;
            } 
        }

        // Scenariusz: wywołanie asynchronicznie jedno miasto po drugim
        // 
        private async void btnGetTemperatureAsnyc1_Click(object sender, RoutedEventArgs e)
        {
            WeatherForecastService wfs = new WeatherForecastService();
            tbTemperature.Text = "";
            lvLogger.Items.Clear();
            string[] cities = txtCity.Text.Split(Environment.NewLine);
            foreach (var city in cities)
            {
                var t= await Task.Run<int>(() =>  // to co jest w ciele bedzie wykonane asynchrodnicznie 
                {
                    int temp = wfs.GetTemperature(city);
                    return temp;
                });

                tbTemperature.Text += $"Temperature in {city} is {t} C" + Environment.NewLine;
                lvLogger.Items.Add($"Currently processing : {city}");
            }
        }

        private async void btnGetTemperatureAsnyc2_Click(object sender, RoutedEventArgs e)
        {
            WeatherForecastService wfs = new WeatherForecastService();
            tbTemperature.Text = "";
            lvLogger.Items.Clear();
            string[] cities = txtCity.Text.Split(Environment.NewLine);

            List<Task<int>> tasks = new List<Task<int>>();
            foreach (var city in cities)
            {
                var t = Task.Run<int>(() =>  // to co jest w ciele bedzie wykonane asynchrodnicznie 
                {
                    int temp = wfs.GetTemperature(city);
                    return temp;
                });
                tasks.Add(t);
            }

            // koniec petli. wszystkie zadania zostaly dodane do listy 
            // i w tle spokojnie sie wykonuja 

            lvLogger.Items.Add("Started processing all cities");
            await Task.WhenAll(tasks); // czekamy az wszystkie zadania sie wykonaja 
            lvLogger.Items.Add("finished processing all cities");

            foreach (var task in tasks)
            {
                // tbTemperature.Text += $"Temperature in {city} is {t} C" + Environment.NewLine;

                int temp = task.Result;
               // int temp = ((Task<int>)task).Result;
                tbTemperature.Text += $"Temperature in ... is {temp} C" + Environment.NewLine;
            }

        }

        //class ExtendedResult
        //{
        //    public string City { get; set; }
        //    public int Temperature { get; set; }
        //}

        private async void btnGetTemperatureAsnyc3_Click(object sender, RoutedEventArgs e)
        {
            WeatherForecastService wfs = new WeatherForecastService();
            tbTemperature.Text = "";
            lvLogger.Items.Clear();
            string[] cities = txtCity.Text.Split(Environment.NewLine);

            //List<Task<ExtendedResult>> tasks = new List<Task<ExtendedResult>>();
            var tasks = new List<Task>();
            foreach (var city in cities)
            {
                var t = Task.Run(() =>  // to co jest w ciele bedzie wykonane asynchrodnicznie 
                {
                    int temp = wfs.GetTemperature(city);
                    return (temp, city);
                });
                tasks.Add(t);
            }

            // koniec petli. wszystkie zadania zostaly dodane do listy 
            // i w tle spokojnie sie wykonuja 

            lvLogger.Items.Add("Started processing all cities");
            await Task.WhenAll(tasks); // czekamy az wszystkie zadania sie wykonaja 
            lvLogger.Items.Add("finished processing all cities");

            foreach (Task<(int Temperature,string City)> task in tasks)
            {
                // tbTemperature.Text += $"Temperature in {city} is {t} C" + Environment.NewLine;

                int temp = task.Result.Temperature;
                string cityName= task.Result.City;
                // int temp = ((Task<int>)task).Result;
                tbTemperature.Text += $"Temperature in {cityName} is {temp} C" + Environment.NewLine;
            }
        }
    }
}
