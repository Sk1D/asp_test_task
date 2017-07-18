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
        private IService serv;
        public ValuesController()
        {
            this.serv = new Service();
        }
        public ValuesController(IService service)
        {
            this.serv = service;
        }
        // GET api/values/GetAlbums
        [HttpGet]
        public IEnumerable<Album> GetAlbums()
        {
            var values = serv.ReadAlbums();
            return values;
        
        }

        // GET api/values/GetAlbum/5
        [HttpGet]
        public Album GetAlbum(int id)
        {
            var value = serv.ReadAlbum(id);
            return value;
        }
        [HttpGet]
        public IEnumerable<Track> GetTracks(int id)
        {
            var values = serv.ReadTrack(id);
            return values;
        }
        [HttpGet]
        public IEnumerable<Track> GetTracks()
        {
            var values = serv.ReadTracks();
            return values;
        }

        [HttpPost]
        public int AddAlbum([FromBody]Album value)
        {
            var result = serv.CreateAlbum(value);
            return result;
           
        }
        [HttpPost]
        public string AddTrack([FromBody]Track value)
        {
            var result = serv.CreateTrack(value);
            return result;
        }

        [HttpPut]
        public string UpdateAlbum(int id, [FromBody]Album value)
        {
            var result = serv.UpdateAlbum(id,value);
            return result;
        }
        [HttpPut]
        public void UpdateTrack([FromBody]Track value)
        {
            serv.UpdateTrack(value);
            
        }

        [HttpDelete]
        public string DeleteAlbum(int id)
        {
            var result = serv.DeleteAlbum(id);
            return result;
        }
        [HttpDelete]
        public string DeleteTrack(int id)
        {
            var result = serv.DeleteTrack(id);
            return result;
        }


    }
}
