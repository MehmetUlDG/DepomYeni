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
        }

        public static Bilgiler bilgiler
        {
            get
            {
                return _bilgiler;
            }
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
    }
}