using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestGameCars.Entities
{
   public class Line
    {
        [Key] 
        public int idLine { get; set; }
        public string nameLine { get; set; }
        public List<Track> tracks { get; set; }
        public List<Game> games { get; set; }

    }
}
