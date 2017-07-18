using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Music.BL;
using WebApp.Music.DAL.Entities;
using WebApp.Music.DAL.Interfaces;
using WebApp.Music.DAL.Repositories;

namespace WebApp.Music.API
{
    public class ValuesController : ApiController
    {
        private IService service;
        public ValuesController(IService service)
        {
            this.service = service;
        }

        // GET api/values/GetAlbums
        [HttpGet]
        public IEnumerable<Album> GetAlbums()
        {
            var values = service.ReadAlbums();
            return values;
        
        }

        // GET api/values/GetAlbum/5
        [HttpGet]
        public Album GetAlbum(int id)
        {
            var value = service.ReadAlbum(id);
            return value;
        }
        [HttpGet]
        public IEnumerable<Track> GetTracks(int id)
        {
            var values = service.ReadTrack(id);
            return values;
        }
        [HttpGet]
        public IEnumerable<Track> GetTracks()
        {
            var values = service.ReadTracks();
            return values;
        }

        [HttpPost]
        public int AddAlbum([FromBody]Album value)
        {
            var result = service.CreateAlbum(value);
            return result;
           
        }
        [HttpPost]
        public string AddTrack([FromBody]Track value)
        {
            var result = service.CreateTrack(value);
            return result;
        }

        [HttpPut]
        public string UpdateAlbum(int id, [FromBody]Album value)
        {
            var result = service.UpdateAlbum(id,value);
            return result;
        }
        [HttpPut]
        public void UpdateTrack([FromBody]Track value)
        {
            service.UpdateTrack(value);
            
        }

        [HttpDelete]
        public string DeleteAlbum(int id)
        {
            var result = service.DeleteAlbum(id);
            return result;
        }
        [HttpDelete]
        public string DeleteTrack(int id)
        {
            var result = service.DeleteTrack(id);
            return result;
        }


    }
}
