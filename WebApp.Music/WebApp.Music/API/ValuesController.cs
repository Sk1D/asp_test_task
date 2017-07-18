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

        [HttpPut]
        public string UpdateAlbum(int id, [FromBody]Album value)
        {
            if (value != null && id == value.Id)
            {
                Album _album = unitOfWork.Albums.Get(id);
                _album.Name = value.Name;
                _album.Year = value.Year;
                unitOfWork.Albums.Update(_album);
                unitOfWork.Save();
                return "Album record updated successfully";
            }
            else
            {
                return "Invalid album record";
            }
        }
        [HttpPut]
        public void UpdateTrack([FromBody]Track value)
        {

            if (value != null)
            {
                Track _track = unitOfWork.Tracks.Get(value.Id);
                if (_track != null)
                {
                    _track.Artist = value.Artist;
                    _track.Title = value.Title;
                    _track.Time = value.Time;
                    unitOfWork.Tracks.Update(_track);
                }
                else
                {
                    Track _newTrack = new Track();
                    _newTrack.Artist = value.Artist;
                    _newTrack.Title = value.Title;
                    _newTrack.Time = value.Time;
                    _newTrack.AlbumId = value.AlbumId;
                    unitOfWork.Tracks.Create(_newTrack);
                }
                unitOfWork.Save();
            }
        }

        [HttpDelete]
        public string DelAlbum(int id)
        {
            try
            {
                unitOfWork.Albums.Delete(id);
                unitOfWork.Save();
                return "Selected album record deleted sucessfully";
            }
            catch (Exception)
            {
                return "Invalid operation";
            }


        }
        [HttpDelete]
        public string DelTrack(int id)
        {
            try
            {
                unitOfWork.Tracks.Delete(id);
                unitOfWork.Save();
                return "Selected track record deleted sucessfully";
            }
            catch (Exception)
            {
                return "Invalid operation";
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
