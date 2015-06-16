using Android.App;
using Android.Widget;
using Android.OS;
using PostalCodes.PCL;

namespace PostalCodes.Droid
{
	[Activity (Label = "Postal Codes", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private EditText cityEdit;
		private EditText provinceEdit;
		private EditText countryEdit;
		private Button searchButton;
		private ListView searchResultsList;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource
			searchButton = FindViewById<Button> (Resource.Id.searchButton);
			cityEdit = FindViewById<EditText> (Resource.Id.cityEntry);
			provinceEdit = FindViewById<EditText> (Resource.Id.provinceEntry);
			countryEdit = FindViewById<EditText> (Resource.Id.countryEntry);

			searchButton.Click += async (s, e) =>
			{
				var service = new PostalCodeService();

				try
				{
					LocationResult result = await service.LocationQueryAsync(countryEdit.Text, provinceEdit.Text, cityEdit.Text);
					searchResultsList = this.FindViewById<ListView>(Resource.Id.locationResultsList);
					searchResultsList.Adapter = new PlaceArrayAdapter(this, result.Places);

					searchResultsList.ChoiceMode = ChoiceMode.None;

				}
				catch
				{
					DisplayMessage("Search Failed", "Unknown country, province, or city. Cannot find postal codes for this search.");
				}

			};
		}

		private void DisplayMessage(string title, string message)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder(this);

			builder.SetMessage(message)
				    .SetTitle(title);


			AlertDialog dialog = builder.Create();
			dialog.Show ();
        }
    }
}


