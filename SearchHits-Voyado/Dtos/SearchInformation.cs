using Newtonsoft.Json;

namespace SearchHits_Voyado.Dtos
{
    public class SearchInformation
    {
        [JsonProperty(PropertyName = "query_displayed")]
        public string QueryDisplayed { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public double? TotalResults { get; set; }


    }
}
