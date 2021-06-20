using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        private NHVongContext db = new NHVongContext();
        public ActionResult Index()
        {
            List<Product> products = db.Product.ToList();
            List<Category> cate = db.Category.ToList();
            ViewBag.CategoryList = cate;
            return View(products);
        }
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}