using EventSourcingMedium.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingMedium.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public PostController()
        {

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("GetPost")]
        public IActionResult Get([FromQuery] string id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePostInformationDTO createPostInformationDTO)
        {
            // map object
            return Ok();
        }
    }
}
