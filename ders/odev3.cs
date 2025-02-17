    using System;
    class odev3{
        static void Main(string[] args){
            System.Console.WriteLine("bir cümle giriniz");
            string cumle=Console.ReadLine();
            System.Console.WriteLine("cümlenin uzunluğu:"+cumle.Length);
            System.Console.WriteLine("cümlenin büyük harf hali:"+cumle.ToUpper());
            System.Console.WriteLine("cümlenin küçük harf hali:"+cumle.ToLower());
            System.Console.WriteLine("cümlenin ilk harfi:"+cumle[0]);
            System.Console.WriteLine("cümlenin son harfi:"+cumle[cumle.Length-1]);
            System.Console.WriteLine("cümlenin düzeltilmiş hali:"+cumle.trim());
        }
    }