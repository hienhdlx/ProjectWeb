using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class AccountModel
    {
        private DataBanHangContext db = null;
        public AccountModel()
        {
            db = new DataBanHangContext();
        }
        public bool Login(string username, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName", username),
                new SqlParameter("@PassWord", password)
            };
            var res = db.Database.SqlQuery<bool>("Sp_Account_Login @UserName, @PassWord", sqlParams).SingleOrDefault();
            return res;
        }
    }
}