using System;
using System.Linq;
using UIKit;
using PostalCodes.PCL;

namespace PostalCodes.iOS
{
	public partial class PostalCodes_iOSViewController : UIViewController
	{
		public PostalCodes_iOSViewController (IntPtr handle) : base (handle)
		{
		}


		partial void searchButton_TouchUpInside (UIButton sender)
		{
			SearchPostalCodes();
		}

		private async void SearchPostalCodes()
		{
			var service = new PostalCodeService();

			try
			{
				LocationResult result = await service.LocationQueryAsync(countryText.Text, provinceText.Text, cityText.Text);

				string[] tableItems = result.Places.Select(p => p.PostalCode).ToArray<string>();

				placesTable.Source = new TableSource(tableItems);
				placesTable.ReloadData();

			}
			catch
			{
				UIAlertView alert = new UIAlertView ("Search Failed",
					"Unknown country, province, or city. Cannot find postal codes for this search.", null, "OK", null);
				alert.Show();
			}


		}
	}
}

