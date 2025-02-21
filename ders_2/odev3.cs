    using System;
    class FirstProject
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("sıralamaya hoşgeldiniz");
                     string[] isimler = { "Ali", "Ayşe", "Mehmet", "Zeynep", "Hasan" };

                     foreach (string isim in isimler)
                     {   if(isim=="Mehmet")
                         {
                             continue;
                         }
                         System.Console.WriteLine(isim);
                     }
                }
                    
                
            }