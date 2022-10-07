using Newtonsoft.Json.Linq;
using System.Net;
using System.Web.Http;

namespace SearchHits_Voyado.API
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //Creating a GET method for reusing in the application
        public async Task<T> GetAsync<T>(string endpoint)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            try
            {
                using var response = await _httpClient.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //render http response to JSON string
                    var responseRead = await response.Content.ReadAsStringAsync();
                    //Parsing it to a JsonObject
                    var jsonObject = JObject.Parse(responseRead);
                    //Getting a certain property name from the jsonObject
                    var searchInfo = jsonObject.GetValue("search_information");

                    //Binding the searchInfo to my SearchInformation.cs
                    var result = searchInfo.ToObject<T>();

                    return result;
                }

                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                }

                throw new HttpResponseException(response.StatusCode);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }


}

