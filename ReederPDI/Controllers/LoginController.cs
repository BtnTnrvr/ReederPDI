using ReederPDI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connnectionstring()
        {
            con.ConnectionString = "data source=192.168.1.12,1433\\SQL;initial catalog=ReederTSWeb;user id=batinrd;password=batin159753;MultipleActiveResultSets=True;App=EntityFramework;";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connnectionstring();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from TableLogin where user_name='" + acc.Name + "' and password_='" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("~/Views/Home/Welcome.cshtml");
            }
            else
            {
                con.Close();
                return View("~/Views/Home/Error.cshtml");
            }
        }
    }
}