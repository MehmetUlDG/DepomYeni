using ToDoApp.Bussines;
using ToDoApp.Entities;
using ToDoApp.DataAccess;
using ToDoApp.Entities.Dto;
using ToDoApp.Bussiness.Helpers;

namespace ToDoApp.Bussiness
{
    public class ToDoUserManager : IToDoUserService
    {
        private readonly IToDoUserRepository _repo;

        public ToDoUserManager(IToDoUserRepository repo)
        {
            _repo = repo;

        }

        public void AddUser(ToDoUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _repo.AddUser(user);
            _repo.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(id));
            }
            _repo.DeleteUser(id);
        }

        public List<ToDoUser> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        public ToDoUser? GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }
            return _repo.GetUserByEmail(email);
        }

        public ToDoUser? GetUserById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(id));
            }
            return _repo.GetUserById(id);
        }


        public List<ToDoUser> GetUsersWithGoogleLinked()
        {
            return _repo.GetUsersWithGoogleLinked();
        }

        public void UpdateGoogleTokens(int userId, string accessToken, string refreshToken, DateTime tokenExpiry)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("Access token cannot be null or empty", nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                throw new ArgumentException("Refresh token cannot be null or empty", nameof(refreshToken));
            }
            if (tokenExpiry == default)
            {
                throw new ArgumentException("Invalid token expiry date", nameof(tokenExpiry));
            }
            _repo.UpdateGoogleTokens(userId, accessToken, refreshToken, tokenExpiry);
        }

        public void UpdateUser(UserDto user)
        {
            var existingUser = _repo.GetUserById(user.Id);
            if (existingUser == null)
            {
                throw new ArgumentException("User not found", nameof(user));
            }
            // byte[] passwordHash; //şifreleme işlemleri 
            //byte[] passwordSalt;
            //PasswordHelper.CreatePasswordHash(user.Password!, out passwordHash, out passwordSalt);
            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                PasswordHelper.CreatePasswordHash(user.Password, out var hash, out var salt);
                existingUser.PasswordHash = hash;
                existingUser.PasswordSalt = salt;
            }
            existingUser.Name = user.Name!;
            existingUser.Email = user.Email!;
            existingUser.Surname = user.Surname!;
            _repo.UpdateUser(existingUser);
            _repo.SaveChanges();
        }
    }
}