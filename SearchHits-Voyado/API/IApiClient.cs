namespace SearchHits_Voyado.API
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }


}


