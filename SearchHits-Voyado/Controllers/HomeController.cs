using Microsoft.AspNetCore.Mvc;
using SearchHits_Voyado.Dtos;
using SearchHits_Voyado.Models;
using SearchHits_Voyado.Repositories;

namespace SearchHits_Voyado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiRepository _apiRepository;

        public HomeController(ILogger<HomeController> logger, IApiRepository apiRepository)
        {
            _logger = logger;
            _apiRepository = apiRepository;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return View(new SearchViewModel());
            }

            double countGoogle = 0;
            double countYahoo = 0;

            try
            {

                //Remove leading and trailing whitespaces
                string[] words = searchString.Trim().Split(" ");

                var searchGoogle = new SearchInformation();
                var searchYahoo = new SearchInformation();


                foreach (var word in words)
                {
                    searchGoogle = await _apiRepository.GetSearchHitsFromGoogle(word);
                    searchYahoo = await _apiRepository.GetSearchHitsFromYahoo(word);

                    countGoogle += searchGoogle.TotalResults ?? 0;
                    countYahoo += searchYahoo.TotalResults ?? 0;
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


            //wrapping everything a ViewModel to present it to the View.
            var model = new SearchViewModel
            {
                SearchQuery = searchString,
                TotalHitsGoogle = countGoogle,
                TotalHitsYahoo = countYahoo
            };

            return View(model);
        }


    }
}