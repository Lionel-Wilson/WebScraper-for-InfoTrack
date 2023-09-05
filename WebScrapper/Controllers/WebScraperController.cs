using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebScrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        [HttpGet]
        public string Get([FromBody] string keywords, string url)
        {
            
            
            return 'test';
        }
    }
}
