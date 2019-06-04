using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLoginApplication.Models;

namespace MVCLoginApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            LoginInfo loginInfo = new LoginInfo();

            return View(loginInfo);
        }

        //[HttpPost]
        //public ActionResult Index(string UserName, string Password)
        //{
        //    using (SqlConnection con = new SqlConnection("data source=MCUBE148; database=SampleDB; user id=sa; password=welcome;"))
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Login_Info WHERE user_name = @Uname AND password = @pwd", con);
        //        cmd.Parameters.AddWithValue("@Uname", UserName);
        //        cmd.Parameters.AddWithValue("@pwd", Password);
        //        //cmd.Parameters.Add(new SqlParameter("@Uname", UserName));
        //        //cmd.Parameters.Add(new SqlParameter("@pwd", Password));
        //        con.Open();
        //        int noOfRows = (int)cmd.ExecuteScalar();

        //        if (noOfRows>0)
        //        {
        //            return RedirectToAction("Login");
        //        }
        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult Index(LoginInfo loginInfo)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection("data source=MCUBE148; database=SampleDB; user id=sa; password=welcome;"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Login_Info WHERE user_name = @Uname AND password = @pwd", con);
                    cmd.Parameters.AddWithValue("@Uname", loginInfo.UserName);
                    cmd.Parameters.AddWithValue("@pwd", loginInfo.Password);
                    //cmd.Parameters.Add(new SqlParameter("@Uname", UserName));
                    //cmd.Parameters.Add(new SqlParameter("@pwd", Password));
                    con.Open();
                    int noOfRows = (int)cmd.ExecuteScalar();

                    if (noOfRows > 0)
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
