using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDAO
    {
        private NHVongContext db;

        public ProductDAO()
        {
            db = new NHVongContext();
        }
        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Product;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.ProductName.Contains(keysearch));
            }
            return model.OrderBy(x => x.ProductName).ToPagedList(page, pagesize);
        }

        public Product Find(string ProductName)
        {
            return db.Product.Find(ProductName);
        }
        public List<Product> ListAll()
        {
            return db.Product.ToList();
        }
        public string getNewProductID()
        {
            string ProductID = db.Product.OrderByDescending(x => x.ProductID).First().ProductID;
            string NewPrID = string.Concat(Int32.Parse(ProductID) + 1);
            return NewPrID;
        }
    }
}
