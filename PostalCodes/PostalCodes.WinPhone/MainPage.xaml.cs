using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using PostalCodes.PCL;

namespace PostalCodes.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var service = new PostalCodeService();

            try
            {
                LocationResult result = await service.LocationQueryAsync(countryText.Text, provinceText.Text, cityText.Text);
                List<string> listItems = result.Places.Select(p => p.PostalCode).ToList<string>();
                resultsList.ItemsSource = listItems;
                resultsList.UpdateLayout();
            }
            catch
            {
                MessageBox.Show("Unknown country, province, or city. Cannot find postal codes for this search.");
            }

        }
    }
}