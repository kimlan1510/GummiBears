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
    public class HomeController : Controller
    {
        private GummiBearKingdomContext db = new GummiBearKingdomContext();
        //HomePage
        public IActionResult Index()
        {
            return View(db.Tastes.ToList());
        }
    }
}
