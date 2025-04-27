using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMaduraiCateringService.Models;

namespace WebMaduraiCateringService.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseFirstDbEntities de = new DatabaseFirstDbEntities();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.listProducts = de.Products.ToList();
            return View();
        }
    }
}