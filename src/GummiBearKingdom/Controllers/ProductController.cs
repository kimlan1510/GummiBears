using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummiBearKingdom.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBearKingdom.Controllers
{
    public class ProductController : Controller
    {
        private GummiBearKingdomContext db = new GummiBearKingdomContext();
        //View all products
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        } 
        //Details view of product
        public IActionResult Details(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            return View(thisProduct);

        }
    }
}
