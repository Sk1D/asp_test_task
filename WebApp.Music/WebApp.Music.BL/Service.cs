using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Music.DAL.Entities;
using WebApp.Music.DAL.Interfaces;
using WebApp.Music.DAL.Repositories;

namespace WebApp.Music.BL
{
    public class Service : IService
    {
        IUnitOfWork unitOfWork { get; set; }
        public Service(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }
        public Service()   // delete !!! DI
        {
            this.unitOfWork = new UnitOfWork();
        }

        public int CreateAlbum(Album value)
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

        public string CreateTrack(Track value)
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

        public string DeleteAlbum(int id)
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

        public string DeleteTrack(int id)
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

        public Album ReadAlbum(int id)
        {
            var value = unitOfWork.Albums.Get(id);
            return value;
        }

        public IEnumerable<Album> ReadAlbums()
        {
            var values = unitOfWork.Albums.GetAll();
            return values;
        }

        public IEnumerable<Track> ReadTrack(int id)
        {
            var values = unitOfWork.Tracks.Find(x => x.AlbumId == id);
            return values;
        }

        public IEnumerable<Track> ReadTracks()
        {
            var values = unitOfWork.Tracks.GetAll();
            return values;
        }

        public string UpdateAlbum(int id, Album value)
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

        public void UpdateTrack(Track value)
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

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
