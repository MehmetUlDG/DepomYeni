using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace müsteri
{
    public class UserConnect
    {
        {

    public DateTime Birthdate { get; set; }
    public DateTime CreatedDate { get; set; }
    public string TelNr1 { get; set; }
    public string TelNr2 { get; set; }

   
    public User( DateTime birthdate, DateTime createdDate, string telNr1, string telNr2)
    {
        
        Birthdate = birthdate;
        CreatedDate = createdDate;
        TelNr1 = telNr1;
        TelNr2 = telNr2;
    }

  
    public override string ToString()
    {
        return $" Birthdate: {Birthdate.ToString("dd.MM.yyyy")}, " +
               $"Created Date: {CreatedDate.ToString("yyyy-MM-dd HH:mm:ss")}, TelNr1: {TelNr1}, TelNr2: {TelNr2}";
    }
}
    }
}