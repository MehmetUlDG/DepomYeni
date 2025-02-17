    using System;
    class odev
    {
        static void Main(string[] args)
        {
           System.Console.WriteLine("adınızı giriniz");
           string ad=Console.ReadLine();
           System.Console.WriteLine("soyadınızı giriniz");
           string soyad=Console.ReadLine();
           System.Console.WriteLine("yasınızı giriniz");
           int yas=Convert.ToInt32(Console.ReadLine());
           System.Console.WriteLine("ikamet ettiğiniz şehri giriniz");  
           string sehir=Console.ReadLine();
           System.Console.WriteLine("mesleğinizi giriniz");
           string meslek=Console.ReadLine();

           System.Console.WriteLine("......... bilgi kartınız .........");
           System.Console.WriteLine("adınız:"+ad);
           System.Console.WriteLine("soyadınız:"+soyad);
           System.Console.WriteLine("yaşınız:"+yas);
           System.Console.WriteLine("ikamet ettiğiniz şehir:"+sehir);
           System.Console.WriteLine("mesleğiniz:"+meslek);
           System.Console.WriteLine("..................................");
        }
    }