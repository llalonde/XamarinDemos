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

namespace XamarinResxDemo.iOS
{
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AppTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel HelloLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView StopImage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AppTitleLabel != null) {
				AppTitleLabel.Dispose ();
				AppTitleLabel = null;
			}
			if (HelloLabel != null) {
				HelloLabel.Dispose ();
				HelloLabel = null;
			}
			if (StopImage != null) {
				StopImage.Dispose ();
				StopImage = null;
			}
		}
	}
}
