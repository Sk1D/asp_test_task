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
        [HttpGet]
        public IEnumerable<Track> GetTracks(int id)
        {
            var values = unitOfWork.Tracks.Find(x => x.AlbumId == id);
            return values;
        }
        [HttpGet]
        public IEnumerable<Track> GetTracks()
        {
            var values = unitOfWork.Tracks.GetAll();
            return values;
        }

        [HttpPost]
        public int AddAlbum([FromBody]Album value)
        {
            int albumID = 0;
            if (value != null)
            {
                unitOfWork.Albums.Create(value);
                unitOfWork.Save();
                albumID = value.Id;
            }
            return albumID;
        }
        [HttpPost]
        public string AddTrack([FromBody]Track value)
        {
            if (value != null)
            {
                unitOfWork.Tracks.Create(value);
                unitOfWork.Save();
                return "track record added successfully";
            }
            else
            {
                return "Invalid track record";
            }

        }


        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
