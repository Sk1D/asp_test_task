using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Music.DAL.Interfaces;
using WebApp.Music.DAL.Repositories;
//using WebApp.Music.DAL;  //delete after test 

namespace WebApp.Music.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Home
        public ActionResult Index()
        {

                return View();
        }
        public ActionResult Test()
        {
            //using (var db = new SQLContext())
            //{
            //    var value = db.Albums.ToList();
            //    return View(value);
            //}
            var value = unitOfWork.Albums.GetAll();
            return View(value);
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}