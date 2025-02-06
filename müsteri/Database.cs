using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace müsteri
{
    public class Database
    {
        public string Username { get; set; }
    public string Password { get; set; }
    public string NameSurname { get; set; }
   

    
    private static List<User> userDatabase = new List<User>();

    
    public User(string username, string password, string nameSurname)
    {
        Username = username;
        Password = password;
        NameSurname = nameSurname;
       
    }

  
    public static void AddUserToDatabase(User user)
    {
        userDatabase.Add(user);
        Console.WriteLine($"Veritabanına eklendi: {user.NameSurname} ({user.Username})");
    }

 
    public static List<User> GetUsersFromDatabase()
    {
        return userDatabase;
    }

        public static void ReadUsersFromFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); 

                if (parts.Length >= 5)
                {
                   
                    string username = parts[0];
                    string password = parts[1];
                    string nameSurname = parts[2] + " " + parts[3]; 
                 

                   
                    User newUser = new User(username, password, nameSurname);
                    AddUserToDatabase(newUser);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Dosya okuma hatası: {ex.Message}");
        }
    }
    }
}