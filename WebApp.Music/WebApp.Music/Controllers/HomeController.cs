using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Music.DAL;  //delete after test 

namespace WebApp.Music.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

                return View();
        }
        public ActionResult Test()
        {
            using (var db = new SQLContext())
            {
                var value =db.Albums.ToList();
                return View(value);
            }
        }
    }
}