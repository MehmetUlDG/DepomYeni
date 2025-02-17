
using System;
    class FirstProject
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("doğum tarih giriniz");
            DateTime date=DateTime.Parse(Console.ReadLine());
           int yaş=DateTime.Now.Year-date.Year;
           System.Console.WriteLine("yaşınız:"+yaş);
        }
    }

