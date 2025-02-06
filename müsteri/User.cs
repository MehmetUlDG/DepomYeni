using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace müsteri
{
    public class User
    {
        public int ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string NameSurname { get; set; }

  
    public User(int id, string username, string password, string nameSurname)
    {
        ID = id;
        Username = username;
        Password = password;
        NameSurname = nameSurname;
    }

  
    public override string ToString()
    {
        return $"ID: {ID}, Username: {Username}, Name: {NameSurname}";
    }
}
    }
