using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Music.DAL.Entities;
using WebApp.Music.DAL.Interfaces;

namespace WebApp.Music.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SQLContext db;
        private TrackRepository trackRepository;
        private AlbumRepository albumRepository;
        public UnitOfWork()
        {
            this.db = new SQLContext();
        }
        public UnitOfWork(string connectionString)
        {
            this.db = new SQLContext(connectionString);
        }
        public IRepository<Album> Albums
        {
            get
            {
                if (albumRepository == null)
                {
                    albumRepository = new AlbumRepository(db);
                }
                return albumRepository;
            }
        }

        public IRepository<Track> Tracks
        {
            get
            {
                if (trackRepository == null)
                {
                    trackRepository = new TrackRepository(db);
                }
                return trackRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
