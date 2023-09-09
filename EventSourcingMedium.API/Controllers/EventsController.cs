using EventSourcingMedium.API.Services.EventStreaming;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingMedium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventStoreService _eventStoreService;

        public EventsController(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int start, int count)
        {
            var res = await _eventStoreService.GetAllEvents(start, count);
            if (res.Any())
            {
                return Ok(res);
            }
            return NoContent();
        }
    }
}
