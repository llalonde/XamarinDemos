// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PostalCodes.iOS
{
	[Register ("PostalCodes_iOSViewController")]
	partial class PostalCodes_iOSViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField cityText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField countryText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView placesTable { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField provinceText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton searchButton { get; set; }

		[Action ("searchButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void searchButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (cityText != null) {
				cityText.Dispose ();
				cityText = null;
			}
			if (countryText != null) {
				countryText.Dispose ();
				countryText = null;
			}
			if (placesTable != null) {
				placesTable.Dispose ();
				placesTable = null;
			}
			if (provinceText != null) {
				provinceText.Dispose ();
				provinceText = null;
			}
			if (searchButton != null) {
				searchButton.Dispose ();
				searchButton = null;
			}
		}
	}
}
