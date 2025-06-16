using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Bussines;
using ToDoApp.Bussiness;
using ToDoApp.Entities;
using ToDoApp.Entities.Dto;

namespace ToDoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _service;
        private readonly IToDoUserService _uservice;
        private readonly IConfiguration _configuration;
        public ToDoTaskController(IToDoTaskService service, IConfiguration configuration, IToDoUserService uservice)
        {
            _service = service;
            _configuration = configuration;
            _uservice = uservice;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            _service.GetAllTasks();
            return Ok();
        }
        [Authorize]
        [HttpGet("task/{id:int}")]
        public IActionResult GetTaskById(int id)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Geçersiz token. Kullanıcı ID bulunamadı.");
            int userId = int.Parse(userIdClaim.Value);
            var u = _uservice.GetUserById(userId);
            if (u == null)
                return NotFound("Kullanıcı bulunamadı.");

            var t = _service.GetTaskById(id);
            if (t == null)
                return NotFound("Görev bulunamadı.");

            if (u.Id != t.UserId)
                return Forbid("Bu işlem için yetkiniz yoktur.");

            return Ok(t);
        }

        [HttpGet("user/{userId:int}")]
        public IActionResult GetTasksByUserId(int userId)
        {
            var u = _service.GetTasksByUserId(userId);
            return u == null ? NotFound() : Ok(u);
        }

        [HttpGet("google/{googleEventId}")]
        public IActionResult GetTaskByGoogleEventId(string googleEventId)
        {
            var Event = _service.GetTaskByGoogleEventId(googleEventId);
            return Event == null ? NotFound() : Ok(Event);
        }

        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTaskAsync([FromBody] TaskDetailsDto dto)
        {
            var user = _uservice.GetUserById(dto.UserId);
            if (user == null) throw new Exception("Bu etkinliği oluşturacak kullanıcı bulunamadı.");

            var task = new ToDoTask
            {

                Title = dto.Title!,
                Description = dto.Description!,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                CompletedAt = dto.CompletedAt,
                UserId = dto.UserId,
                GoogleEventId = dto.GoogleEventId

            };
            await _service.AddTaskAsync(task, user);
            return Ok("Harika!Etkinliğiniz oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync([FromBody] ToDoTask task)
        {
            var user = _uservice.GetUserById(task.UserId);
            if (user == null)
                return BadRequest();

            var existingTask = _service.GetTaskById(task.Id);
            if (existingTask == null)
                return BadRequest();

            if (existingTask.UserId != user.Id)
                return Forbid("Bu işlem için yetkiniz yoktur.");

            await _service.UpdateTask(task, user);
            return Ok("Güncelleme işlemi başarılı.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id, TaskDetailsDto dto)
        {
            var user = _uservice.GetUserById(dto.UserId);
            if (user == null)
                return BadRequest();

            var task = _service.GetTaskById(id);
            if (task == null)
                return BadRequest();

            if (task.UserId != user.Id)
                return Forbid("Bu işlem için yetkiniz yoktur.");

            await _service.DeleteTask(id, user);
            return Ok("Silme işlemi başarılı.");
        }
    }
}