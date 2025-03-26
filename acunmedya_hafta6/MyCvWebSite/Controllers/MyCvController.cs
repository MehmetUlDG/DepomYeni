using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            return View(Repostory.bilgiler);
        }

        public IActionResult Detail()
        {
            return View(Repostory.bilgiler);
        }

        public IActionResult Text(int id)
        {
            return View(Repostory.bilgiler);
        }
    }
}