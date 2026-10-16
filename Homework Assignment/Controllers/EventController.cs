using Microsoft.AspNetCore.Mvc;
using Homework_Assignment.Models;
using Homework_Assignment.Repositories;

namespace Homework_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            return Ok(await _eventRepository.GetAllEvents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var eventItem = await _eventRepository.GetEventById(id);
            return eventItem == null ? NotFound() : Ok(eventItem);
        }

        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(Event eventItem)
        {
            var newEvent = await _eventRepository.AddEvent(eventItem);
            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event eventItem)
        {
            if (id != eventItem.Id) return BadRequest();
            var updatedEvent = await _eventRepository.UpdateEvent(eventItem);
            return updatedEvent == null ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            return await _eventRepository.DeleteEvent(id) ? NoContent() : NotFound();
        }

    }
}


