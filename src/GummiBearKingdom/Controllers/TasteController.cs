using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummiBearKingdom.Models;


namespace GummiBearKingdom.Controllers
{
    public class TasteController : Controller
    {
        private GummiBearKingdomContext db = new GummiBearKingdomContext();
        //View all tastes
        public IActionResult Index()
        {
            return View(db.Tastes.ToList());
        }

        //Create new Taste
        public IActionResult Create()
        {
            ViewBag.TasteId = new SelectList(db.Tastes, "TasteId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
