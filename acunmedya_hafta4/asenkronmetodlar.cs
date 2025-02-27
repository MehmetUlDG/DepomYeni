   using System;
using System.Threading.Tasks;
  //Asenkron bir metot yaz ve 3 saniye bekleterek bir mesaj göster.
class Program
{
    static async Task Main(string[] args)
    {
        // Asenkron metodu çağırıyoruz
        await BekleVeMesajGoster();
    }

    // 3 saniye bekleyip mesaj gösteren asenkron metot
    static async Task BekleVeMesajGoster()
    {
        Console.WriteLine("Bekleme başladı...");
        
        // 3 saniye bekliyoruz
        await Task.Delay(3000);
        
        // Bekleme tamamlandığında mesaj gösteriyoruz
        Console.WriteLine("3 saniye geçti! Mesaj gösterildi.");
    }
}
 