using System;
class odev2{
    static void Main(string[] args){
       System.Console.WriteLine("birinci sayıyı giriniz");
       int sayi1=Convert.ToInt32(Console.ReadLine());
         System.Console.WriteLine("ikinci sayıyı giriniz");
         int sayi2=Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("toplam:"+(sayi1+sayi2));
            System.Console.WriteLine("fark:"+(sayi1-sayi2));
            System.Console.WriteLine("çarpım:"+(sayi1*sayi2));
            if(sayi2==0){
                System.Console.WriteLine("bölen sıfır olamaz");
            }
            else{
                System.Console.WriteLine("bölüm:"+(sayi1/sayi2));
                System.Console.WriteLine("kalan:"+(sayi1%sayi2));
            }
    }
}