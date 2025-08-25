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
        private readonly IConfiguration _configuration; // Geliştirmek için kullanılabilir.
        private readonly TokenHelper _tokenHelper;

        public ToDoUserController(IToDoUserService service, IConfiguration configuration, TokenHelper tokenHelper)
        {
            _service = service;
            _configuration = configuration;
            _tokenHelper = tokenHelper;
        }
        // Uygulamaya kayıtlı tüm kullanıcıları listeleme.(Bu Api sadece geleiştirici tarafından test amaçlı oluşturulmuştur.)
        [HttpGet]
        public IActionResult GetAllUsers() => Ok(_service.GetAllUsers());
        // Belirtilen kullanıcı Id'sine göre kulanıcıyı listeler.
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var u = _service.GetUserById(id);
            return u == null ? NotFound() : Ok(u);
        }
        // Kullanıcının e-posta bilgisine göre kullanıcıyı listeler.
        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var u = _service.GetUserByEmail(email);
            return u == null ? NotFound() : Ok(u);
        }
        //Kullanıcının google ile bağlanıp bağlanmadığını gösterir.
        [HttpGet("linked-google")]
        public IActionResult GetUsersWithGoogleLinked()
        {
            var u = _service.GetUsersWithGoogleLinked();
            return Ok(u);
        }
        // Kullanıcın uygulamaya kayıt olma işlemini yapan API
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto dto)
        {
            var existingUser = _service.GetUserByEmail(dto.Email!);
            if (existingUser != null)
                return BadRequest("Bu e-posta adresi kullanımda.");

            byte[] passwordHash;//şifreleme işlemleri 
            byte[] passwordSalt;
            PasswordHelper.CreatePasswordHash(dto.Password!, out passwordHash, out passwordSalt);
            var user = new ToDoUser
            {

                Name = dto.Name!,
                Surname = dto.Surname!,
                Email = dto.Email!,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsGoogleLinked = false  // google hesabı üzerinden bir bağlantı olamdığı için 

            };
            _service.AddUser(user);
            return Ok("Kayıt Başarılı.");

        }
        // Kaydedilmiş kullanıcının login olma işlemini yapan API
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
        // Google hesabı üzerinden bağlantı işlemini yapan API 
        // Dikkat!Bu Apı fake bir google login işlemi yapmaktadır.Gerçek google login işlemi Swagger üzerinde Oauthorize ile sağlanmaktadır.(Nasıl kurulacağı README.md dosyasında yazılmaktadır.)
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
                    IsGoogleLinked = true,  // Google bağlantısını aktif hale getiriyoruz.
                    // Token işlemleri 
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
        // Kullanıcı bilgilerini güncelleme 
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            if (user.Id <= 0 || user == null)
            {
                return BadRequest("Geçersiz kullanıcı bilgisi.");
            }
            try
            {
                _service.UpdateUser(user);
                return Ok("Kullanıcı bilgileri güncellendi.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        // Belirtilen id'ye ait kullanıcıyı silme 
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _service.DeleteUser(id);
            return Ok("Kullanıcı bilgileri silindi.");
        }

        [HttpGet("validate")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            return
            Ok(new
            {
                message = "Token geçerli",
                userId = userId
            });
        }
    }
}