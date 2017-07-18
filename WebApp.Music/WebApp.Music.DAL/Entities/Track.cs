using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Music.DAL.Entities
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public TimeSpan Time { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
