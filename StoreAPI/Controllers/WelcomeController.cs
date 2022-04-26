using Microsoft.AspNetCore.Mvc;

//TODO delete this class
namespace StoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public string[] Welcome()
        {
            return new string[] { "Store API Version 1.0.0" };
        }
    }
}
