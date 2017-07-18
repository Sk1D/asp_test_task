using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Music.DAL.Entities;
using WebApp.Music.DAL.Interfaces;
using System.Data.Entity;

namespace WebApp.Music.DAL.Repositories
{
    public class TrackRepository : IRepository<Track>
    {
        private SQLContext db;
        public TrackRepository(SQLContext context)
        {
            this.db = context;
        }
        public void Create(Track value)
        {
            db.Tracks.Add(value);
        }

        public void Delete(int id)
        {
            Track track = db.Tracks.Find(id);
            if (track != null)
            {
                db.Tracks.Remove(track);
            }
        }

        public IEnumerable<Track> Find(Func<Track, bool> predicate)
        {
            return db.Tracks.Include(a => a.Album).Where(predicate);
        }

        public Track Get(int id)
        {
            return db.Tracks.Find(id);
        }

        public IEnumerable<Track> GetAll()
        {
            return db.Tracks.Include(a => a.Album);
        }

        public void Update(Track value)
        {
            db.Entry(value).State = EntityState.Modified;
        }
    }
}
