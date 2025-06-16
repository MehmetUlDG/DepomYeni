using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Bussiness;
using ToDoApp.Entities;

namespace ToDoApp.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleCalendarController : ControllerBase
    {
        private readonly IGoogleCalendarService _googleCalendarService;

        public GoogleCalendarController(IGoogleCalendarService googleCalendarService)
        {
            _googleCalendarService = googleCalendarService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddTaskGoogleEventAsync([FromBody] TaskUserDto dto)
        {
            var eventId = await _googleCalendarService.AddTaskGoogleEventAsync(dto.task!, dto.user!);
            dto.task!.GoogleEventId = eventId;
            return Ok(
                new
                {
                    message = "Takvime eklendi.",
                    eventid = eventId
                }
            );

        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTaskGoogleEventAsync([FromBody] TaskUserDto dto)
        {
            var eventId = await _googleCalendarService.UpdateTaskGoogleEventAsync(dto.task!, dto.user!);
            dto.task!.GoogleEventId = eventId;
            return Ok(new
            {
                message = "Etkinlik güncellendi.",
                eventid = eventId
            });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTaskGoogleEventAsync([FromBody] TaskUserDto dto)
        {
            await _googleCalendarService.DeleteTaskGoogleEventAsync(dto.task!, dto.user!);
            return Ok(new
            {
                message = "Etkinlik silindi."
            });
        }

        [HttpPost("is-linked")]
        public async Task<IActionResult> IsGoogleLinkedAsync(TaskUserDto dto)
        {
            var isLinked = await _googleCalendarService.IsGoogleLinkedAsync(dto.user!);
            dto.user!.IsGoogleLinked = isLinked;
            return Ok(new
            {
                result = isLinked
            });

        }
    }
}