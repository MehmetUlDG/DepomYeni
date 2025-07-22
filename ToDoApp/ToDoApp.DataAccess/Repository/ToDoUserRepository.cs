using ToDoApp.Entities;
using ToDoApp.Entities.Dto;

namespace ToDoApp.DataAccess
{
    public class ToDoUserRepository : IToDoUserRepository
    {
        private readonly DataContext _context;
        public ToDoUserRepository(DataContext context)
        {
            _context = context;
        }

        public void AddUser(ToDoUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Kullanıcı bilgileri boş bırakılamaz");
            }
            _context.ToDoUsers.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.ToDoUsers.Find(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"Kullanıcı ID {id} bulunamadı");
            }
            _context.ToDoUsers.Remove(user);
            _context.SaveChanges();
        }

        public List<ToDoUser> GetAllUsers()
        {
            return _context.ToDoUsers.ToList();
        }

        public ToDoUser? GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("E-posta boş bırakılamaz", nameof(email));
            }
            return _context.ToDoUsers.FirstOrDefault(u => u.Email.ToLower()==email.ToLower());
        }

        public ToDoUser? GetUserById(int id)
        {
            return _context.ToDoUsers.Find(id);
        }

        public List<ToDoUser> GetUsersWithGoogleLinked()
        {
            return _context.ToDoUsers.Where(u => u.IsGoogleLinked).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateGoogleTokens(int userId, string accessToken, string refreshToken, DateTime? tokenExpiry)
        {
            var existingUser = _context.ToDoUsers.Find(userId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"Kullanıcı ID {userId} bulunamadı");
            }
            existingUser.GoogleAccessToken = accessToken;
            existingUser.GoogleRefreshToken = refreshToken;
            existingUser.GoogleTokenExpiry = tokenExpiry;
            _context.ToDoUsers.Update(existingUser);
            _context.SaveChanges();
        }

        public void UpdateUser(ToDoUser user)
        {
            var existingUser = _context.ToDoUsers.Find(user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"Kullanıcı ID {user.Id} bulunamadı");
            }
            existingUser.Name = user.Name!;
            existingUser.Email = user.Email!;
            existingUser.Surname = user.Surname!;
            _context.ToDoUsers.Update(existingUser);
            _context.SaveChanges();
        }
    }
}