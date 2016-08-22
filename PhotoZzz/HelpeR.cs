using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace PhotoZzz
{

	public class HelpeR
	{
		HttpClient client;
		public HelpeR()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<JObject> postRequest(string urlString, string json)
		{
			var uri = new Uri(urlString);
			JObject result = null;
			try
			{
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				response = await client.PostAsync(uri, content);

				var stringResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				result = JObject.Parse(stringResult);
				return result;

			}
			catch (Exception )
			{
				return null;
			}
		}

		public async Task<JObject> putRequest(string urlString, string json)
		{
			var uri = new Uri(urlString);
			JObject result = null;
			try
			{
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				response = await client.PutAsync(uri, content);

				var stringResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				result = JObject.Parse(stringResult);
				return result;

			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<JObject> getRequest(string urlString)
		{
			var uri = new Uri(urlString);
			JObject result = null;
			try
			{

				HttpResponseMessage response = null;
				response = await client.GetAsync(uri);

				var stringResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				result = JObject.Parse(stringResult);

				return result;

			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


