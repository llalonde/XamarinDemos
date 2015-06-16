using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PostalCodes.PCL
{
	public class LocationResult
	{
		public string Country { get; set; }

		[JsonProperty("country abbreviation")]
		public string CountryAbbreviation { get; set; }

		public string State { get; set; }

		[JsonProperty("state abbreviation")]
		public string StateAbbreviation { get; set; }

		[JsonProperty("place name")]
		public string PlaceName { get; set; }

		public IList<Place> Places { get; set; }
	}
}

