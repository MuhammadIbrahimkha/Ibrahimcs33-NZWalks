using Microsoft.AspNetCore.Mvc;
using NZWalks.Web.Models.DTO;

namespace NZWalks.Web.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public RegionsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {

            List<RegionDto> response1 = new List<RegionDto>();


            try
            {
                // Get all regions from web api


                var client = _httpClient.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7080/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();



        response1.AddRange( await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

               


            }
            catch (Exception ex)
            {
                // log the execption.

            }


            return View(response1);
        }
    }
}
