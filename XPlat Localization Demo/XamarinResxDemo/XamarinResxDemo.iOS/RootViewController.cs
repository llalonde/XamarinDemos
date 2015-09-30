using System;
using System.Drawing;

using Foundation;
using UIKit;
using System.Globalization;
using XamarinResxDemo.PCL;

namespace XamarinResxDemo.iOS
{
    public partial class RootViewController : UIViewController
    {
        public RootViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            //What's the current language
            var lang = NSLocale.PreferredLanguages[0];

            //setting resources in code behind
            var title = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleDisplayName");
            AppTitleLabel.Text = title.ToString();
            var ci = GetCurrentCultureInfo();
            HelloLabel.Text = TranslationHelper.GetString("Hello", ci);

            StopImage.Image = UIImage.FromBundle("stopsign");

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        private CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-");
            }
            return new CultureInfo(netLanguage);
        }

        #endregion
    }
}