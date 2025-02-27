    using System;
    class FirstProject
    {
        static void Main(string[] args)
        {
                System.Console.WriteLine("bir sayı giriniz.");
    int sayi = Convert.ToInt32(Console.ReadLine());
    int toplam = 0;
    int toplam2 = 0;
    int döngü=1;
    while (döngü!= sayi+1)
    {
        toplam = toplam + döngü;
        döngü++;
    }
    System.Console.WriteLine("girilen sayıya kadar olan sayıların toplamı(while döngüsü): " + toplam);

    for (int i = 1; i <= sayi; i++)
    {
        toplam2 = toplam2 + i;

    }
    System.Console.WriteLine("girilen sayıya kadar olan sayıların toplamı(for döngüsü): " + toplam2);
}
    }