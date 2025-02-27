     using System;
    class FirstProject
    {
        static void Main(string[] args)

        {  
    int[] sayilar = new int[5];
    for (int i = 0; i < 5; i++)
    {
        System.Console.WriteLine("bir sayı giriniz.");
        sayilar[i] = Convert.ToInt32(Console.ReadLine());
    }


    System.Console.WriteLine("en büyük sayı: " + enbuyuk(sayilar));
    System.Console.WriteLine("en küçük sayı: " + enkucuk(sayilar));
}

static int enbuyuk(int[] sayilar)
{
    int enbuyuk = sayilar[0];
    for (int i = 0; i < 5; i++)
    {
        if (sayilar[i] > enbuyuk)
        {
            enbuyuk = sayilar[i];
        }
    }
    return enbuyuk;
}
   static int enkucuk(int[] sayilar)
    {
        int enkucuk = sayilar[0];
        for (int i = 0; i < 5; i++)
        {
            if (sayilar[i] < enkucuk)
            {
                enkucuk = sayilar[i];
            }
        }
        return enkucuk;
    }

        }