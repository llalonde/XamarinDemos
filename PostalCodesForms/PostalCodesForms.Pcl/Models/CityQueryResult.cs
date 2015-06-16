using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace PostalCodesForms.Models
{
    public class CityQueryResult
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

