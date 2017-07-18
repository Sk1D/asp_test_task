using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Music.DAL.Entities;
using WebApp.Music.DAL.Interfaces;
using WebApp.Music.DAL.Repositories;

namespace WebApp.Music.API
{
    public class ValuesController : ApiController
    {
        IUnitOfWork unitOfWork;
        public ValuesController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET api/values/GetAlbums
        [HttpGet]
        public IEnumerable<Album> GetAlbums()
        {
            var values = unitOfWork.Albums.GetAll();
            return values;
        
        }

        // GET api/values/GetAlbum/5
        [HttpGet]
        public Album GetAlbum(int id)
        {
            var value = unitOfWork.Albums.Get(id);
            return value;
        }



        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
