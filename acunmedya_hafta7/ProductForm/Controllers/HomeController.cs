using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductForm.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
namespace ProductForm.Controllers;

public class HomeController : Controller
{
    public int CategoryId { get; set; }


    public IActionResult Index(string searchString, string category)
    {
        ViewBag.SearchString = searchString;
        var products = Repostory.Products;
        if (!string.IsNullOrEmpty(searchString))
        {
            products = products.Where(p => p.Name!.ToLower().Contains(searchString.ToLower())).ToList();


        }
        if (!string.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }

        var model = new ProductViewModel
        {

            Products = products,
            Categories = Repostory.Categories,
            SelectedCategory = category,

        };
        return View(model);
    }
    [HttpGet]
    public IActionResult Create(){
        ViewBag.Categories = new SelectList(Repostory.Categories, "CategoryId","Name");
        return View();
    }
    [HttpPost]
    public IActionResult Create(ProductModel model)
    {   if (!ModelState.IsValid){
        model.ProductId = Repostory.Products.Count + 1;
        Repostory.CreateProduct(model);
            return RedirectToAction("Index");
    }
        return View(model);
        }
      
    }

