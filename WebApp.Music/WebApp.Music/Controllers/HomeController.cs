using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Music.BL;
using WebApp.Music.DAL.Interfaces;
using WebApp.Music.DAL.Repositories;


namespace WebApp.Music.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult TrackList()
        //{
        //    return View();
        //}

    }
}