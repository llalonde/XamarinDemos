
using Android.App;
using Android.Widget;
using Android.OS;
using XamarinResxDemo.PCL;

namespace XamarinResxDemo.Droid
{
	[Activity (Label = "Resx Localization Demo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            var ci = new System.Globalization.CultureInfo(netLanguage);

            //setting resources in code behind
            TextView textView = this.FindViewById<TextView>(Resource.Id.GreetingTextView);
            textView.Text = TranslationHelper.GetString("Hello", ci);

            ImageView imageView = this.FindViewById<ImageView>(Resource.Id.StopImageView);
            imageView.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.stopsign));

		}
	}
}


