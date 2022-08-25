namespace BlazorGameDatabase.Services
{
    public class HttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetGameData(string sortKey, string searchKey = "")
        {
            var URL = "https://api.rawg.io/api/games?{YOUR_KEY_HERE}"+ "&ordering=" + sortKey.ToLower(); ;
            if (!string.IsNullOrEmpty(searchKey))
            {
                URL = URL + "&search=" + searchKey;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, URL);
            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
