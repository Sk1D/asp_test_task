using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Music.DAL.Entities;

namespace WebApp.Music.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Album> Albums { get; }
        IRepository<Track> Tracks { get; }
        void Save();
    }
}
