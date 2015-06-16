using System;
using Newtonsoft.Json;

namespace PostalCodes.PCL
{
	public class Place
	{
		[JsonProperty("place name")]
		public string PlaceName { get; set; }

		public decimal Latitude { get; set; }

		public decimal Longitude { get; set; }

		[JsonProperty("post code")]
		public string PostalCode { get; set; }
	}
}

