using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Music.DAL.Entities;
using WebApp.Music.DAL.Interfaces;

namespace WebApp.Music.DAL.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private SQLContext db;
        public AlbumRepository(SQLContext context)
        {
            this.db = context;
        }
        public void Create(Album value)
        {
            db.Albums.Add(value);
        }

        public void Delete(int id)
        {
            Album album = db.Albums.Find(id);
            if (album != null)
            {
                db.Albums.Remove(album);
            }

        }

        public IEnumerable<Album> Find(Func<Album, bool> predicate)
        {
            return db.Albums.Where(predicate);
        }


        public Album Get(int id)
        {
            return db.Albums.Find(id);
        }

        public IEnumerable<Album> GetAll()
        {
            return db.Albums;
        }

        public void Update(Album value)
        {
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
