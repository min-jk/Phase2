using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatFactsController : ControllerBase
    {
        private readonly HttpClient _client;

        public CatFactsController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("Cat Facts");
        }

        [HttpGet]
        [Route("raw")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCatFacts()
        {
            var res = await _client.GetAsync("/facts");
            var content = await res.Content.ReadAsStringAsync();

            return Ok(content);
        }

    }
}
