using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Music.DAL.Entities;

namespace WebApp.Music.DAL
{
    public class SQLContext:DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public SQLContext() : base("MusicDB")
        {
            
        }
        public SQLContext(string connectionString) : base(connectionString)
        {

        }
    }
}
