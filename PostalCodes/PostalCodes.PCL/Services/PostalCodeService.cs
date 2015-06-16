using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PostalCodes.PCL
{
	public class PostalCodeService
	{
		private const string QueryUrl = "http://api.zippopotam.us";
		private const string DataMimeType = "application/json";

		public async Task<LocationResult> LocationQueryAsync(string countryCode, string stateCode, string city)
		{
			using (var client = CreateClient())
			{
				var response = await client.GetAsync(string.Format("{0}/{1}/{2}", countryCode, stateCode, city));

				// Throw an exception if we do not have a successful interchange.
				response.EnsureSuccessStatusCode();

				var result = JsonConvert.DeserializeObject<LocationResult>(await response.Content.ReadAsStringAsync());

				return result;
			}
		}

		private HttpClient CreateClient()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(QueryUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(DataMimeType));

			return client;
		}
	}
}

