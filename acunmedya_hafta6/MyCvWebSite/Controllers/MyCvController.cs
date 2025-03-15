using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCvWebSite.Models;
namespace MyCvWebSite.Controllers
{
   
    public class MyCvController : Controller
    {
         public IActionResult Index()
        {
            var cv = new MyCvModel
            {
                Id = 1,
                Name = "Mehmet",
                Surname ="Uludağ",
                Email = "mehmetuludag2021@outlook.com",
                Description = "CV profilime hoşgeldiniz.",
            };

            return View(cv);
    }

    public IActionResult Detail()
    {       
        var cvler = new MyCvModel
        {
            Email = "mehmetuludag2021@outlook.com",
            github = "https://github.com/MehmetUlDG/DepomYeni",
            linkedin = "www.linkedin.com/in/mehmet-uludağ-7b2604343",
            Education = "Süleyman Demirel Üniversitesi",
            Experience = "Yazılım Geliştirici",
            Skills = "C#\n ,C\n ,GoLang\n ,Java\n ,Git\n ,Github\n ,SQL\n ,Solidity\n ",
            Languages = "İngilizce-Pre_indermediate\n  ",
        };
        return View(cvler);
    }
}}  
