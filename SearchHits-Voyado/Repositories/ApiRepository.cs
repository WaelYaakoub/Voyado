using SearchHits_Voyado.API;
using SearchHits_Voyado.Dtos;

namespace SearchHits_Voyado.Repositories
{
    public class ApiRepository : IApiRepository
    {
        private readonly IApiClient _apiClient;
        private readonly string baseEndPoint = "https://serpapi.com/search.json?engine=";
        //Should be in a secret.
        //Paste in the API key down below...
        private readonly string apiKey = "";


        public ApiRepository(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        //API call to the Google Api with provided search query
        public async Task<SearchInformation> GetSearchHitsFromGoogle(string searchString)
        {
            var result = await _apiClient.GetAsync<SearchInformation>($"{baseEndPoint}google&q={searchString}&hl=en&gl=us&api_key={apiKey}");
            return result;
        }

        //API call to the Yahoo Api with provided search query
        public async Task<SearchInformation> GetSearchHitsFromYahoo(string searchString)
        {
            var result = await _apiClient.GetAsync<SearchInformation>($"{baseEndPoint}yahoo&p={searchString}&hl=en&gl=us&api_key={apiKey}");
            return result;
        }

    }
}
