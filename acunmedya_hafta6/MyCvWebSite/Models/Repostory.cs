using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCvWebSite.Models
{
    public class Repostory
    {
        private static readonly Bilgiler _bilgiler = new Bilgiler();

        static Repostory()
        {
            _bilgiler.Id = 1;
            _bilgiler.Name = "Mehmet";
            _bilgiler.Surname = "Uludağ";
            _bilgiler.Email = "mehmetuludag2021@outlook.com";
            _bilgiler.Description = "Benim özgeçmişim sayfasına hoşgeldiniz.";
            _bilgiler.github = "https://github.com/MehmetUlDG/DepomYeni";
            _bilgiler.linkedin = "https://www.linkedin.com/in/mehmet-uludağ-7b2604343";
            _bilgiler.Education = "Süleyman Demirel Üniversitesi";
            _bilgiler.Experience = "Yazılım Geliştirici";
            _bilgiler.Skills = "C#\n, C\n, GoLang\n, Java\n, Git\n, Github\n, SQL\n, Solidity\n";
            _bilgiler.Languages = "İngilizce-Pre_intermediate\n";
            _bilgiler.Image = "images/AnaResim.jpg";
            _bilgiler.Certificates="sertifika.png";
            _bilgiler.Projects="MVC Şablonlu cv sitesi";
            _bilgiler.Text="Bu siteyi MVC şablonu kullanarak oluşturdum. Bu siteyi oluştururken C# dili kullandım. Bu siteyi oluştururken HTML, CSS, JS, C# dillerini kullandım. Bu siteyi oluştururken Bootstrap kütüphanesini kullandım. Bu siteyi oluştururken Entity Framework kütüphanesini kullandım. Bu siteyi oluştururken SQL Server veritabanını kullandım. Bu siteyi oluştururken Git ve Github kullanarak sürüm kontrolü yaptım. Bu siteyi oluştururken Visual Studio Code ve Visual Studio 2019 IDE'lerini kullandım. Bu siteyi oluştururken Azure üzerinde yayınladım.";
        }

        public static Bilgiler bilgiler
        {
            get
            {
                return _bilgiler;
            }
        }

        public static Bilgiler? GetById(int id)
        {   
            return id == _bilgiler.Id ? _bilgiler : null;
        }
    }

    public class Bilgiler
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? github { get; set; }
        public string? linkedin { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public string? Skills { get; set; }
        public string? Languages { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        
        public string? Projects { get; set; }
        public string? Certificates { get; set; }
        public string? Text { get; set; }
        
    }
}