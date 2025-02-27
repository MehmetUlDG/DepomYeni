    using System;

class ödev
{
    static void Main(string[] args)
    {

    

        //Bir listenin içindeki tek sayıları filtreleyen bir Lambda fonksiyonu yaz.
       List<int> list = new List<int>();
       for (int i = 0; i < 10; i++)
{
    list.Add(i);
}
       IEnumerable<int> tekRakamlar = list.Where(x => x % 2 == 1);
        foreach (int rakam in tekRakamlar) Console.WriteLine(rakam);

       //Func kullanarak iki string’i birleştiren bir metot oluştur.
         Func<string, string, string> birlestir = (x, y) => x + y;
         System.Console.WriteLine(birlestir("Merhaba", "Dünya"));

         //Action kullanarak ekrana “Veri Kaydedildi” mesajını yazdır.
            Action mesaj = () => Console.WriteLine("Veri Kaydedildi");
            mesaj();
            //Predicate kullanarak bir kelimenin 5 harften uzun olup olmadığını kontrol eden bir metot yaz.
            Predicate<string> uzunluk = x => x.Length > 5;
            Console.WriteLine(uzunluk("Merhaba"));
            //Gerçek dünya örneği: Bir öğrenci listesi oluştur ve 18 yaşından büyük olanları filtrele.
            class Ogrenci
{
    public string Ad { get; set; }
    public int Yas { get; set; }
}
            List<ogrenci> ogrenciler = new List<ogrenci>();
            ogrenciler.Add(new ogrenci { ad = "Ali", yas = 17 });   
            ogrenciler.Add(new ogrenci { ad = "Veli", yas = 18 });
            ogrenciler.Add(new ogrenci { ad = "Ahmet", yas = 19 });
            IEnumerable<ogrenci> yetiskinler = ogrenciler.Where(x => x.yas > 18);
            foreach (ogrenci ogrenci in yetiskinler) Console.WriteLine(ogrenci.ad);

            //Bir metot oluştur ve ref ile bir değişkenin değerini 2 katına çıkar.
               int sayi = 5;
             arttir(ref sayi);


            Console.WriteLine(sayi);


            static void arttir(ref int sayi) => sayi *= 2;
            //params kullanarak 5 farklı sayıyı toplayan bir metot yaz.
            Console.WriteLine(Topla(1, 2, 3, 4, 5));
            static int Topla(params int[] sayilar) => sayilar.Sum();
            //Kendi Logger sistemini yaz ve dosyaya log kaydet.
            Logger logger = new Logger();
            logger.Log("Hata", "Dosya Bulunamadı");
            logger.Log("Bilgi", "Dosya Bulundu");
            logger.Log("Uyarı", "Dosya Silindi");
      //Kullanıcıdan isim alıp selam veren bir metot yaz.
            Console.WriteLine(SelamVer("Ali"));
            static string SelamVer(string isim) => $"Merhaba {isim}";
            //Kullanıcıdan iki sayı alıp çarpan bir metot yaz.
            
            Console.WriteLine(Carp(5, 3));  
            static int Carp(int sayi1, int sayi2) => sayi1 * sayi2;
            //Aynı işlemi int ve double için yapan Overloading metodunu yaz.
            Console.WriteLine(Carp(5, 3));
            static int Carp(int sayi1, int sayi2) => sayi1 * sayi2;
            //**************************************//
            Console.WriteLine(Carp(5.5, 3.5));
            static double Carp(double sayi1, double sayi2) => sayi1 * sayi2;
            //Girilen bir kelimeyi tersten yazan bir metot yaz.
            Console.WriteLine(TerstenYaz("Merhaba"));
            static string TerstenYaz(string kelime) => new string(kelime.Reverse().ToArray());
           //DİKKAT: bazı metodlar main metodu içinde tanımlanmıştır.bu yüzden hata verebilir.// 
    }

}
