using System.Net.Http;

namespace ContosoCrafts.WebSite.Services
{
	/// <summary>
	/// Utility class to handle checking urls
	/// </summary>
	public static class UrlCheckerService
	{
		// Static client to send Http requests.
		// This class should only be instantiated once per an application lifetime to avoid socket exhaustion
		static readonly HttpClient client = new HttpClient();

		/// <summary>
		/// Static method to check if a url is valid. Sends a HTTP request, so this method can take a while to execute
		/// </summary>
		/// <param name="website">The website url to be validated</param>
		/// <returns>Returns true if http request to website succeeded. False otherwise</returns>
		public static bool ValidateUrl(string website)
		{
			// Create a HEAD request for the target website.
			// A HEAD request saves bandwidth by not actually getting the resource requested, only the Http header of the response.
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, website);


			// If the url is not formatted as an absolute URI, Send() will return an error
			try
			{
				// Send the request and get the response
				HttpResponseMessage response = client.Send(request);
                return response.IsSuccessStatusCode;
            }
			catch(System.Exception) 
            {
                // Exceptions include improperly formatted url and request failing (e.g. no server responded)
				// Generally, if the request fails for any reason, we want to return false
                return false;
			}
		}
	}
}