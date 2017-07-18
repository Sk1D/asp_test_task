using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Music.DAL.Entities
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public Album()
        {
            Tracks = new List<Track>();
        }

    }
}
