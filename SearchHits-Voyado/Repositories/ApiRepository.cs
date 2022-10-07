using SearchHits_Voyado.API;
using SearchHits_Voyado.Dtos;

namespace SearchHits_Voyado.Repositories
{
    public class ApiRepository : IApiRepository
    {
        private readonly IApiClient _apiClient;
        private readonly string baseEndPoint = "https://serpapi.com/search.json?engine=";
        //Should be in a secret.
        private readonly string apiKey = "3856e09ec25e3a359568c71b2aaa5973a74d8b679e240cafc9a1a7245cec09ad";


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
