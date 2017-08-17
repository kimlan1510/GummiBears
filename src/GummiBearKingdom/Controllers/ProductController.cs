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
            var foundTaste = db.Tastes.FirstOrDefault(something => something.TasteId == thisProduct.TasteId);
            ViewBag.Taste = foundTaste.Name;
            return View(thisProduct);

        }
        //Create new Product
        public IActionResult Create()
        {
            ViewBag.TasteId = new SelectList(db.Tastes, "TasteId", "Name");
            ViewBag.TasteList = db.Tastes.ToList().LongCount();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Edit a Product
        public IActionResult Edit(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(productId => productId.ProductId == id);
            PopulateTasteDropdownList();
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Delete a product
        public IActionResult Delete(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            db.Products.Remove(thisProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get Taste list 
        private void PopulateTasteDropdownList()
        {
            var tastesQuery = from taste in db.Tastes
                                orderby taste.Name
                                select taste;
            ViewBag.TasteId = new SelectList(tastesQuery, "TasteId", "Name");
        }
    }
}
