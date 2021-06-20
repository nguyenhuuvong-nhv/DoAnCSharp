using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDAO
    {
        private NHVongContext db;

        public UserDAO()
        {
            db = new NHVongContext();
        }
        public int login(string user, string Password)
        {
            var result = db.UserAccount.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(Password));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccount.ToList();
        }
        public string getNewUserID()
        {
            string UserID = db.UserAccount.OrderByDescending(x => x.UserID).First().UserID;
            string NewUserID = string.Concat(Int32.Parse(UserID)+ 1);
            return NewUserID;
        }


        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccount;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }
            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }



    }
}

