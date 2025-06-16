using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ToDoApp.Bussines;
using ToDoApp.Bussiness.Helpers;
using ToDoApp.Entities;
using ToDoApp.Entities.Configurations;
using ToDoApp.Entities.Dto;

namespace ToDoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoUserController : ControllerBase
    {
        private readonly IToDoUserService _service;
        private readonly IConfiguration _configuration;
        private readonly TokenHelper _tokenHelper;

        public ToDoUserController(IToDoUserService service, IConfiguration configuration, TokenHelper tokenHelper)
        {
            _service = service;
            _configuration = configuration;
            _tokenHelper = tokenHelper;
        }
        [HttpGet]
        public IActionResult GetAllUsers() => Ok(_service.GetAllUsers());

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var u = _service.GetUserById(id);
            return u == null ? NotFound() : Ok(u);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var u = _service.GetUserByEmail(email);
            return u == null ? NotFound() : Ok(u);
        }
        [HttpGet("linked-google")]
        public IActionResult GetUsersWithGoogleLinked()
        {
            var u = _service.GetUsersWithGoogleLinked();
            return Ok(u);
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto dto)
        {
            var existingUser = _service.GetUserByEmail(dto.Email!);
            if (existingUser != null)
                return BadRequest("Bu e-posta adresi kullanımda.");

            byte[] passwordHash;
            byte[] passwordSalt;
            PasswordHelper.CreatePasswordHash(dto.Password!, out passwordHash, out passwordSalt);
            var user = new ToDoUser
            {
             
                Name = dto.Name!,
                Surname = dto.Surname!,
                Email = dto.Email!,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsGoogleLinked = false

            };
            _service.AddUser(user);
            return Ok("Kayıt Başarılı.");

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto dto)
        {
            var user = _service.GetUserByEmail(dto.Email!);
            byte[] storedHash = user!.PasswordHash;
            byte[] storedSalt = user.PasswordSalt;
            bool check = PasswordHelper.VerifyPassword(dto.Password!, storedHash, storedSalt);
            if (user == null || !check)
                return Unauthorized("Hatalı bilgiler.");

            var token = _tokenHelper.CreateToken(user);
            return Ok(new { token });

        }
        [HttpPost("google-login")]
        public IActionResult GoogleLogin([FromBody] UserAuthDto dto)
        {
            var user = _service.GetUserByEmail(dto.Email!);
            if (user == null)
            {
                user = new ToDoUser
                {
                    Name = dto.Name!,
                    Surname = dto.Surname!,
                    Email = dto.Email!,
                    IsGoogleLinked = true,
                    GoogleAccessToken = dto.GoogleAccessToken,
                    GoogleRefreshToken = dto.GoogleRefreshToken,
                    GoogleTokenExpiry = dto.GoogleTokenExpiry
                };
                _service.AddUser(user);
            }
            else
            {
                _service.UpdateGoogleTokens(user.Id, dto.GoogleAccessToken!, dto.GoogleRefreshToken!, dto.GoogleTokenExpiry);
            }
            var token = _tokenHelper.CreateToken(user);
            return Ok(new { token });

        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] ToDoUser user)
        {
            _service.UpdateUser(user);
            return Ok("Kullanıcı bilgileri güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _service.DeleteUser(id);
            return Ok("Kullanıcı bilgileri silindi.");
        }
    }
}