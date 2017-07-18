using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Music.DAL.Entities;

namespace WebApp.Music.BL
{
    public interface  IService
    {
        int CreateAlbum(Album value);
        string CreateTrack(Track value);
        IEnumerable<Album> ReadAlbums();
        Album ReadAlbum(int id);
        IEnumerable<Track> ReadTrack(int id);
        IEnumerable<Track> ReadTracks();
        string UpdateAlbum(int id, Album value);
        void UpdateTrack(Track value);
        string DeleteAlbum(int id);
        string DeleteTrack(int id);
        void Dispose();



    }
}
