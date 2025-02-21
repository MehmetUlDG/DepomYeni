    using System;
    class FirstProject
    {
        static void Main(string[] args)
        {
           System.Console.WriteLine("bir sayı giriniz");
              int sayi = Convert.ToInt32(Console.ReadLine());
              if(sayi==0)
              {
                  System.Console.WriteLine("sayı sıfırdır");
              }
              else if(sayi>0)
              {
                  System.Console.WriteLine("sayı pozitiftir");
              }
              else
              {
                  System.Console.WriteLine("sayı negatiftir");
              }
                int kalan = sayi % 2;
              switch(kalan)
              {
                  case 0:
                  System.Console.WriteLine("sayı cifttir");
                  break;
                  case 1:
                  System.Console.WriteLine("sayı tektir");
                  break;
                  default:
                  System.Console.WriteLine("hatalı giriş");
                  break;
              }
        }
    }