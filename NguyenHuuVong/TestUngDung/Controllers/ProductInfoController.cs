using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class ProductInfoController : Controller
    {
        private NHVongContext db = new NHVongContext();
        // GET: ProductInfo
        [HttpGet]
        public ActionResult Index(string id)
        {
            var product = db.Product.Where(p => p.ProductID.Equals(id));
            return View(product.ToList());
        }
    }
}