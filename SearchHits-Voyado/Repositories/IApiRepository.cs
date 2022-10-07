using SearchHits_Voyado.Dtos;

namespace SearchHits_Voyado.Repositories
{
    public interface IApiRepository
    {
        Task<SearchInformation> GetSearchHitsFromGoogle(string searchQuery);
        Task<SearchInformation> GetSearchHitsFromYahoo(string searchQuery);
    }
}
