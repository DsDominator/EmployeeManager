using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Data.SqlClient;

namespace CrudOperationInMVC.Models
{
    public class AccountModel
    {
        private CompanyDBDataContext context = null;
        public AccountModel()
        {
            context = new CompanyDBDataContext("Data Source=LAPTOP-CG78U18T\\PHONG;Initial Catalog=ProjectMVC;Integrated Security=True;TrustServerCertificate=True");
        }
        
        public bool Login(string Username, string Password)
        {
            bool? res = false;
            context.sp_Account_Login_Check(Username, Password, ref res);
            return (res ?? false);
        }

    }

   
}