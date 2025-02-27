 using System;
    class FirstProject
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("isiminizi giriniz");
            string isim = Console.ReadLine();
            System.Console.WriteLine("yasınızı giriniz");
            int yas = Convert.ToInt32(Console.ReadLine());  
            System.Console.WriteLine("merhaba " + isim + " yaşınız " + yas);
        }}