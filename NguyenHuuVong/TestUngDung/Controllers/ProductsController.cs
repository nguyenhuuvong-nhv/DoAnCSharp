using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace TestUngDung.Controllers
{
    public class ProductsController : Controller
    {
        private NHVongContext db = new NHVongContext();

        [HttpGet]
        public ActionResult Index(string id)
        {
            if(id == null)
            {
                var product = db.Product.Include(p => p.Category);
                return View(product.ToList());
            }
            else
            {
                var product = db.Product.Include(p => p.Category).Where(p=>p.CategoryID.Equals(id));
                return View(product.ToList());
            }
            
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
