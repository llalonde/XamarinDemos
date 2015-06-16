using System;
using Android.App;
using System.Collections.Generic;
using PostalCodes.PCL;
using Android.Widget;
using Android.Views;

namespace PostalCodes.Droid
{
	public class PlaceArrayAdapter : ArrayAdapter<Place>
	{
		public PlaceArrayAdapter(Activity context, IList<Place> places)
			: base(context, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, places)
		{
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var currentPlace = GetItem(position);

			var layoutInflater = (LayoutInflater) Application.Context.GetSystemService(Android.Content.Context.LayoutInflaterService);
			View searchItemResultLayout = layoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

			var searchItemView = searchItemResultLayout.FindViewById<TextView>(Android.Resource.Id.Text1);
			searchItemView.Text = currentPlace.PostalCode;

			return searchItemResultLayout;
		}

	}
}

