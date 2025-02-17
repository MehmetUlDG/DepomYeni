     using System;
    class odev5
    {
       static void Main (string[] args){
        System.Console.WriteLine("birinci sayıyı giriniz");
        int sayi1=Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("ikinci sayıyı giriniz");
        int sayi2=Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine( "ücüncü sayıyı giriniz");
        int sayi3=Convert.ToInt32(Console.ReadLine());

        float ortalama=(sayi1+sayi2+sayi3)/3;
        System.Console.WriteLine("ortalama:"+ortalama);
        
       }
    }