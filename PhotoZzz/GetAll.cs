using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PhotoZzz
{
	public class GetAll 
	{
		private string stringg = "http://192.168.1.214:3000/v1/";   // server supplying dummy info
		private HttpClient _client;

		public GetAll()
		{
			_client = new HttpClient();
			_client.BaseAddress = new Uri(stringg);
			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<ObjectMain> FetchPosts()
		{
			var result = new ObjectMain();
			var request = "vegetables";
			var responseString = "";

			try
			{
				// make GET request
				HttpResponseMessage response = await _client.GetAsync(request);

				// read the http response body
				responseString = await response.Content.ReadAsStringAsync();

				// deserialize json string
				result = JsonConvert.DeserializeObject<ObjectMain>(responseString);

			}
			catch (Exception )
			{
				System.Diagnostics.Debug.WriteLine("RestService: Something went wrong.");
			}

			return result;
		}
	}
}


